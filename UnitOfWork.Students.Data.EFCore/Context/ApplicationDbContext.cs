using Microsoft.EntityFrameworkCore;
using UnitOfWork.Students.Domain.Entities;

namespace UnitOfWork.Students.Data.EFCore.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(b => b.FirstName)
                .IsRequired()
                .HasMaxLength(50);
        }

        public DbSet<Student> Students { get; set; }

    }
}
