using Core.Application.Common.Interfaces;
using Core.Common;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddScoped<IUserManager, UserManagerService>();
            services.AddTransient<INotificationService, NotificationService>();

            services.AddTransient<IDateTime, MachineDateTime>();
            //services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<IdentityDbContext>();

            //if (environment.IsEnvironment("Test"))
            //{
            //    services.AddIdentityServer()
            //        .AddApiAuthorization<ApplicationUser, IdentityDbContext>(options =>
            //        {
            //            options.Clients.Add(new IdentityServer4.Models.Client
            //            {
            //                ClientId = "Northwind.IntegrationTests",
            //                AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
            //                ClientSecrets = { new IdentityServer4.Models.Secret("secret".Sha256()) },
            //                AllowedScopes = { "Northwind.WebUIAPI", "openid", "profile" }
            //            });
            //        }).AddTestUsers(new List<TestUser>
            //        {
            //            new TestUser
            //            {
            //                SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
            //                Username = "jason@northwind",
            //                Password = "Northwind1!",
            //                Claims = new List<Claim>
            //                {
            //                    new Claim(JwtClaimTypes.Email, "jason@northwind")
            //                }
            //            }
            //        });
            //}
            //else
            //{
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, IdentityDbContext>();
            //}

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}