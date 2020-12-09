using AutoMapper;
using Medusa.DataTransferObject;
using Medusa.Entities;
using Medusa.WebAPI.Models;
namespace Medusa.WebAPI.MapProfile
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<BlogDto, BlogEntity>();
            CreateMap<BlogEntity, BlogDto>();

            CreateMap<BlogAddModel, BlogEntity>();
            CreateMap<BlogEntity, BlogAddModel>();

            CreateMap<BlogUpdateModel, BlogEntity>();
            CreateMap<BlogEntity, BlogUpdateModel>();

            CreateMap<BlogDto, BlogEntity>();
            CreateMap<BlogEntity, BlogDto>();

            CreateMap<CategoryAddDto, CategoryEntity>();
            CreateMap<CategoryEntity, CategoryAddDto>();

            CreateMap<CategoryDto, CategoryEntity>();
            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<CategoryUpdateDto, CategoryEntity>();
            CreateMap<CategoryEntity, CategoryUpdateDto>();
        }
    }
}
