using System.Diagnostics;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
[GitHubActions(
    "continuous",
    GitHubActionsImage.WindowsLatest,
    On = new[] { GitHubActionsTrigger.Push },
    InvokedTargets = new[] { nameof(CompileAndAnalyze) })]
partial class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main() => Execute<Build>(x => x.CompileAndAnalyze);

    [Solution] readonly Solution Solution;

    AbsolutePath BuildDirectory => RootDirectory / "build";
    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
    AbsolutePath AnalysisArtifactsDirectory => ArtifactsDirectory / "Analysis";

    Target OpenReport => _ => _
        .Executes(() =>
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = ArtifactsDirectory / "Analysis.html",
                UseShellExecute = true,
            };

            Process.Start(processStartInfo);
        });

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj", "**/AppPackages").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Clean)
        .DependsOn(Restore)
        .Executes(() =>
        {
            MsBuildOutput = MSBuild(s => s
                .SetTargetPath(Solution)
                .SetConfiguration(Configuration));
        });

    Target CopyStaticArtifacts => _ => _
        .After(Clean)
        .Executes(() =>
        {
            EnsureExistingDirectory(ArtifactsDirectory);

            CopyDirectoryRecursively(BuildDirectory / "StaticArtifacts",
                ArtifactsDirectory,
                DirectoryExistsPolicy.Merge,
                FileExistsPolicy.OverwriteIfNewer);
        });

    Target CompileAndAnalyze => _ => _
        .Produces(ArtifactsDirectory)
        .DependsOn(Compile)
        .DependsOn(GetRoslynAnalyzersResults)
        .DependsOn(CalculateMetrics)
        .DependsOn(RunReSharperInspection)
        .DependsOn(FindDuplications)
        .DependsOn(RunTestsWithCoverage);
}