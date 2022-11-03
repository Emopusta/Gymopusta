using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class MoveAreaConfiguration : IEntityTypeConfiguration<MoveArea>
    {
        public void Configure(EntityTypeBuilder<MoveArea> builder)
        {
            builder.ToTable("MoveAreas").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.MoveAreaName).HasColumnName("MoveAreaName");
            builder.HasMany(p => p.Moves);


            MoveArea[] moveAreaEntitySeeds = { new(1, "Chest") };
            builder.HasData(moveAreaEntitySeeds);
        }
    }
}
