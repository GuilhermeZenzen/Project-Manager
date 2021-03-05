using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Aggregates.ProjectAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Infrastructure.Maps.ProjectMaps
{
    public class TicketChangeMap : AuditableEntityMap<TicketChange>
    {
        public override void Configure(EntityTypeBuilder<TicketChange> builder)
        {
            builder.ToTable("TicketChanges");

            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.PropertyName).HasColumnType("varchar(64)").IsRequired();
            builder.Property(tc => tc.OldValue).HasColumnType("varchar(64)").IsRequired();
            builder.Property(tc => tc.NewValue).HasColumnType("varchar(64)").IsRequired();
            builder.Property(tc => tc.AuthorName).HasColumnType("varchar(64)").IsRequired();

            builder.HasOne(tc => tc.Ticket).WithMany(t => t.Changes).HasForeignKey(tc => tc.TicketId).IsRequired();

            base.Configure(builder);
        }
    }
}
