using System.Xml.Xsl;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using static Nuke.Common.Logger;
using static Nuke.Common.IO.FileSystemTasks;

partial class Build
{
    [PackageExecutable(packageId: "Microsoft.CodeAnalysis.Metrics", packageExecutable: "Metrics.exe")]
    readonly Tool Metrics;

    AbsolutePath CodeMetricsArtifactsDirectory => ArtifactsDirectory / "Analysis" / "CodeMetrics";

    Target CalculateMetrics => _ => _
        .DependsOn(CopyAssetsToArtifacts)
        .After(Compile)
        .Executes(() =>
        {
            // Cleaning this specific directory allows running this target on its own without deleting other results.
            EnsureCleanDirectory(CodeMetricsArtifactsDirectory);

            var metricsOutputPath = CodeMetricsArtifactsDirectory / "Results.xml";
            Metrics($"/SOLUTION:\"{Solution}\" /OUT:\"{metricsOutputPath}\"");

            TransformMetricsResults(metricsOutputPath);
        });

    void TransformMetricsResults(string metricsOutputPath)
    {
        Normal("Transforming CodeMetrics results...");

        var transformation = new XslCompiledTransform();
        transformation.Load(BuildDirectory / "CodeMetrics" / "TransformCodeMetricsResults.xslt");
        transformation.Transform(metricsOutputPath, CodeMetricsArtifactsDirectory / "CodeMetrics.html");

        Normal("Transformation completed.");
    }
}
