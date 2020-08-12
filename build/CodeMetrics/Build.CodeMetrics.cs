using System.IO;
using System.Text.RegularExpressions;
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
        .DependsOn(CopyStaticArtifacts)
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
        var htmlOutput = File.ReadAllText(CodeMetricsHtmlReportFile);

        var numberOfIssues = Regex.Matches(htmlOutput, "bgcolor=\"#FF221E\"").Count;
        if (numberOfIssues > 0)
        {
            Fail($"CodeMetrics analysis found {numberOfIssues} members with MaintainabilityIndex less than required value of '{MaintainabilityIndexMinimum}'.");
        }
    }

}
