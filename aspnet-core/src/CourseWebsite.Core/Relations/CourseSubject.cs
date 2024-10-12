using Abp.Domain.Entities.Auditing;
using CourseWebsite.Courses;
using CourseWebsite.Subjects;

namespace CourseWebsite.Relations
{
    public class CourseSubject : FullAuditedEntity<int>
    {
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public int Order { get; set; }

        public virtual Course Course { get; set; }
        public virtual Subject Subject { get; set; }

    }
}
