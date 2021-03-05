using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Application.Identity;

namespace ProjectManager.Infrastructure.Maps.UserMaps
{
    public class UserIdentityMap : IEntityTypeConfiguration<UserIdentity>
    {
        public void Configure(EntityTypeBuilder<UserIdentity> builder)
        {
            builder.HasOne(ui => ui.User).WithOne().HasForeignKey((UserIdentity ui) => ui.UserId).IsRequired();
        }
    }
}
