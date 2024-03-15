using Microsoft.AspNetCore.Authorization;

namespace SimpleApiTemplate.Utils;

public class DynamicRoleAuthorizeAttribute : AuthorizeAttribute
{
    public DynamicRoleAuthorizeAttribute(Func<string> getRole)
    {
        Roles = getRole.Invoke();
    }
}