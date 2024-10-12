using Abp.Authorization;
using CourseWebsite.Authorization.Roles;
using CourseWebsite.Authorization.Users;

namespace CourseWebsite.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
