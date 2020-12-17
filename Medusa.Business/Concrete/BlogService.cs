using Medusa.Business.Interface;
using Medusa.DataAccess.Interface;
using Medusa.DataTransferObject;
using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.Business.Concrete
{
    public class BlogService : GenericService<BlogEntity>, IBlogService
    {
        private IGenericDal<BlogEntity> _genericDal;
        private IGenericDal<CategoryBlogEntity> _categoryBlogService;
        private IBlogDal _blogDal;
        public BlogService(IGenericDal<BlogEntity> genericDal, IGenericDal<CategoryBlogEntity> categoryBlogService, IBlogDal blogDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryBlogService = categoryBlogService;
            _blogDal = blogDal;
        }

        public async Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var insertedEntity = await _categoryBlogService
                    .GetAsync(a => a.CategoryId == categoryBlogDto.CategoryId && a.BlogId == categoryBlogDto.BlogId);

            if (insertedEntity == null)
                await _categoryBlogService.AddAsync(new CategoryBlogEntity
                {
                    CategoryId = categoryBlogDto.CategoryId,
                    BlogId = categoryBlogDto.BlogId
                });
        }

        public async Task RemoveToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var deletedEntity = await _categoryBlogService
                  .GetAsync(a => a.CategoryId == categoryBlogDto.CategoryId && a.BlogId == categoryBlogDto.BlogId);

            if (deletedEntity != null)
                await _categoryBlogService.RemoveAsync(deletedEntity);
        }
        public async Task<List<BlogEntity>> GetAllSortedByPostedTimeAsync()
        {
            return await _genericDal.GetAllAsync(I => I.PostedTime);
        }

        public async Task<List<BlogEntity>> GetAllByCategoryIdAsync(int id)
        {
            return await _blogDal.GetAllByCategoryIdAsync(id);
        }

        public async Task<List<CategoryEntity>> GetCategoriesByBlogIdAsync(int blogId)
        {
            return await _blogDal.GetCategoriesByBlogIdAsync(blogId);
        }

        public async Task<List<BlogEntity>> GetLastSizeAsync(int size)
        {
            return await _blogDal.GetLastSizeAsync(size);
        }

        public async Task<List<BlogEntity>> SearchBlogAsync(string searchString)
        {
            return await _blogDal.GetAllAsync(a => a.Title.Contains(searchString) ||
            a.LongDescription.Contains(searchString) || a.ShortDescription.Contains(searchString), b => b.PostedTime);
        }
    }
}
