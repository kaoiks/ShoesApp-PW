using INF148151_148140.ShoesApp.Intefaces;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using INF148151_148140.ShoesApp.DAOSQL.BO;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Diagnostics;


namespace INF148151_148140.ShoesApp.DAOSQL
{
    public class DAOSQL : IDAO, IDesignTimeDbContextFactory<DataContext>
    {
        private DataContext context;

        public DAOSQL()
        {
            context = CreateDbContext(new string[] { });
            context.Database.OpenConnection();
        }

        ~DAOSQL()
        {
            context.Database.CloseConnection();
        }

        public DataContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();

            return new DataContext(configuration);
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
            context.Add(ConvertFootwearInteraceToDAO(footwear));
            context.SaveChanges();
        }

        public void AddProducer(IProducer producer)
        {
            context.Add(ConvertProducerInterfaceToDAO(producer));
            context.SaveChanges();
        }

        public IEnumerable<IFootwear> GetAllFootwear()
        {
            return context.Footwears.Include(f => f.Producer);
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return context.Producers;
        }

        public IFootwear GetFootwear(int id)
        {
            return context.Footwears.Include(f => f.Producer).FirstOrDefault(f => f.Id == id)!;
        }

        public IProducer GetProducer(int id)
        {
            return context.Producers.FirstOrDefault(p => p.Id == id)!;
        }

        public void RemoveFootwear(int id)
        {
            context.Remove(GetFootwear(id));
            context.SaveChanges();
        }

        public void RemoveProducer(int idr)
        {
            context.Remove(GetProducer(idr));
            context.SaveChanges();
        }

        public void UpdateFootwear(IFootwear footwear)
        {
            context.Update(footwear);
            context.SaveChanges();
        }

        public void UpdateProducer(IProducer producer)
        {
            context.Update(producer);
            context.SaveChanges();
        }

        public Footwear ConvertFootwearInteraceToDAO(IFootwear footwear)
        {
            return new Footwear()
            {
                Id = footwear.Id,
                Sku = footwear.Sku,
                Name = footwear.Name,
                Color = footwear.Color,
                Price = footwear.Price,
                Producer = ConvertProducerInterfaceToDAO(footwear.Producer),
                Type = footwear.Type
            };
        }

        public Producer ConvertProducerInterfaceToDAO(IProducer producer)
        {
            return new Producer()
            {
                Id = producer.Id,
                Name = producer.Name,
                Country = producer.Country
            };
        }
    }
}
