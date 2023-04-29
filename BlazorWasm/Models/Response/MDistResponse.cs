using System.Text.Json.Serialization;

namespace BlazorWasm.Models.Response
{
    public class MDistResponse
    {
        [JsonPropertyName("_ClientID")]
        public int ClientID { get; set; }

        [JsonPropertyName("_pDate")]
        public DateTime PDate { get; set; }

        [JsonPropertyName("_Flash")]
        public string Flash { get; set; }

        [JsonPropertyName("_Media")]
        public string Media { get; set; }

        [JsonPropertyName("_Support")]
        public string Support { get; set; }

        [JsonPropertyName("_Subject")]
        public string Subject { get; set; }

        [JsonPropertyName("_Summary")]
        public string Summary { get; set; }

        [JsonPropertyName("_Mention")]
        public string Mention { get; set; }

        [JsonPropertyName("_object")]
        public string Object { get; set; }

        [JsonPropertyName("_Link")]
        public string Link { get; set; }

        [JsonPropertyName("_Tonalite")]
        public int Tonalite { get; set; }

        [JsonPropertyName("_Citee")]
        public int Citee { get; set; }

        [JsonPropertyName("_seen")]
        public int Seen { get; set; }
    }
}
