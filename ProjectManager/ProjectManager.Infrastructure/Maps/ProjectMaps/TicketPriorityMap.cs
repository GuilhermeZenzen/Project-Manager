using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Enums;
using ProjectManager.Domain.Aggregates.ProjectAggregate;
using ProjectManager.Infrastructure.Maps.Common;

namespace ProjectManager.Infrastructure.Maps.ProjectMaps
{
    public class TicketPriorityMap : EnumMap<TicketPriority, TicketPriorityEnum>
    {
        public override void Configure(EntityTypeBuilder<TicketPriority> builder)
        {
            builder.ToTable("TicketPriorities");

            builder.Property(tp => tp.Name).HasColumnType("varchar(8)").IsRequired();

            base.Configure(builder);
        }
    }
}
