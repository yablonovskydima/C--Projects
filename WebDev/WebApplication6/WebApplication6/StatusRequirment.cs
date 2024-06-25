using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication6
{
    public class StatusRequirment : IAuthorizationRequirement
    {
        protected internal string Status { get; set; }
        public StatusRequirment(string status) => Status = status;
    }
}
