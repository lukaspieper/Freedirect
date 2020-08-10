using System.Text.Json.Serialization;

namespace Freedirect.Application.Settings
{
    public class UserSettings
    {
        [JsonPropertyName("SelectedSearchEngine")]
        public string SelectedSearchEngine { get; set; } = "Bing";
    }
}