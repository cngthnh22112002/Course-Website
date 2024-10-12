using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CourseWebsite.EntityFrameworkCore
{
    public static class CourseWebsiteDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CourseWebsiteDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CourseWebsiteDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
