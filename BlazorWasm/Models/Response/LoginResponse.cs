using System.Text.Json.Serialization;

namespace BlazorWasm.Models.Response
{
    public class UserLoginResponse
    {
        public string Username { get; set; }
        public int? Permissions { get; set; }
        public int? UserRole { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }

        [JsonPropertyName("loginResponse")]
        public string LoginResponse { get; set; }
        public string AuthToken { get; set; }
    }
}
