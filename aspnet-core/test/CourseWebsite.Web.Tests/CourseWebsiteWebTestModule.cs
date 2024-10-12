using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CourseWebsite.EntityFrameworkCore;
using CourseWebsite.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CourseWebsite.Web.Tests
{
    [DependsOn(
        typeof(CourseWebsiteWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class CourseWebsiteWebTestModule : AbpModule
    {
        public CourseWebsiteWebTestModule(CourseWebsiteEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CourseWebsiteWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(CourseWebsiteWebMvcModule).Assembly);
        }
    }
}