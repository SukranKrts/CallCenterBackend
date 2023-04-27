using CallCenterProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CallCenterProject.Data
{
    public class MainDb: DbContext
    {
        public MainDb(DbContextOptions<MainDb> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<RequestEntity> RequestEntities { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Interview>().ToTable("Interview");
            modelBuilder.Entity<Report>().ToTable("Report");
            modelBuilder.Entity<RequestEntity>().ToTable("RequestEntity");
            modelBuilder.Entity<Representative>().ToTable("Representative");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
