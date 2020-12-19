using Medusa.WebUI.ApiServices.Interfaces;
using Medusa.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Medusa.WebUI.ApiServices.Concrete
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor; // Sessiona erişmek için kullanıcaz
        private HttpClient _httpClient;
        public CategoryApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:55315/api/category");
            _httpcontextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(CategoryAddModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpcontextAccessor.HttpContext.Session.GetString("token"));
            var responseMessage = await _httpClient.PostAsync(_httpClient.BaseAddress + "/CreateCategory", content);
        }

        public async Task DeleteAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpcontextAccessor.HttpContext.Session.GetString("token"));
            var responseMessage = await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/DeleteCategory?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<CategoryListModel>>
                    (await responseMessage.Content.ReadAsStringAsync());
            }
        }

        public async Task<List<CategoryListModel>> GetAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync(_httpClient.BaseAddress + "/GetAllSortedById");
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

        public async Task<CategoryListModel> GetByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/GetCategoryById?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryListModel>
                    (await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task UpdateAsync(CategoryUpdateModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpcontextAccessor.HttpContext.Session.GetString("token"));
            var responseMessage = await _httpClient.PutAsync(_httpClient.BaseAddress + "/UpdateCategory", content);
        }
    }
}
