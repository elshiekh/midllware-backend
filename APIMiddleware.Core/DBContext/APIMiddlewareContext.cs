using APIMiddleware.Core.DBContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIMiddleware.Core.DBContext
{
    public class APIMiddlewareContext : DbContext
    {
        //public APIMiddlewareContext(DbContextOptions<APIMiddlewareContext> options) : base(options)
        //{ }

        public DbSet<Request> Requests { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SystemPreference> SystemPreferences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string conn = "Server=CS-LPTP-51A\\SQLEXPRESS; Database=APIMiddlewareDB; Trusted_Connection=True; MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(conn);
        }
    }
}
