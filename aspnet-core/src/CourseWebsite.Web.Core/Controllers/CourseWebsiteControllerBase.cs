using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CourseWebsite.Controllers
{
    public abstract class CourseWebsiteControllerBase: AbpController
    {
        protected CourseWebsiteControllerBase()
        {
            LocalizationSourceName = CourseWebsiteConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
