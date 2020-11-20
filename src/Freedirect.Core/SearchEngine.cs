using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Freedirect.Core
{
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "Does not apply to records.")]
    [SuppressMessage("Usage", "CA1801:Review unused parameters", Justification = "Does not apply to records.")]
    public record SearchEngine(
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("Address")] string Address);
}