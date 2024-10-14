using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CourseWebsite.Authorization.Roles;
using CourseWebsite.Authorization.Users;
using CourseWebsite.MultiTenancy;
using CourseWebsite.Courses;
using CourseWebsite.Relations;
using CourseWebsite.Subjects;

namespace CourseWebsite.EntityFrameworkCore
{
    public class CourseWebsiteDbContext : AbpZeroDbContext<Tenant, Role, User, CourseWebsiteDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }

        public CourseWebsiteDbContext(DbContextOptions<CourseWebsiteDbContext> options)
            : base(options)
        {
        }
    }
}
