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
    public class InstructorCustomerConfiguration : IEntityTypeConfiguration<InstructorCustomer>
    {
        public void Configure(EntityTypeBuilder<InstructorCustomer> builder)
        {
            builder.ToTable("GIFs").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.UserId).HasColumnName("UserId");
            builder.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(p => p.BodyWeight).HasColumnName("BodyWeight");
            builder.Property(p => p.Height).HasColumnName("Height");
            builder.Property(p => p.BranchId).HasColumnName("BranchId");
            builder.Property(p => p.Education).HasColumnName("Education");
        }
    }
}
