using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Data.Entities.Bases;
using SchoolManagement.Data.Entities.Identiy;

namespace SchoolManagement.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public ApplicationDbContext()
        {

        }
        public DbSet<UserRefreshToken> userRefreshTokens { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Attendence> Attendence { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.Entity is ICreatedBase createdEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        createdEntity.CreatedAt = DateTime.Now;
                    }
                }

                if (entry.Entity is IUpdatedBase updateEntity)
                {
                    if (entry.State == EntityState.Modified)
                    {
                        updateEntity.UpdatedAt = DateTime.Now;
                    }

                    if (entry.Entity is ICreatedBase createdBase)
                    {
                        entry.Property(nameof(createdBase.CreatedAt)).IsModified = false;
                    }
                }




            }

            return await base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StudentClass>().HasKey(x => new { x.ClassId, x.StudentId });
       
            base.OnModelCreating(modelBuilder);
        }
    }

}

