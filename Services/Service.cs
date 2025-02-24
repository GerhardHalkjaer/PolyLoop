using Entities;
using System.Net.Http.Json;

namespace Services
{
    public class Service
    {
        private readonly HttpClient _httpClient;
        private readonly string apiString;

        public Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
             apiString = @"https://localhost:7299/";
        }

        public MaterialType GetAllMaterialTypes()
        {
            string getall = @"/api/MaterialType";

            return null;
        }


        private async Task<T?> GetDataAsync<T>(string url)
        {
            return await _httpClient.GetFromJsonAsync<T>(url);
        }
    }
}
