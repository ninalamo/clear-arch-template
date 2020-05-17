namespace api
{
    using api.Features.Authentication;
    using api.Features.Authorization;
    using api.Features.Swagger;
    using api.Filters;
    using application.cqrs.auditTrail.queries;
    using application.infrastructure;
    using application.infrastructure.automapper;
    using application.interfaces;
    using AutoMapper;
    using FluentValidation.AspNetCore;
    using lib.common;
    using lib.infrastructure;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using persistence;
    using System;
    using System.Reflection;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// Defines the <see cref="Startup" />.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the Configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// The ConfigureServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext using SQL Server Provider
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database")));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            }).AddApiKeySupport(options => { });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.OnlyEmployees, policy => policy.Requirements.Add(new OnlyEmployeesRequirement()));
                options.AddPolicy(Policies.OnlyAdmin, policy => policy.Requirements.Add(new OnlyAdminRequirement()));
                options.AddPolicy(Policies.OnlyApiConsumers, policy => policy.Requirements.Add(new OnlyApiConsumersRequirement()));
                options.AddPolicy(Policies.OnlyRockstars, policy => policy.Requirements.Add(new DevelopersOnlyRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, OnlyEmployeesAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OnlyAdminAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OnlyAPIConsumersAuthorizationHandler>();

            services.AddTransient<IGetApiKeyQuery, InMemoryGetApiKeyQuery>();

            services.AddRouting(x => x.LowercaseUrls = true);
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.ConfigureSwaggerFeature();

            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();
            //services.AddTransient<IDateTime, MachineDateTime>();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            // Add MediatR
            services.AddMediatR(typeof(GetAuditTrailsRequestHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddMvcOptions(options => options.EnableEndpointRouting = false)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetAuditTrailsQueryValidator>());

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddHttpClient();

            services.AddCors();

            services.AddResponseCaching();
            services.AddResponseCompression();
            services.Configure<RouteOptions>(o => o.LowercaseUrls = true);
        }

        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/>.</param>
        /// <param name="env">The env<see cref="IWebHostEnvironment"/>.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            //app.UseCors("MyPolicy");
            // global cors policy

            //must be AFTER ROUTING and BEFORE UseAuthorization
            app.UseCors(x => x
            //.WithOrigins("https://localhost:9001")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "KMC Solutions HR API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();

            app.UseMvc();
            app.UseResponseCaching();
            app.UseResponseCompression();

            app.Use(async (context, next) =>
            {
                // For GetTypedHeaders, add: using Microsoft.AspNetCore.Http;
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding", };
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                await next();
            });
        }
    }
}