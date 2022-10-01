using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// add-migration name
// update-database
namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        
        DbSet<Move> Moves { get; set; }



        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Move>(a =>
            {
                a.ToTable("Moves").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.MoveAreaId).HasColumnName("MoveAreaId");
                a.Property(p => p.MoveName).HasColumnName("MoveName");
                a.Property(p => p.Description).HasColumnName("Description");
            });
            

            Move[] moveEntitySeeds = { new(1, 1, "Chest Press", "blabla bla bla") };
            modelBuilder.Entity<Move>().HasData(moveEntitySeeds);   



        }
    }
}
