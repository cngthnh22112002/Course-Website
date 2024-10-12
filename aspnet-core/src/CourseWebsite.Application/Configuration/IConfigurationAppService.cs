using System.Threading.Tasks;
using CourseWebsite.Configuration.Dto;

namespace CourseWebsite.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
