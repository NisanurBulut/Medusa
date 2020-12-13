using Medusa.WebUI.ApiServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Medusa.WebUI.ApiServices.Concrete
{
    public class ImageApiService : IImageApiService
    {
        private readonly HttpClient _httpClient;
        public ImageApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:55315/api/image");
        }
        public async Task<string> GetBlogImageByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"GetBlogImageByIdAsync/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                // byte olarak okunacak
                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();
                return $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }
            return null;
        }
    }
}
