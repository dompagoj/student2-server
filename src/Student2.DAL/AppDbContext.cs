using LoginModel.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student2.BL.Entities;

namespace LoginModel
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<University> University { get; set; } = null!;
        public DbSet<Post> Post { get; set; } = null!;
        public DbSet<Course> Course { get; set; } = null!;
        public DbSet<Tutor> Tutor { get; set; } = null!;
        public DbSet<Comment> Comment { get; set; } = null!;

        public AppDbContext() { }
        public AppDbContext(DbContextOptions opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseSnakeCase();
            modelBuilder.ApplyConfiguration(new AppRolesConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}
