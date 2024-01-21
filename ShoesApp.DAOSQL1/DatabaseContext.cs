using INF148151_148140.ShoesApp.DAOSQL1.BO;
using INF148151_148140.ShoesApp.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148151_148140.ShoesApp.DAOSQL1
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Footwear> Footwear { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Debug.WriteLine(System.Reflection.Assembly.GetEntryAssembly().Location);
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producer>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Footwear>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Footwear>()
                .Property(f => f.Price)
                .HasColumnType("decimal(18, 2)");


        }
    }
}
