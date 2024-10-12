using Abp.Application.Services;
using CourseWebsite.MultiTenancy.Dto;

namespace CourseWebsite.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

