using INF148151_148140.ShoesApp.Core;
using INF148151_148140.ShoesApp.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148151_148140.ShoesApp.DAOMock1
{
    public class DAOMock : IDAO
    {
        private List<IProducer> producerList;
        private List<IFootwear> footwearList;

        public DAOMock()
        {
            producerList = new List<IProducer>()
            {
                new BO.Producer() { Id = 1, Name = "Nike", Country = "USA" },
                new BO.Producer() { Id = 2, Name = "Adidas", Country = "Germany" },
                new BO.Producer() { Id = 3, Name = "Puma", Country = "Germany" },
                new BO.Producer() { Id = 4, Name = "Reebok", Country = "USA" },
                new BO.Producer() { Id = 5, Name = "Asics", Country = "Japan" },
            };
            footwearList = new List<IFootwear>()
            {
                new BO.Footwear()
                {
                    Id = 1,
                    Sku = "DJ6188-101",
                    Name = "Dunk Low 'Reverse Panda'",
                    Color = "White/Black",
                    Price = 100,
                    Producer = producerList[0],
                    Type = FootwearType.Sneaker
                },
                new BO.Footwear()
                {
                    Id = 2,
                    Sku = "GY7386",
                    Name = "Bermuda 'Glow Pink'",
                    Color = "Pink",
                    Price = 120,
                    Producer = producerList[1],
                    Type = FootwearType.Sneaker
                },
                new BO.Footwear()
                {
                    Id = 3,
                    Sku = "FX4298",
                    Name = "Yeezy Boost 350 V2 'Linen'",
                    Color = "Beige",
                    Price = 220,
                    Producer = producerList[1],
                    Type = FootwearType.Sneaker
                },
                new BO.Footwear()
                {
                    Id = 4,
                    Sku = "1201A019-108",
                    Name = "Gel Kayano 14 'Silver Cream",
                    Color = "Silver",
                    Price = 150,
                    Producer = producerList[4],
                    Type = FootwearType.Running
                },
            };
        }

        public void AddFootwear(IFootwear footwear)
        {
            var footwear_element = new BO.Footwear()
            {
                Id = footwearList.Max(f => f.Id) + 1,
                Sku = footwear.Sku,
                Name = footwear.Name,
                Color = footwear.Color,
                Price = footwear.Price,
                Producer = footwear.Producer,
                Type = footwear.Type
            };
            footwearList.Add(footwear_element);
        }

        public void AddProducer(IProducer producer)
        {
            var producer_element = new BO.Producer()
            {
                Id = producerList.Max(p => p.Id) + 1,
                Name = producer.Name,
                Country = producer.Country
            };
            producerList.Add(producer_element);
        }

        public IFootwear CreateFootwear()
        {
            return new BO.Footwear();
        }

        public IProducer CreateProducer()
        {
            return new BO.Producer();
        }

        public IEnumerable<IFootwear> GetAllFootwear()
        {
            return footwearList;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return producerList;
        }

        public IFootwear GetFootwear(int id)
        {
            return footwearList.FirstOrDefault(f => f.Id == id);
        }

        public IProducer GetProducer(int id)
        {
            return producerList.FirstOrDefault(p => p.Id == id);
        }

        public void RemoveFootwear(int id)
        {
            footwearList.Remove(footwearList.FirstOrDefault(f => f.Id == id));
        }

        public void RemoveProducer(int id)
        {
            footwearList.RemoveAll(f => f.Producer.Id == id);
            producerList.Remove(producerList.FirstOrDefault(p => p.Id == id));

        }

        public void UpdateFootwear(IFootwear footwear)
        {
            footwearList.Remove(footwearList.FirstOrDefault(f => f.Id == footwear.Id));
            footwearList.Add(footwear);
        }

        public void UpdateProducer(IProducer producer)
        {
            producerList.Remove(producerList.FirstOrDefault(p => p.Id == producer.Id));
            producerList.Add(producer);
        }
    }
}
