using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Infrastructure.Maps
{
    public abstract class EntityMap<ET> : IEntityTypeConfiguration<ET> where ET: Entity
    {
        public virtual void Configure(EntityTypeBuilder<ET> builder)
        {
            builder.Ignore(e => e.ValidationResult);
        }
    }
}
