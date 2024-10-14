using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CourseWebsite.Subjects.Dtos
{
    [AutoMapFrom(typeof(Subject))]
    [AutoMapTo(typeof(Subject))]
    public class SubjectDto : FullAuditedEntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
