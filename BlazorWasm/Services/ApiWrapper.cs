using BlazorWasm.Models;
using BlazorWasm.Models.Response;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Net;
using System.Text.Json;
using System.Web;

namespace BlazorWasm.Services
{
    public class ApiWrapper
    {
        private readonly RestClient _client;
        private readonly string _baseUrl;

        public ApiWrapper(string baseUrl)
        {
            _client = new RestClient();
            _baseUrl = baseUrl;
        }

        public async Task<T> Get<T>(string url, Dictionary<string, string> parameters = null)
        {
            var request = new RestRequest(_baseUrl + "/" + url, Method.Get);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    url += "?" + parameter;
                }
            }

            var response = await _client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<T>(response.Content);
            }

            throw new Exception(JsonSerializer.Deserialize<string>(response.Content));
        }
    }

    public class ApiService
    {
        private readonly ApiWrapper _apiWrapper;
        private readonly ApiUrls _apiUrls;

        public ApiService(IOptions<ApiUrls> apiUrlsOptions)
        {
            _apiUrls = apiUrlsOptions.Value;
            _apiWrapper = new ApiWrapper(_apiUrls.Base);
        }

        public async Task<UserLoginResponse> Login(string username, string password)
        {
            var url = $"{_apiUrls.Login}?username={username}&password={HttpUtility.UrlEncode(password)}%";
            return await _apiWrapper.Get<UserLoginResponse>(url);
        }
    }
}
