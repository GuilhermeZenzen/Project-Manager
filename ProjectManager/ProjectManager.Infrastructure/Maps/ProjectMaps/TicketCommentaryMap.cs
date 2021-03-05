using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Aggregates.ProjectAggregate;

namespace ProjectManager.Infrastructure.Maps.ProjectMaps
{
    public class TicketCommentaryMap : AuditableEntityMap<TicketCommentary>
    {
        public override void Configure(EntityTypeBuilder<TicketCommentary> builder)
        {
            builder.ToTable("TicketCommentaries");

            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.AuthorName).HasColumnType("varchar(64)").IsRequired();
            builder.Property(tc => tc.Body).HasColumnType("varchar(512)").IsRequired();

            builder.HasOne(tc => tc.Ticket).WithMany(t => t.Commentaries).HasForeignKey(tc => tc.TicketId).IsRequired();

            base.Configure(builder);
        }
    }
}
