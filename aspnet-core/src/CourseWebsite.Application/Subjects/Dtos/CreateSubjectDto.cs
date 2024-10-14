using Abp.AutoMapper;

namespace CourseWebsite.Subjects.Dtos
{
    [AutoMapTo(typeof(Subject))]
    public class CreateSubjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
