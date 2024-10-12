using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CourseWebsite.Configuration.Dto;

namespace CourseWebsite.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CourseWebsiteAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
