using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CourseWebsite.Authorization.Roles;
using CourseWebsite.Authorization.Users;
using CourseWebsite.MultiTenancy;

namespace CourseWebsite.EntityFrameworkCore
{
    public class CourseWebsiteDbContext : AbpZeroDbContext<Tenant, Role, User, CourseWebsiteDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CourseWebsiteDbContext(DbContextOptions<CourseWebsiteDbContext> options)
            : base(options)
        {
        }
    }
}
