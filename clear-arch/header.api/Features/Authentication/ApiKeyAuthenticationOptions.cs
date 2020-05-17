namespace api.Features.Authentication
{
    using Microsoft.AspNetCore.Authentication;

    /// <summary>
    /// Defines the <see cref="ApiKeyAuthenticationOptions" />.
    /// </summary>
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        /// <summary>
        /// Defines the DefaultScheme.
        /// </summary>
        public const string DefaultScheme = "API Key";

        /// <summary>
        /// Gets the Scheme.
        /// </summary>
        public string Scheme => DefaultScheme;

        /// <summary>
        /// Defines the AuthenticationType.
        /// </summary>
        public string AuthenticationType = DefaultScheme;
    }
}