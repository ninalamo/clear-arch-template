using domain.Users;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace api.Features.Authorization
{
    public class OnlyAdminAuthorizationHandler : AuthorizationHandler<OnlyAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyAdminRequirement requirement)
        {
            if (context.User.IsInRole(AuthorizedRole.Admin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}