using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using static Nuke.Common.Logger;
using static Nuke.Common.IO.FileSystemTasks;
using static Utilities.XmlTransformation;

partial class Build
{
    IReadOnlyCollection<Output> MsBuildOutput;

    AbsolutePath RoslynAnalyzersTransformXsltFile => BuildDirectory / "RoslynAnalyzers" / "TransformRoslynAnalyzersResults.xslt";
    AbsolutePath RoslynAnalyzersArtifactsDirectory => AnalysisArtifactsDirectory / "RoslynAnalyzers";
    AbsolutePath RoslynAnalyzersXmlResultsFile => RoslynAnalyzersArtifactsDirectory / "RoslynAnalyzers.xml";
    AbsolutePath RoslynAnalyzersHtmlReportFile => RoslynAnalyzersArtifactsDirectory / "RoslynAnalyzers.html";

    Target GetRoslynAnalyzersResults => _ => _
        .DependsOn(Compile)
        .DependsOn(CopyAssetsToArtifacts)
        .Executes(() =>
        {
            var analyzerResults = GetRoslynAnalyzersResultsFromBuildOutput();

            // TODO: Check if the number of issues from the previous GitHubActions run can be retrieved and cause this step to fail if the value is higher
            if (analyzerResults.Any())
            {
                Warn($"RoslynAnalyzers found {analyzerResults.Count} issues.");
            }

            WriteResultsToXmlFile(analyzerResults);
            TransformAnalyzersResults();
        });

    List<AnalyzerResult> GetRoslynAnalyzersResultsFromBuildOutput()
    {
        var analyzerResultRegex = new Regex(@"^\s*(?'Location'\S*[\(\d*,\d*\)]?)\s*:\s*(?'Severity'[a-z]*)\s*(?'Code'[A-Z]{2}\d{4}):\s*(?'Description'.*)\s\[(?'Project'.*)\]");

        return MsBuildOutput.Select(o => o.Text.Trim())
            .Distinct()
            .Select(line => analyzerResultRegex.Match(line))
            .Where(match => match.Success)
            .Select(match => new AnalyzerResult(match))
            .OrderBy(result => result.Location)
            .ToList();
    }

    void WriteResultsToXmlFile(List<AnalyzerResult> results)
    {
        EnsureExistingDirectory(RoslynAnalyzersArtifactsDirectory);

        var serializer = new XmlSerializer(typeof(List<AnalyzerResult>), new XmlRootAttribute("AnalyzerResults"));

        using var writer = new StreamWriter(RoslynAnalyzersXmlResultsFile);
        serializer.Serialize(writer, results);
    }

    void TransformAnalyzersResults()
    {
        TransformXml(RoslynAnalyzersXmlResultsFile, RoslynAnalyzersTransformXsltFile, RoslynAnalyzersHtmlReportFile);
    }
}
