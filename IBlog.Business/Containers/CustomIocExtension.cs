using IBlog.Business.Concrete;
using IBlog.DataAccess.Concrete;
using IBlog.DataAccess.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBlog.Business.Containers
{
    public static class CustomIocExtension
    {
        public static void AddDependecy(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>),typeof(GenericDal<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

        }
    }
}
