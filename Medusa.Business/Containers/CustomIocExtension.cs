using FluentValidation;
using Medusa.Business.Concrete;
using Medusa.Business.Interface;
using Medusa.Business.Tools;
using Medusa.DataAccess.Concrete;
using Medusa.DataAccess.Interface;
using Microsoft.Extensions.DependencyInjection;
using Medusa.DataTransferObject;
using Medusa.Business.ValidationRules;
using Medusa.DataAccess.Context;

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

            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppUserDal, AppUserRepository>();

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentDal, CommentRepository>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>, CategoryBlogValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();

            services.AddDbContext<DatabaseContext>();
        }
    }
}
