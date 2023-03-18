using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student2.BL.Entities;

namespace LoginModel.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasIndex(u => u.NormalizedEmail)
                .IsUnique();

            builder.HasIndex(u => u.UniversityId);
        }
    }
}