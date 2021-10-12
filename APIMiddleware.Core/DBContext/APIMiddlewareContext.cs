using APIMiddleware.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIMiddleware.Core.DBContext
{
    public class APIMiddlewareContext : DbContext
    {
        //public APIMiddlewareContext(DbContextOptions<APIMiddlewareContext> options) : base(options)
        //{ }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SystemPreference> SystemPreferences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Production ----------------
             // const string conn = "Server=10.201.201.130;Database=ERPMW;User Id=ERPMW;password=U$r4mwerp;Trusted_Connection=False;MultipleActiveResultSets=true;"; //PRODUCTION
           // Development -----------------
            const string conn = "Server=10.201.203.131;Database=ERPMW;User Id=ERPMW;password=pass4erpmw;Trusted_Connection=False;MultipleActiveResultSets=true;";
            ///Testing-----------------------
             //const string conn = "Server=(localdb)\\mssqllocaldb;Database=APIMiddlewareDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(conn);
        }
    }
}
