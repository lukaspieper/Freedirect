using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Freedirect.Core
{
    public class SearchEngine
    {
        [UsedImplicitly]
        public SearchEngine()
        {
        }

        public SearchEngine(string name, string address)
        {
            Name = name;
            Address = address;
        }

        [UsedImplicitly]
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [UsedImplicitly]
        [JsonPropertyName("Address")]
        public string Address { get; set; }
    }
}