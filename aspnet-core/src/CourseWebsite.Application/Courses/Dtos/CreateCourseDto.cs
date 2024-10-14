using Abp.AutoMapper;
using System.Collections.Generic;

namespace CourseWebsite.Courses.Dtos
{
    [AutoMapTo(typeof(Course))]
    public class CreateCourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<SubjectOrderDto> Subjects { get; set; }
    }

    public class SubjectOrderDto
    {
        public int SubjectId { get; set; }
        public int Order { get; set; }
    }
}
