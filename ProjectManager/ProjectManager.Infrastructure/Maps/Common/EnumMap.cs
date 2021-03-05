using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Infrastructure.Maps.Common
{
    public abstract class EnumMap<ET, ENUM> : IEntityTypeConfiguration<ET> where ET: EnumEntity<ENUM>, new() where ENUM: Enum
    {
        public virtual void Configure(EntityTypeBuilder<ET> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasData(Enum.GetValues(typeof(ENUM)).OfType<ENUM>().Select(en =>
            {
                ET entity = new ET();
                entity.Set(en, en.ToString());

                return entity;
            }));
        }
    }
}
