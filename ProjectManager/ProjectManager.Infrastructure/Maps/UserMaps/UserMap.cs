using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Aggregates.UserAggregate;

namespace ProjectManager.Infrastructure.Maps.UserMaps
{
    public class UserMap : EntityMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName).HasColumnName("FirstName").HasColumnType("varchar(64)").IsRequired();
            builder.Property(u => u.LastName).HasColumnName("LastName").HasColumnType("varchar(64)").IsRequired();

            //builder.OwnsOne(u => u.Name, n =>
            //{
            //    n.Ignore(p => p.ValidationResult);
            //    n.Property(p => p.FirstName).HasColumnName("FirstName").HasColumnType("varchar(64)").IsRequired();
            //    n.Property(p => p.Surname).HasColumnName("Surname").HasColumnType("varchar(256)");
            //    n.Property(p => p.LastName).HasColumnName("LastName").HasColumnType("varchar(64)").IsRequired();
            //});

            base.Configure(builder);
        }
    }
}
