using Abp.Application.Services.Dto;

namespace CourseWebsite.Subjects.Dtos
{
    public class SubjectFilterDto : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
