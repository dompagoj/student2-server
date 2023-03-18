using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student2.BL.Entities;

namespace LoginModel.Configuration
{
    public class AppRolesConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole
                {
                    Id = 1,
                    Name = AppRole.ADMIN,
                    NormalizedName = AppRole.ADMIN.ToUpper()
                }, new AppRole
                {
                    Id = 2,
                    Name = AppRole.EDITOR,
                    NormalizedName = AppRole.EDITOR.ToUpper()
                }, new AppRole
                {
                    Id = 3,
                    Name = AppRole.REGULAR,
                    NormalizedName = AppRole.REGULAR.ToUpper()
                });
        }
    }
}