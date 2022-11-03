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
    public class MoveConfiguration : IEntityTypeConfiguration<Move>
    {
        public void Configure(EntityTypeBuilder<Move> builder)
        {
            builder.ToTable("Moves").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.MoveAreaId).HasColumnName("MoveAreaId");
            builder.Property(p => p.MoveName).HasColumnName("MoveName");
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            builder.HasOne(p => p.MoveArea);
            builder.HasMany(p => p.Descriptions);


            


        }
    }
}
