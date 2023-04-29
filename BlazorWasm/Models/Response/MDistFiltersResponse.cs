using System.Text.Json.Serialization;

namespace BlazorWasm.Models.Response
{
    public class MDistFiltersResponse
    {
        [JsonPropertyName("Support")]
        public List<string> Support { get; set; }

        [JsonPropertyName("Mention")]
        public List<string> Mention { get; set; }

        [JsonPropertyName("aObject")]
        public List<string> AObject { get; set; }

        [JsonPropertyName("Tonalite")]
        public List<int> Tonalite { get; set; }

        [JsonPropertyName("Citee")]
        public List<int> Citee { get; set; }

        [JsonPropertyName("Seen")]
        public List<int> Seen { get; set; }
    }
}
