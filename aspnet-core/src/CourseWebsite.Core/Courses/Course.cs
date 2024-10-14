using Abp.Domain.Entities.Auditing;
using CourseWebsite.Relations;
using System.Collections.Generic;

namespace CourseWebsite.Courses
{
    public class Course : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<CourseSubject> CourseSubjects { get; set; }

        public Course()
        {
            CourseSubjects = new HashSet<CourseSubject>();
        }

    }
}
