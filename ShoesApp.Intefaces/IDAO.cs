using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148151_148140.ShoesApp.Intefaces
{
    public interface IDAO
    {
        IFootwear CreateFootwear();
        IProducer CreateProducer();
        void AddFootwear(IFootwear footwear);
        void AddProducer(IProducer producer);
        void RemoveFootwear(int id);
        void RemoveProducer(int id);
        void UpdateFootwear(IFootwear footwear);
        void UpdateProducer(IProducer producer);
        IFootwear GetFootwear(int id);
        IProducer GetProducer(int id);
        IEnumerable<IFootwear> GetAllFootwear();
        IEnumerable<IProducer> GetAllProducers();
    }
}
