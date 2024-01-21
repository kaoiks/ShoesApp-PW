using CommunityToolkit.Mvvm.ComponentModel;
using INF148151_148140.ShoesApp.Core;
using INF148151_148140.ShoesApp.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148151_148140.ShoesApp.MAUI.ViewModels
{
    public partial class FootwearViewModel: ObservableObject, IFootwear
    {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string sku;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string color;
        [ObservableProperty]
        private decimal price;
        [ObservableProperty]
        private IProducer producer;
        [ObservableProperty]
        private FootwearType type;

        public FootwearViewModel(IFootwear footwear)
        {
            Id = footwear.Id;
            Sku = footwear.Sku;
            Name = footwear.Name;
            Color = footwear.Color;
            Price = footwear.Price;
            Producer = footwear.Producer;
            Type = footwear.Type;
        }
    }
}
