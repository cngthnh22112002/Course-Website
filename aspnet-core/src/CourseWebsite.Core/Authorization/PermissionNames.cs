namespace CourseWebsite.Authorization
{
    public static class PermissionNames
    {
        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Users = "Pages.Users";
        public const string Pages_Users_Activation = "Pages.Users.Activation";
        public const string Pages_Roles = "Pages.Roles";

        public static class Prefix
        {
            public const string Administration = "Pages.Administration";
        }

        public static class Page
        {
            public const string Menu = "Menu";
            public const string Subject = "Subject";
            public const string Course = "Course";
        }

        public static class Action
        {
            public const string View = "View";
            public const string Create = "Create";
            public const string Update = "Update";
            public const string Delete = "Delete";
            public const string Search = "Search";
        }
    }
}
