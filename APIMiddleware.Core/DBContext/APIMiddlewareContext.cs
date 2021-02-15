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
            /// Server=(localdb)\\mssqllocaldb;Database=APIMiddlewareWebContext;Trusted_Connection=True;MultipleActiveResultSets=true
            const string conn = "Server=10.201.203.131;Database=ERPMW;User Id=ERPMW;password=pass4erpmw;Trusted_Connection=False;MultipleActiveResultSets=true;";
            //const string conn = "Server=(localdb)\\mssqllocaldb;Database=APIMiddlewareDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(conn);
        }
    }
}
