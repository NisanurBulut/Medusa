using Medusa.DataTransferObject;
using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.Business.Interface
{
    // BlogEntity tip için IGenericDal dan kalıtsal geç
    public interface IBlogService : IGenericService<BlogEntity>
    {
        Task<List<BlogEntity>> GetAllSortedByPostedTimeAsync();
        Task<List<BlogEntity>> SearchBlogAsync(string searchString);
        Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task RemoveToCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task<List<BlogEntity>> GetAllByCategoryIdAsync(int id);
        Task<List<CategoryEntity>> GetCategoriesByBlogIdAsync(int blogId);
        Task<List<BlogEntity>> GetLastSizeAsync(int size);
    }
}
