using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesApp.Intefaces
{
    public interface IDAO
    {
        IFootwear AddFootwear();
        IProducer AddProducer();
        void RemoveFootwear(IFootwear footwear);
        void RemoveProducer(IProducer producer);
        void UpdateFootwear(IFootwear footwear);
        void UpdateProducer(IProducer producer);
        IFootwear GetFootwear(int id);
        IProducer GetProducer(int id);
        IEnumerable<IFootwear> GetAllFootwear();
        IEnumerable<IProducer> GetAllProducers();
    }
}
