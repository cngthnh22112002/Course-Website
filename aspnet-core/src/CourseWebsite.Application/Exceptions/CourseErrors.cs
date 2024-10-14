using CourseWebsite.Commons;

namespace CourseWebsite.Exceptions
{
    public static class CourseErrors
    {
        public static Error GetFailure = new("Course.GetFailure", "Can't get course.");
        public static Error InsertFailure = new("Course.InsertFailure", "Can't create course.");
        public static Error UpdateFailure = new("Course.UpdateFailure", "Can't update course.");
        public static Error DeleteFailure = new("Course.DeleteFailure", "Can't delete course.");
        public static Error NotExist(int id) => new("Course.NotExist", "This course does not exist.", new { id });
        public static Error EntityNotFound(int id) => new("Course.EntityNotFound", "Entity not found.", new { id });
        public static Error SubjectNotInCourse(int courseId, int subjectId) => new("Course.SubjectNotInCourse", $"Subject with ID {subjectId} is not in Course with ID {courseId}.", new { courseId, subjectId });
    }
}