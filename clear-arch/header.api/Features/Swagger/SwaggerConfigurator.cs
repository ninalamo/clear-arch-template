namespace api.Features.Swagger
{
    using api.Features.Shared;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Defines the <see cref="SwaggerConfigurator" />.
    /// </summary>
    public static class SwaggerConfigurator
    {
        /// <summary>
        /// The ConfigureSwaggerFeature.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void ConfigureSwaggerFeature(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KMC API - HR", Version = "v1" });

                c.AddSecurityDefinition(ApiKeyConstants.HeaderName, new OpenApiSecurityScheme
                {
                    Description = "Api key needed to access the endpoints. X-Api-Key: My_API_Key",
                    In = ParameterLocation.Header,
                    Name = ApiKeyConstants.HeaderName,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = ApiKeyConstants.HeaderName,
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = ApiKeyConstants.HeaderName },
                        },
                        new string[] {}
                    }
                });
            });
        }
    }
}