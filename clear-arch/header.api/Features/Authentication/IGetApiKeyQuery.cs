namespace api.Features.Authentication
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IGetApiKeyQuery" />.
    /// </summary>
    public interface IGetApiKeyQuery
    {
        /// <summary>
        /// The Execute.
        /// </summary>
        /// <param name="providedApiKey">The providedApiKey<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ApiKey}"/>.</returns>
        Task<ApiKey> Execute(string providedApiKey);
    }
}