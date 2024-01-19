using INF148151_148140.ShoesApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148151_148140.ShoesApp.Intefaces
{
    public interface IFootwear
    {
        int Id { get; set; }
        string Sku { get; set; }
        string Name { get; set; }
        string Color { get; set; }
        decimal Price { get; set; }
        IProducer Producer { get; set; }
        FootwearType Type { get; set; }

    }
}
