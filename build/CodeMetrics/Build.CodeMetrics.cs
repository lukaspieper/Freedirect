using System.IO;
using System.Xml.Xsl;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.IO.FileSystemTasks;
using static Utilities.XmlTransformation;

partial class Build
{
    [PackageExecutable(packageId: "Microsoft.CodeAnalysis.Metrics", packageExecutable: "Metrics.exe")]
    readonly Tool Metrics;

    AbsolutePath CodeMetricsTransformXsltFile => BuildDirectory / "CodeMetrics" / "TransformCodeMetricsResults.xslt";
    AbsolutePath CodeMetricsArtifactsDirectory => AnalysisArtifactsDirectory / "CodeMetrics";
    AbsolutePath CodeMetricsXmlResultsFile => CodeMetricsArtifactsDirectory / "CodeMetrics.xml";
    AbsolutePath CodeMetricsHtmlReportFile => CodeMetricsArtifactsDirectory / "CodeMetrics.html";

    Target CalculateMetrics => _ => _
        .DependsOn(CopyAssetsToArtifacts)
        .After(Compile)
        .ProceedAfterFailure()
        .Executes(() =>
        {
            // Cleaning this specific directory allows running this target on its own without deleting other results.
            EnsureCleanDirectory(CodeMetricsArtifactsDirectory);

            Metrics($"/SOLUTION:\"{Solution}\" /OUT:\"{CodeMetricsXmlResultsFile}\"");

            TransformMetricsResults();
            FailTargetOnTooLowMaintainability();
        });

    void TransformMetricsResults()
    {
        var arguments = new XsltArgumentList();
        arguments.AddParam("maintainability_index_minimum", "", MaintainabilityIndexMinimum);

        TransformXml(CodeMetricsXmlResultsFile, CodeMetricsTransformXsltFile, CodeMetricsHtmlReportFile, arguments);
    }

    void FailTargetOnTooLowMaintainability()
    {
        var html = File.ReadAllText(CodeMetricsHtmlReportFile);

        if (html.Contains("bgcolor=\"#FF221E\""))
        {
            Fail($"CodeMetrics analysis found member with MaintainabilityIndex less than required value of '{MaintainabilityIndexMinimum}'.");
        }
    }
}
