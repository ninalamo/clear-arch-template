using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace api.Features.Authorization
{
    public class DevelopersOnlyAuthorizationHandler : AuthorizationHandler<DevelopersOnlyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DevelopersOnlyRequirement requirement)
        {
            if (context.User.IsInRole(AuthorizedRole.Rockstar))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}