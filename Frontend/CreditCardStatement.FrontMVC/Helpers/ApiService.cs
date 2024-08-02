using CreditCardStatement.FrontMVC.Models.ApiService;
using Newtonsoft.Json;

namespace CreditCardStatement.FrontMVC.Helpers
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BaseResponseModel> GetAsync(string endpoint)
        {
            var response = await _httpClient.GetStringAsync(endpoint);
            return JsonConvert.DeserializeObject<BaseResponseModel>(response);
        }

        public async Task<BaseResponseModel> PostAsync(string endpoint, object data)
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, data);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResponseModel>(json);
        }

        public async Task<BaseResponseModel> PutAsync(string endpoint, object data)
        {
            var response = await _httpClient.PutAsJsonAsync(endpoint, data);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResponseModel>(json);
        }

        public async Task DeleteAsync(string endpoint)
        {
            await _httpClient.DeleteAsync(endpoint);
        }
    }
}
