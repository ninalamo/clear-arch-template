namespace api.Features.Authentication
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ApiKey" />.
    /// </summary>
    public class ApiKey
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKey"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <param name="owner">The owner<see cref="string"/>.</param>
        /// <param name="key">The key<see cref="string"/>.</param>
        /// <param name="created">The created<see cref="DateTime"/>.</param>
        /// <param name="roles">The roles<see cref="IReadOnlyCollection{string}"/>.</param>
        public ApiKey(long id, string owner, string key, DateTime created, IReadOnlyCollection<string> roles)
        {
            Id = id;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Created = created;
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
        }

        /// <summary>
        /// Gets the Id.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the Owner.
        /// </summary>
        public string Owner { get; }

        /// <summary>
        /// Gets the Key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the Created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// Gets the Roles.
        /// </summary>
        public IReadOnlyCollection<string> Roles { get; }
    }
}