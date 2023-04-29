using System.Text.Json.Serialization;

namespace BlazorWasm.Models.Response
{
    public class UserLoginResponse
    {
        [JsonPropertyName("_username")]
        public string Username { get; set; }

        [JsonPropertyName("_loginResponse")]
        public string LoginResponse { get; set; }

        [JsonPropertyName("_UserRole")]
        public int UserRole { get; set; }

        [JsonPropertyName("_authtoken")]
        public string Authtoken { get; set; }
    }
}
