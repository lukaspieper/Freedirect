using System;
using System.IO;
using System.Text.RegularExpressions;
using Nuke.Common;
using Nuke.Common.IO;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.Logger;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotCover.DotCoverTasks;
using static Utilities.XmlTransformation;

partial class Build
{
    AbsolutePath TrxTransformXsltFile => BuildDirectory / "Tests" / "TransformTrx.xslt";
    AbsolutePath DotCoverArtifactsDirectory => AnalysisArtifactsDirectory / "DotCover";
    AbsolutePath DotNetTestTrxReportFile => DotCoverArtifactsDirectory / "DotNetTest.trx";
    AbsolutePath DotNetTestHtmlReportFile => DotCoverArtifactsDirectory / "DotNetTest.html";

    Target RunTestsWithCoverage => _ => _
        .DependsOn(CopyStaticArtifacts)
        .After(Compile)
        .ProceedAfterFailure()
        .Executes(() =>
        {
            // Cleaning this specific directory allows running this target on its own without deleting other results.
            EnsureCleanDirectory(DotCoverArtifactsDirectory);

            try
            {
                var arguments = BuildDotCoverArguments();
                DotCover(arguments, DotCoverArtifactsDirectory);
            }
            catch (Exception e)
            {
                Warn(e);
            }
            
            TransformTrx();
            FailTargetOnFailingTest();
        });

    string BuildDotCoverArguments()
    {
        var arguments =
            $"dotnet --output=DotCover.html --reportType=HTML --Filters={DotCoverFilter} -- test {Solution} --logger \"trx;LogFileName={DotNetTestTrxReportFile}\"";

        if (InvokedTargets.Contains(Restore))
        {
            arguments += " --no-restore";
        }

        if (InvokedTargets.Contains(Compile))
        {
            arguments += " --no-build";
        }

        return arguments;
    }

    void TransformTrx()
    {
        TransformXml(DotNetTestTrxReportFile, TrxTransformXsltFile, DotNetTestHtmlReportFile);
    }

    void FailTargetOnFailingTest()
    {
        var htmlOutput = File.ReadAllText(DotNetTestHtmlReportFile);

        var numberOfFailingTests = Regex.Matches(htmlOutput, "alt=\"Failed\"").Count;
        if (numberOfFailingTests > 0)
        {
            Fail($"{numberOfFailingTests} tests failed.");
        }
    }
}