using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class GymProgramItemConfiguration : IEntityTypeConfiguration<GymProgramItem>
    {
        public void Configure(EntityTypeBuilder<GymProgramItem> builder)
        {
            builder.ToTable("GymProgramItems").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.GymProgramId).HasColumnName("GymProgramId");
            builder.Property(p => p.MoveId).HasColumnName("MoveId");
            builder.Property(p => p.RestTime).HasColumnName("RestTime");
            builder.Property(p => p.Sets).HasColumnName("Sets");
            builder.Property(p => p.Reps).HasColumnName("Reps");
        }
    }
}
