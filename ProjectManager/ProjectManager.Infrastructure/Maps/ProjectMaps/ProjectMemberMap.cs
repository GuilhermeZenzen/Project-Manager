using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Aggregates.ProjectAggregate;

namespace ProjectManager.Infrastructure.Maps.ProjectMaps
{
    public class ProjectMemberMap : EntityMap<ProjectMember>
    {
        public override void Configure(EntityTypeBuilder<ProjectMember> builder)
        {
            builder.ToTable("ProjectMembers");

            builder.HasKey(pm => pm.Id);
            builder.Property(pm => pm.Id).ValueGeneratedNever();

            builder.HasOne(pm => pm.Project).WithMany(p => p.Members).HasForeignKey(pm => pm.ProjectId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(pm => pm.Member).WithMany().HasForeignKey(pm => pm.MemberId).IsRequired();

            base.Configure(builder);
        }
    }
}
