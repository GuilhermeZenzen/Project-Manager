using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Aggregates.UserAggregate;

namespace ProjectManager.Infrastructure.Maps.UserMaps
{
    public class UserAdministrationMap : EntityMap<UserAdministration>
    {
        public override void Configure(EntityTypeBuilder<UserAdministration> builder)
        {
            builder.ToTable("UserAdministrations");

            builder.HasKey(ua => ua.Id);

            builder.Property(ua => ua.Id);

            builder.HasOne(ua => ua.Administrator).WithMany(u => u.Personnel).HasForeignKey(ua => ua.AdministratorId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(ua => ua.Administered).WithMany(u => u.Administrators).HasForeignKey(ua => ua.AdministeredId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.HasOne(ua => ua.Role).WithMany().HasForeignKey(ua => ua.RoleId).OnDelete(DeleteBehavior.Cascade).IsRequired();

            base.Configure(builder);
        }
    }
}
