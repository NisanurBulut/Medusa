using System.Collections.Generic;
using System.Threading.Tasks;
using Medusa.WebUI.Models;
namespace Medusa.WebUI.ApiServices.Interfaces
{
    public interface ICategoryApiService
    {
        Task<List<CategoryListModel>> GetAllAsync();
        Task<CategoryListModel> GetByIdAsync(int id);
        Task<List<CategoryWithBlogsCountModel>> GetAllWithBlogsCountAsync();
        Task AddAsync(CategoryAddModel model);
        Task UpdateAsync(CategoryUpdateModel model);
        Task DeleteAsync(int id);
    }
}
