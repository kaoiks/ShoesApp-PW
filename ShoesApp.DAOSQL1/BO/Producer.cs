using INF148151_148140.ShoesApp.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148151_148140.ShoesApp.DAOSQL1.BO
{
    public class Producer: IProducer
    {
        public int Id { get; set; }

        [DisplayName("Producer Name")]
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
