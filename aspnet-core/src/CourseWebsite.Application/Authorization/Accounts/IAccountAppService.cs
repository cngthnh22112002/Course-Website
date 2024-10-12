using System.Threading.Tasks;
using Abp.Application.Services;
using CourseWebsite.Authorization.Accounts.Dto;

namespace CourseWebsite.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
