using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Aggregates.ProjectAggregate;

namespace ProjectManager.Infrastructure.Maps.ProjectMaps
{
    public class TicketMap : AuditableEntityMap<Ticket>
    {
        public override void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).HasColumnType("varchar(64)").IsRequired();
            builder.Property(t => t.Description).HasColumnType("varchar(512)").IsRequired();
            builder.Property(t => t.PriorityId);

            builder.HasOne(t => t.Submitter).WithMany().HasForeignKey(t => t.SubmitterId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ProjectTicketCategory).WithMany(ptc => ptc.Tickets).HasForeignKey(t => t.ProjectTicketCategoryId).IsRequired();
            builder.HasOne(t => t.Project).WithMany(p => p.Tickets).HasForeignKey(t => t.ProjectId).IsRequired();

            base.Configure(builder);
        }
    }
}
