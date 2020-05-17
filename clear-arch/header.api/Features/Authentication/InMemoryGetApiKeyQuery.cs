namespace api.Features.Authentication
{
    using application.interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="InMemoryGetApiKeyQuery" />.
    /// </summary>
    public class InMemoryGetApiKeyQuery : IGetApiKeyQuery
    {
        /// <summary>
        /// Defines the _apiKeys.
        /// </summary>
        private readonly IDictionary<string, ApiKey> _apiKeys;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryGetApiKeyQuery"/> class.
        /// </summary>
        /// <param name="dbContext">The dbContext<see cref="IApplicationDbContext"/>.</param>
        public InMemoryGetApiKeyQuery(IApplicationDbContext dbContext)
        {
            var authorizedUser = dbContext.AuthorizedUsers
                .Include(i => i.Roles)
                .ThenInclude(i => i.Role)
                .AsNoTracking()
                .ToList();

            var apiKeys = authorizedUser.Select(i =>
                new ApiKey(((long)authorizedUser.IndexOf(i)) + 1,
                i.Email, i.HashedApiKey, i.CreatedOn.DateTime, i.Roles.Select(r => r.Role.Name).ToList()));

            _apiKeys = apiKeys.ToDictionary(x => x.Key, x => x);
        }

        /// <summary>
        /// The Execute.
        /// </summary>
        /// <param name="providedApiKey">The providedApiKey<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ApiKey}"/>.</returns>
        public Task<ApiKey> Execute(string providedApiKey)
        {
            var hashedApiKey = AuthorizedUser.GetHash(providedApiKey, AuthorizedUser.Key);
            _apiKeys.TryGetValue(hashedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}