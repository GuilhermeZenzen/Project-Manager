using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Aggregates.ProjectAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Infrastructure.Maps.ProjectMaps
{
    public class ProjectMap : EntityMap<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasColumnType("varchar(64)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("varchar(512)");

            builder.HasOne(p => p.Creator).WithMany().HasForeignKey(p => p.CreatorId);

            base.Configure(builder);
        }
    }
}
