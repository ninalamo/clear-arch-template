namespace api.Features.Authorization
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Defines the <see cref="OnlyEmployeesRequirement" />.
    /// </summary>
    public class OnlyEmployeesRequirement : IAuthorizationRequirement
    {
    }
}