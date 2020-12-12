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

        public BlogService(IGenericDal<BlogEntity> genericDal, IGenericDal<CategoryBlogEntity> categoryBlogService) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryBlogService = categoryBlogService;
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
    }
}
