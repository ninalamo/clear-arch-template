using domain.Users;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace api.Features.Authorization
{
    public class OnlyAPIConsumersAuthorizationHandler : AuthorizationHandler<OnlyApiConsumersRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyApiConsumersRequirement requirement)
        {
            if (context.User.IsInRole(AuthorizedRole.Application))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}