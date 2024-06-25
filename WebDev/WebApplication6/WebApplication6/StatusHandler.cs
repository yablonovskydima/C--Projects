using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication6
{
    public class StatusHandler : AuthorizationHandler<StatusRequirment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, StatusRequirment requirement)
        {
            var statusClaim = context.User.FindFirst(c => c.Type == "Status");
            if (statusClaim != null)
            {
                if (statusClaim.Value == "VIP" || statusClaim.Value == "admin")
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
