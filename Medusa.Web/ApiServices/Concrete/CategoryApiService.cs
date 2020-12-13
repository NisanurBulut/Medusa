using Medusa.WebUI.ApiServices.Interfaces;
using Medusa.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Medusa.WebUI.ApiServices.Concrete
{
    public class CategoryApiService : ICategoryApiService
    {
        private HttpClient _httpClient;
        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:55315/api/category");
        }
        public async Task<List<CategoryListModel>> GetAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync(_httpClient.BaseAddress+"/GetAllSortedById");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CategoryListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<List<CategoryWithBlogsCountModel>> GetAllWithBlogsCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/GetWithBlogsWithCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CategoryWithBlogsCountModel>>
                    (await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}
