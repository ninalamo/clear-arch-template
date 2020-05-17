namespace api.Features.Json
{
    using System.Text.Json;

    /// <summary>
    /// Defines the <see cref="DefaultJsonSerializerOptions" />.
    /// </summary>
    public static class DefaultJsonSerializerOptions
    {
        /// <summary>
        /// Gets the Options.
        /// </summary>
        public static JsonSerializerOptions Options => new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };
    }
}