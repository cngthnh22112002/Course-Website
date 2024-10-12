using System.Threading.Tasks;
using Abp.Application.Services;
using CourseWebsite.Sessions.Dto;

namespace CourseWebsite.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
