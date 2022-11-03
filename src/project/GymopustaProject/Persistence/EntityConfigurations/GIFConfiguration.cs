using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class GIFConfiguration : IEntityTypeConfiguration<GIF>
    {
        public void Configure(EntityTypeBuilder<GIF> builder)
        {
            builder.ToTable("GIFs").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.MoveId).HasColumnName("MoveId");
            builder.Property(p => p.GIFPath).HasColumnName("GIFPath");
            builder.HasOne(p => p.Move);
        }
    }
    
}
