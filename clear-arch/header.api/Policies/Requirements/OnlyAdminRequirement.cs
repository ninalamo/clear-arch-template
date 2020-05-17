namespace api.Features.Authorization
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Defines the <see cref="OnlyAdminRequirement" />.
    /// </summary>
    public class OnlyAdminRequirement : IAuthorizationRequirement
    {
    }
}