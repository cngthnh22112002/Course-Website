using Abp.Application.Services.Dto;

namespace CourseWebsite.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

