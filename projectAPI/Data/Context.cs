using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projectAPI.Models;
using System.Reflection.Emit;

namespace projectAPI.Data
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public Context(DbContextOptions<Context> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudentSubject>()
            .HasIndex(ss => new { ss.StudentId, ss.SubjectId }).IsUnique();


            SeedRole(builder);
        }
        private static void SeedRole(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "SuperAdmin", ConcurrencyStamp = "1", NormalizedName = "SuperAdmin" },
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "2", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "3", NormalizedName = "User" }
                );
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<StudentSubject> StudentSubject { get; set; }


    }
}
