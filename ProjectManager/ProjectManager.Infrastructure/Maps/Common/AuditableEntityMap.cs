using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Infrastructure.Maps
{
    public class AuditableEntityMap<AET> : EntityMap<AET> where AET: AuditableEntity
    {
        public override void Configure(EntityTypeBuilder<AET> builder)
        {
            builder.Property(ae => ae.CreatedAt);
            builder.Property(ae => ae.UpdatedAt);

            base.Configure(builder);
        }
    }
}
