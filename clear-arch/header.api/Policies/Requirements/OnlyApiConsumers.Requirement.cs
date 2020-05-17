namespace api.Features.Authorization
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Defines the <see cref="OnlyApiConsumersRequirement" />.
    /// </summary>
    public class OnlyApiConsumersRequirement : IAuthorizationRequirement
    {
    }
}