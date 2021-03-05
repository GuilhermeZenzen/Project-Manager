using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Enums;
using ProjectManager.Domain.Aggregates.UserAggregate;
using ProjectManager.Infrastructure.Maps.Common;

namespace ProjectManager.Infrastructure.Maps.RoleMaps
{
    public class RoleMap : EnumMap<Role, RoleEnum>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.Property(r => r.Name).HasColumnType("varchar(16)").IsRequired();

            base.Configure(builder);
        }
    }
}
