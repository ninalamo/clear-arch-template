namespace api.Features.Authorization
{
    /// <summary>
    /// Defines the <see cref="Policies" />.
    /// </summary>
    public static class Policies
    {
        /// <summary>
        /// Defines the OnlyEmployees.
        /// </summary>
        public const string OnlyEmployees = nameof(OnlyEmployees);

        /// <summary>
        /// Defines the OnlyAdmin.
        /// </summary>
        public const string OnlyAdmin = nameof(OnlyAdmin);

        /// <summary>
        /// Defines the OnlyApiConsumers.
        /// </summary>
        public const string OnlyApiConsumers = nameof(OnlyApiConsumers);

        /// <summary>
        /// Defines the OnlyRockstars.
        /// </summary>
        public const string OnlyRockstars = nameof(OnlyRockstars);
    }
}