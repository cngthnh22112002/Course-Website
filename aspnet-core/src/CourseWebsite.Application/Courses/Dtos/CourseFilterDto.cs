using Abp.Application.Services.Dto;

namespace CourseWebsite.Courses.Dtos
{
    public class CourseFilterDto : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
