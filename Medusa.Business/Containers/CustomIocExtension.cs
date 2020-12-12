using Medusa.Business.Concrete;
using Medusa.Business.Interface;
using Medusa.DataAccess.Concrete;
using Medusa.DataAccess.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Medusa.Business.Containers
{
    public static class CustomIocExtension
    {
        public static void AddDependecy(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>),typeof(GenericDal<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped<IBlogService,BlogService>();
            services.AddScoped<IBlogDal, BlogRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDal, CategoryRepository>();
        }
    }
}
