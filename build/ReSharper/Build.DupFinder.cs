using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.DupFinder;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DupFinder.DupFinderTasks;
using static Utilities.XmlTransformation;

partial class Build
{
    AbsolutePath DupFinderTransformXsltFile => BuildDirectory / "ReSharper" / "TransformDupFinderResults.xslt";
    AbsolutePath DupFinderArtifactsDirectory => AnalysisArtifactsDirectory / "DupFinder";
    AbsolutePath DupFinderXmlResultsFile => DupFinderArtifactsDirectory / "DupFinder.xml";
    AbsolutePath DupFinderHtmlReportFile => DupFinderArtifactsDirectory / "DupFinder.html";

    Target FindDuplications => _ => _
        .After(Compile)
        .Executes(() =>
        {
            // Cleaning this specific directory allows running this target on its own without deleting other results.
            EnsureCleanDirectory(CodeInspectionArtifactsDirectory);

            DupFinder(_ => _
                .SetSource(Solution)
                .SetOutputFile(DupFinderXmlResultsFile)
            );

            TransformDupFinderResults();
        });

    void TransformDupFinderResults()
    {
        TransformXml(DupFinderXmlResultsFile, DupFinderTransformXsltFile, DupFinderHtmlReportFile);
    }
}