using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CourseWebsite.Configuration;

namespace CourseWebsite.Web.Host.Startup
{
    [DependsOn(
       typeof(CourseWebsiteWebCoreModule))]
    public class CourseWebsiteWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CourseWebsiteWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CourseWebsiteWebHostModule).GetAssembly());
        }
    }
}
