using INF148151_148140.ShoesApp.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148151_148140.ShoesApp.DAOSQL.BO
{
    public class Producer: IProducer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Footwear> Footwears { get; set; } = new List<Footwear>();
    }
}
