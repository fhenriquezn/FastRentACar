using FastRentACar.BusinessLogic.Services;
using FastRentACar.BusinessLogic.Services.Contracts;
using FastRentACar.Common.Filters;
using FastRentACar.DataAccess;
using FastRentACar.DataAccess.Contracts;
using FastRentACar.DataAccess.Core;
using FastRentACar.DataAccess.Repositories;
using FastRentACar.Domain.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace FastRentACar.BusinessLogic.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureSetting(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<Settings>(Configuration.GetSection("Settings"));
        }

        /// <summary>
        /// Configure DI for application services
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICryptoService, CryptoService>();
        }

        public static void RegisterRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
        }

        public static void Configure(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddMvc(mvc =>
            {
                mvc.Filters.Add(new ValidatorActionFilter());
            });
        }

        /// <summary>
        /// Configure JWT authentication
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            // configure jwt authentication
            IConfigurationSection JWTSection = Configuration.GetSection("Settings:JWTSettings");
            var appSettings = JWTSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
