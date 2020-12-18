using Medusa.WebUI.ApiServices.Interfaces;
using Medusa.WebUI.Extensions;
using Medusa.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Medusa.WebUI.ApiServices.Concrete
{
    public class BlogApiService : IBlogApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpcontextAccessor; // Sessiona erişmek için kullanıcaz
        public BlogApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpcontextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:55315/api/blog");
        }
        public async Task<List<BlogListModel>> GetAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync(_httpClient.BaseAddress + "/GetAllBlogs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<BlogListModel>>(await responseMessage.Content.ReadAsStringAsync());
                return result ?? new List<BlogListModel>();
            }
            return null;
        }
        public async Task<List<BlogListModel>> GetAllByCategoryIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/GetAllByCategoryId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<BlogListModel>>
                    (await responseMessage.Content.ReadAsStringAsync());
                return result ?? new List<BlogListModel>();
            }
            return null;
        }
        public async Task<BlogListModel> GetByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/GetBlogById?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<BlogListModel>(await responseMessage.Content.ReadAsStringAsync());
                return result ?? new BlogListModel();
            }
            return null;
        }
        public async Task AddAsync(BlogAddModel model)
        {
            MultipartFormDataContent formDataContent = new MultipartFormDataContent();

            if (model.Image != null)
            {
                var stream = new MemoryStream();
                await model.Image.CopyToAsync(stream);
                var bytes = stream.ToArray();

                var user = _httpcontextAccessor.HttpContext.Session.GetObject<AppUserViewModel>("activeUser");
                model.AppUserId = user.Id;

                // resimi byte'a çeviricez
                ByteArrayContent byteContent = new ByteArrayContent(bytes);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);

                formDataContent.Add(byteContent, nameof(BlogAddModel.Image), model.Image.FileName);

                formDataContent.Add(new StringContent(model.AppUserId.ToString()), nameof(BlogAddModel.AppUserId));

                formDataContent.Add(new StringContent(model.ShortDescription), nameof(BlogAddModel.ShortDescription));

                formDataContent.Add(new StringContent(model.LongDescription), nameof(BlogAddModel.LongDescription));

                formDataContent.Add(new StringContent(model.Title), nameof(BlogAddModel.Title));

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpcontextAccessor.HttpContext.Session.GetString("token"));

                await _httpClient.PostAsync($"{_httpClient.BaseAddress}/CreateBlog", formDataContent);

            }
        }
        public async Task UpdateAsync(BlogUpdateModel model)
        {
            MultipartFormDataContent formDataContent = new MultipartFormDataContent();

            if (model.Image != null)
            {
                var stream = new MemoryStream();
                await model.Image.CopyToAsync(stream);
                var bytes = stream.ToArray();

                var user = _httpcontextAccessor.HttpContext.Session.GetObject<AppUserViewModel>("activeUser");
                model.AppUserId = user.Id;

                // resimi byte'a çeviricez
                ByteArrayContent byteContent = new ByteArrayContent(bytes);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);
                formDataContent.Add(byteContent, nameof(BlogAddModel.Image), model.Image.FileName);
            }

            formDataContent.Add(new StringContent(model.AppUserId.ToString()), nameof(BlogAddModel.AppUserId));

            formDataContent.Add(new StringContent(model.Id.ToString()), nameof(BlogUpdateModel.Id));

            formDataContent.Add(new StringContent(model.ShortDescription), nameof(BlogAddModel.ShortDescription));

            formDataContent.Add(new StringContent(model.LongDescription), nameof(BlogAddModel.LongDescription));

            formDataContent.Add(new StringContent(model.Title), nameof(BlogAddModel.Title));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpcontextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PutAsync($"{_httpClient.BaseAddress}/UpdateBlog", formDataContent);


        }
        public async Task DeleteAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpcontextAccessor.HttpContext.Session.GetString("token"));
            var responseMessage = await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/DeleteBlog?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<BlogListModel>>
                    (await responseMessage.Content.ReadAsStringAsync());
            }
        }
        public async Task<List<CommentListModel>> GetCommentsAsync(int blogId, int? parentCommentId)
        {
            var responseMessage = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/GetComments?blogId={blogId}&parentCommentId={parentCommentId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CommentListModel>>
                    (await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task AddToCommentAsync(CommentAddModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync($"{_httpClient.BaseAddress}/AddComment", content);
        }
        public async Task<List<CategoryListModel>> GetCategoriesAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/GetCategoriesByBlogIdAsync?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CategoryListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<List<BlogListModel>> GetLastSizeBlogAsync()
        {
            var responseMessage = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/GetLastSizeBlogAsync?size={5}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<BlogListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<List<BlogListModel>> SearchAsync(string s)
        {
            var responseMessage = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/Search?s={s}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<BlogListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task AddToCategoryAsync(CategoryBlogModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "applicatin/json");
            await _httpClient.PostAsync($"{_httpClient.BaseAddress}/AddToCategory",content);
        }
        public async Task RemoveFromCategoryAsync(CategoryBlogModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "applicatin/json");
            await _httpClient.PostAsync($"{_httpClient.BaseAddress}/RemoveFromCategory", content);
        }
    }
}
