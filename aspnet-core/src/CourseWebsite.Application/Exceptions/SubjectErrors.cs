using CourseWebsite.Commons;

namespace CourseWebsite.Exceptions
{
    public static class SubjectErrors
    {
        public static Error GetFailure = new("Subject.GetFailure", "Can't get subject.");
        public static Error InsertFailure = new("Subject.InsertFailure", "Can't create subject.");
        public static Error UpdateFailure = new("Subject.UpdateFailure", "Can't update subject.");
        public static Error DeleteFailure = new("Subject.DeleteFailure", "Can't delete subject.");
        public static Error NotExist(int id) => new("Subject.NotExist", "This subject does not exist.", new { id });
        public static Error EntityNotFound(int id) => new("Subject.EntityNotFound", "Entity not found.", new { id });
    }
}
