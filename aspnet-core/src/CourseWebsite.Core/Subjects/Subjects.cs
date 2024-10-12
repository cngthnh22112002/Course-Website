using Abp.Domain.Entities.Auditing;
using CourseWebsite.Relations;
using System.Collections.Generic;

namespace CourseWebsite.Subjects
{
    public class Subject : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CourseSubject> CourseSubjects { get; set; }

        public Subject()
        {
            CourseSubjects = new HashSet<CourseSubject>();
        }

    }
}
