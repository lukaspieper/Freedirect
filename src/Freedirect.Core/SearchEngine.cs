using System.Text.Json.Serialization;

namespace Freedirect.Core
{
    public class SearchEngine
    {
        [JsonConstructor]
        public SearchEngine(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; init; }

        public string Address { get; init; }
    }
}