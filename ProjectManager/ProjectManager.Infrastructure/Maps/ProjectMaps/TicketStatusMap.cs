using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Enums;
using ProjectManager.Domain.Aggregates.ProjectAggregate;
using ProjectManager.Infrastructure.Maps.Common;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Infrastructure.Maps.ProjectMaps
{
    public class TicketStatusMap : EnumMap<TicketStatus, TicketStatusEnum>
    {
        public override void Configure(EntityTypeBuilder<TicketStatus> builder)
        {
            builder.ToTable("TicketStatuses");

            builder.Property(ts => ts.Name).HasColumnType("varchar(16)").IsRequired();

            base.Configure(builder);
        }
    }
}
