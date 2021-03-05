using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Aggregates.TicketCategoryAggregate;

namespace ProjectManager.Infrastructure.Maps.TicketCategoryMaps
{
    public class TicketCategoryMap : EntityMap<TicketCategory>
    {
        public override void Configure(EntityTypeBuilder<TicketCategory> builder)
        {
            builder.ToTable("TicketCategories");

            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.Name).HasColumnType("varchar(64)").IsRequired();
            builder.Property(tc => tc.Description).HasColumnType("varchar(512)");

            base.Configure(builder);
        }
    }
}
