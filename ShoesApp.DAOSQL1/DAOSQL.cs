using INF148151_148140.ShoesApp.DAOSQL1.BO;
using INF148151_148140.ShoesApp.Intefaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection;

namespace INF148151_148140.ShoesApp.DAOSQL1
{
    public class DAOSQL : IDAO
    {
        private readonly DatabaseContext _context;

        public DAOSQL()
        {
            _context = CreateDbContext(new string[] { });
            _context.Database.OpenConnection();
        }

        ~DAOSQL()
        {
            _context.Database.CloseConnection();
        }

        public DatabaseContext CreateDbContext(string[] args)
        {
            string currentDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder().SetBasePath(currentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            //optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
            Debug.WriteLine("Data Source=" + currentDirectory + "\\database.db");
            optionsBuilder.UseSqlite("Data Source="+ currentDirectory + "\\database.db");
            return new DatabaseContext(optionsBuilder.Options);
        }

        public IFootwear CreateFootwear()
        {
            return new Footwear();
        }

        public IProducer CreateProducer()
        {
            return new Producer();
        }

        public void AddFootwear(IFootwear footwear)
        {
            if (footwear == null)
            {
                throw new ArgumentNullException(nameof(footwear));
            }

            _context.Add(footwear);
            _context.SaveChanges();
        }

        public void AddProducer(IProducer producer)
        {
            if (producer == null)
            {
                throw new ArgumentNullException(nameof(producer));
            }

            _context.Add(producer);
            _context.SaveChanges();
        }

        public void RemoveFootwear(int id)
        {
            var footwearToRemove = _context.Footwear.FirstOrDefault(f => f.Id == id);
            if (footwearToRemove != null)
            {
                _context.Footwear.Remove(footwearToRemove);
                _context.SaveChanges();
            }
        }

        public void RemoveProducer(int id)
        {
            var producerToRemove = _context.Producers.FirstOrDefault(p => p.Id == id);
            if (producerToRemove != null)
            {
                _context.Producers.Remove(producerToRemove);
                _context.SaveChanges();
            }
        }

        public void UpdateFootwear(IFootwear footwear)
        {
            if (footwear == null)
            {
                throw new ArgumentNullException(nameof(footwear));
            }

            _context.Entry(footwear).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateProducer(IProducer producer)
        {
            if (producer == null)
            {
                throw new ArgumentNullException(nameof(producer));
            }

            _context.Entry(producer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IFootwear GetFootwear(int id)
        {
            return _context.Footwear.FirstOrDefault(f => f.Id == id);
        }

        public IProducer GetProducer(int id)
        {
            return _context.Producers.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<IFootwear> GetAllFootwear()
        {
            return _context.Footwear.ToList();
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return _context.Producers.ToList();
        }

    }
}
