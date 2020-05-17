namespace api.Features.Authentication
{
    using Microsoft.AspNetCore.Authentication;
    using System;

    /// <summary>
    /// Defines the <see cref="AuthenticationBuilderExtensions" />.
    /// </summary>
    public static class AuthenticationBuilderExtensions
    {
        /// <summary>
        /// The AddApiKeySupport.
        /// </summary>
        /// <param name="authenticationBuilder">The authenticationBuilder<see cref="AuthenticationBuilder"/>.</param>
        /// <param name="options">The options<see cref="Action{ApiKeyAuthenticationOptions}"/>.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddApiKeySupport(this AuthenticationBuilder authenticationBuilder, Action<ApiKeyAuthenticationOptions> options)
        {
            return authenticationBuilder.AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.DefaultScheme, options);
        }
    }
}