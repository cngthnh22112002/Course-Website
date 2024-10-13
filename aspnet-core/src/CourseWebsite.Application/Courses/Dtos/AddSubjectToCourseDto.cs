namespace CourseWebsite.Courses.Dtos
{
    public class AddSubjectToCourseDto
    {
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public int Order { get; set; }
    }
}
