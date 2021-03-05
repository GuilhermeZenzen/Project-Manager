using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Aggregates.ProjectAggregate;

namespace ProjectManager.Infrastructure.Maps.ProjectMaps
{
    public class ProjectTicketCategoryMap : EntityMap<ProjectTicketCategory>
    {
        public override void Configure(EntityTypeBuilder<ProjectTicketCategory> builder)
        {
            builder.ToTable("ProjectTicketCategories");

            builder.HasKey(ptc => ptc.Id);

            builder.HasOne(ptc => ptc.Project).WithMany(p => p.TicketCategories).HasForeignKey(ptc => ptc.ProjectId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(ptc => ptc.TicketCategory).WithMany().HasForeignKey(ptc => ptc.TicketCategoryId).IsRequired();

            base.Configure(builder);
        }
    }
}
