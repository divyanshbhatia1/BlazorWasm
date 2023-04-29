using BlazorWasm.Models;
using BlazorWasm.Models.Response;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Text.Json;
using System.Web;

namespace BlazorWasm.Services
{
    public class ApiWrapper
    {
        private readonly RestClient _client;

        public ApiWrapper(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<T> Get<T>(string url, Dictionary<string, string> parameters = null)
        {
            var request = new RestRequest(url, Method.Get);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    request.AddQueryParameter(parameter.Key, parameter.Value);
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
            return await _apiWrapper.Get<UserLoginResponse>(_apiUrls.Login, new Dictionary<string, string>
            {
                { "username", username },
                { "password", HttpUtility.UrlEncode(password) + "%" }
            });
        }
    }
}
