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

        public async Task<int> GetLastIdAsync()
        {
            string getId = apiString + @"/api/PackagedUnit/LastId";

            return await _httpClient.GetFromJsonAsync<int>(getId);
        }


        #region Post

        public async Task<int?> PostPackagedUnitAsync(PackagedUnit inPU)
        {
            string path = apiString + "/api/PackagedUnit";

            string jsonData = JsonSerializer.Serialize(inPU);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(path, content);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                // ✅ If API returns just the ID as a number like: 123
                if (int.TryParse(responseBody, out int id))
                {
                    return id;
                }

                // Assuming the API returns a JSON object like { "id": 123 }
                using JsonDocument doc = JsonDocument.Parse(responseBody);
                if (doc.RootElement.TryGetProperty("id", out JsonElement idElement))
                {
                    return idElement.GetInt32();
                }
            }

            return null; // or throw exception / handle error as needed
        }

        #endregion

        public async Task PostPackagedUnitUpdateAsync(PackagedUnit inPU)
        {
            string path = apiString + "/api/PackagedUnit/update";

            var response = await _httpClient.PostAsJsonAsync(path, inPU);
            response.EnsureSuccessStatusCode(); // throws if not 200-299
        }


        //private async Task<T?> GetDataAsync<T>(string url)
        //{
        //    return await _httpClient.GetFromJsonAsync<T>(url);
        //}
    }
}
