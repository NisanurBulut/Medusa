using Medusa.WebUI.ApiServices.Interfaces;
using Medusa.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Medusa.WebUI.ApiServices.Concrete
{
    public class AuthApiService : IAuthApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private HttpClient _httpClient;
        public AuthApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("http://localhost:55315/api/auth");
        }

        public async Task<bool> SignIn(AppUserLoginModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync($"{_httpClient.BaseAddress}/SignIn", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var accessToken = JsonConvert.DeserializeObject<AccessTokenModel>
                    (await responseMessage.Content.ReadAsStringAsync());
                _httpContextAccessor.HttpContext.Session.SetString("token", accessToken.Token);
                return true;
            }
            return false;
        }
    }
}
