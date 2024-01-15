using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INF148151_148140.ShoesApp.DAOSQL.BO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace INF148151_148140.ShoesApp.DAOSQL
{
    public class DataContext: DbContext
    {
        private IConfiguration _configuration;

        public virtual DbSet<Footwear> Footwears { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            //Console.WriteLine("Executing from: {0}", execPath);
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("Sqlite"));
        }
    }
}
