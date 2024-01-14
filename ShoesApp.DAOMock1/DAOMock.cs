using ShoesApp.Core;
using ShoesApp.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesApp.DAOMock1
{
    public class DAOMock : IDAO
    {
        private List<IProducer> producerList;
        private List<IFootwear> footwearList;

        public DAOMock()
        {
            producerList = new List<IProducer>()
            {
                new BO.Producer() { ID = 1, Name = "Nike", Country = "USA" },
                new BO.Producer() { ID = 2, Name = "Adidas", Country = "Germany" },
                new BO.Producer() { ID = 3, Name = "Puma", Country = "Germany" },
                new BO.Producer() { ID = 4, Name = "Reebok", Country = "USA" },
                new BO.Producer() { ID = 5, Name = "Asics", Country = "Japan" },
            };
            footwearList = new List<IFootwear>()
            {
                new BO.Footwear()
                {
                    ID = 1,
                    Sku = "DJ6188-101",
                    Name = "Dunk Low 'Reverse Panda'",
                    Color = "White/Black",
                    Price = 100,
                    Producer = producerList[0],
                    Type = FootwearType.Sneaker
                },
                new BO.Footwear()
                {
                    ID = 2,
                    Sku = "GY7386",
                    Name = "Bermuda 'Glow Pink'",
                    Color = "Pink",
                    Price = 120,
                    Producer = producerList[1],
                    Type = FootwearType.Sneaker
                },
                new BO.Footwear()
                {
                    ID = 3,
                    Sku = "FX4298",
                    Name = "Yeezy Boost 350 V2 'Linen'",
                    Color = "Beige",
                    Price = 220,
                    Producer = producerList[1],
                    Type = FootwearType.Sneaker
                },
                new BO.Footwear()
                {
                    ID = 4,
                    Sku = "1201A019-108",
                    Name = "Gel Kayano 14 'Silver Cream",
                    Color = "Silver",
                    Price = 150,
                    Producer = producerList[4],
                    Type = FootwearType.Running
                },
            };
        }

        public IFootwear AddFootwear()
        {
            return new BO.Footwear();
        }

        public IProducer AddProducer()
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
            throw new NotImplementedException();
        }

        public IProducer GetProducer(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveFootwear(IFootwear footwear)
        {
            throw new NotImplementedException();
        }

        public void RemoveProducer(IProducer producer)
        {
            throw new NotImplementedException();
        }

        public void UpdateFootwear(IFootwear footwear)
        {
            throw new NotImplementedException();
        }

        public void UpdateProducer(IProducer producer)
        {
            throw new NotImplementedException();
        }
    }
}
