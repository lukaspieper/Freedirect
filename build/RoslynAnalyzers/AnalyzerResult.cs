using System.Text.RegularExpressions;
using System.Xml.Serialization;
using JetBrains.Annotations;

[XmlType]
public class AnalyzerResult
{
    [UsedImplicitly]
    public AnalyzerResult()
    {
    }

    public AnalyzerResult(Match match)
    {
        Location = match.Groups["Location"].Value;
        Severity = match.Groups["Severity"].Value;
        Code = match.Groups["Code"].Value;
        Description = match.Groups["Description"].Value;
        Project = match.Groups["Project"].Value;
    }

    [XmlAttribute]
    public string Location { get; set; }

    [XmlAttribute]
    public string Severity { get; set; }

    [XmlAttribute]
    public string Code { get; set; }

    [XmlAttribute]
    public string Description { get; set; }

    [XmlAttribute]
    public string Project { get; set; }

    public override string ToString() => $"{Location} {Code} {Description}";
}
