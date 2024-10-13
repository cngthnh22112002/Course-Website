using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CourseWebsite.Subjects.Dtos;
using System.Collections.Generic;

namespace CourseWebsite.Courses.Dtos
{
    [AutoMapFrom(typeof(Course))]
    [AutoMapTo(typeof(Course))]
    public class CourseDto : FullAuditedEntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<SubjectDto> Subjects { get; set; }
    }
}
