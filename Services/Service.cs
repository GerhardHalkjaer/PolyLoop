using Entities;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Services
{
    public class Service
    {
        private readonly HttpClient _httpClient;
        private readonly string apiString;

        public Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
             apiString = @"https://localhost:7299";
        }


        #region GetALL
        public async Task<List<MaterialType>> GetAllMaterialTypesAsync()
        {
            string getall = apiString + @"/api/MaterialType";

            return await _httpClient.GetFromJsonAsync<List<MaterialType>>(getall);
        }

        public async Task<List<SpecificType>> GetAllSpecificTypesAsync()
        {
            string getall = apiString + @"/api/SpecificType";

            return await _httpClient.GetFromJsonAsync<List<SpecificType>>(getall);

        }

        public async Task<List<Packaging>> GetAllPackagingsAsync()
        {
            string getall = apiString + @"/api/Packaging";

            return await _httpClient.GetFromJsonAsync<List<Packaging>>(getall);
        }

        public async Task<List<PackagedUnit>> GetAllPackagedUnitAsync()
        {
            string getall = apiString + @"/api/PackagedUnit";

            return await _httpClient.GetFromJsonAsync<List<PackagedUnit>>(getall);
        }

        #endregion

        #region Post

        public async Task<HttpResponseMessage> PostPackagedUnitAsync( PackagedUnit inPU)
        {
            string path = apiString + "/api/PackagedUnit";

            string jsonData = JsonSerializer.Serialize(inPU);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(path, content);

            return response;

        }


        #endregion




        //private async Task<T?> GetDataAsync<T>(string url)
        //{
        //    return await _httpClient.GetFromJsonAsync<T>(url);
        //}
    }
}
