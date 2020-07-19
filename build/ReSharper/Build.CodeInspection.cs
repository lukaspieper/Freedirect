using System.IO;
using System.Text.RegularExpressions;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.InspectCode;
using static Nuke.Common.Logger;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.InspectCode.InspectCodeTasks;
using static Utilities.XmlTransformation;

partial class Build
{
    AbsolutePath CodeInspectionTransformXsltFile => BuildDirectory / "ReSharper" / "TransformCodeInspectionResults.xslt";
    AbsolutePath CodeInspectionArtifactsDirectory => AnalysisArtifactsDirectory / "CodeInspection";
    AbsolutePath CodeInspectionXmlResultsFile => CodeInspectionArtifactsDirectory / "CodeInspection.xml";
    AbsolutePath CodeInspectionHtmlReportFile => CodeInspectionArtifactsDirectory / "CodeInspection.html";

    Target RunReSharperInspection => _ => _
        .DependsOn(CopyStaticArtifacts)
        .After(Compile)
        .Executes(() =>
        {
            // Cleaning this specific directory allows running this target on its own without deleting other results.
            EnsureCleanDirectory(CodeInspectionArtifactsDirectory);

            InspectCode(_ => _
                .SetTargetPath(Solution)
                .SetOutput(CodeInspectionXmlResultsFile)
            );

            TransformCodeInspectionResults();
            LogCodeInspectionResults();
        });

    void TransformCodeInspectionResults()
    {
        TransformXml(CodeInspectionXmlResultsFile, CodeInspectionTransformXsltFile, CodeInspectionHtmlReportFile);
    }

    void LogCodeInspectionResults()
    {
        var htmlOutput = File.ReadAllText(CodeInspectionHtmlReportFile);

        var numberOfWarnings = Regex.Matches(htmlOutput, "WARNING").Count;
        if (numberOfWarnings > 0)
        {
            Warn($"ReSharper Code Inspection found {numberOfWarnings} warnings.");
        }

        var numberOfSuggestions = Regex.Matches(htmlOutput, "SUGGESTION").Count;
        if (numberOfSuggestions > 0)
        {
            Warn($"ReSharper Code Inspection found {numberOfSuggestions} suggestions.");
        }
    }
}