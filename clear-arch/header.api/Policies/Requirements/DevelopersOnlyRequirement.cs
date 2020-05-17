namespace api.Features.Authorization
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Defines the <see cref="DevelopersOnlyRequirement" />.
    /// </summary>
    public class DevelopersOnlyRequirement : IAuthorizationRequirement
    {
    }
}