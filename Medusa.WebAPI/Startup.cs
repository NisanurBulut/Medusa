using AutoMapper;
using FluentValidation.AspNetCore;
using Medusa.Business.Containers;
using Medusa.Business.StringInfo;
using Medusa.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace Medusa.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Medusa API", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Description = "Bearer {Token}"
                });
            });
            services.Configure<JwtInfo>(Configuration.GetSection("JwtInfo"));
            var jwtInfo = Configuration.GetSection("JwtInfo").Get<JwtInfo>();

            services.AddAutoMapper(typeof(Startup));
            services.AddDependecy();
            services.AddScoped(typeof(ValidIdModel<>));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    // https kapat�l�r
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtInfo.ISSUER,
                        ValidAudience = jwtInfo.AUDIENCE,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtInfo.SECURITYKEY)),
                        ValidateLifetime = true, // token s�resi ge�ince ge�ersiz say�ls�n
                        ValidateAudience = true, // ba�ka adresten istek gelrse ge�ersiz k�l
                        ValidateIssuer = true,
                        ClockSkew = TimeSpan.Zero // sunucular aras�nda zaman fark� koyma
                    };
                });
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).AddFluentValidation();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Error/Error");
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medusa API v1"); });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
