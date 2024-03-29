﻿using INF148151_148140.ShoesApp.Core;
using INF148151_148140.ShoesApp.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148151_148140.ShoesApp.DAOSQL1.BO
{
    public class Footwear: IFootwear
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int ProducerId { get; set; }
        public FootwearType Type { get; set; }

        public virtual Producer Producer { get; set; }

        IProducer IFootwear.Producer
        {
            get => Producer;
            set
            {
                if (value is Producer)
                {
                    Producer = (Producer)value;
                }

            }
        }

    }

}
