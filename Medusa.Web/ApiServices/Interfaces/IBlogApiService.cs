using Medusa.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medusa.WebUI.ApiServices.Interfaces
{
    public interface IBlogApiService
    {
        Task<List<BlogListModel>> GetAllAsync();
        Task<List<CommentListModel>> GetCommentsAsync(int blogId, int? parentCommentId);
        Task<BlogListModel> GetByIdAsync(int id);
        Task<List<BlogListModel>> GetAllByCategoryIdAsync(int id);
        Task AddAsync(BlogAddModel model);
        Task UpdateAsync(BlogUpdateModel model);
        Task DeleteAsync(int id);
        Task AddToCommentAsync(CommentAddModel model);
        Task<List<CategoryListModel>> GetCategoriesAsync(int id);
        Task<List<BlogListModel>> GetLastSizeBlogAsync(int size);
        Task AddToCategoryAsync(CategoryBlogModel model);
        Task RemoveFromCategoryAsync(CategoryBlogModel model);
        Task<List<BlogListModel>> SearchAsync(string s);
    }
}
