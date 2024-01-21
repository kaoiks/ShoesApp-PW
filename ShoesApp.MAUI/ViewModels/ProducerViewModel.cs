using CommunityToolkit.Mvvm.ComponentModel;
using INF148151_148140.ShoesApp.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148151_148140.ShoesApp.MAUI.ViewModels
{
    public partial class ProducerViewModel: ObservableObject, IProducer, ICloneable
    {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string country;

        public ProducerViewModel(IProducer producer)
        {
            Id = producer.Id;
            Name = producer.Name;
            Country = producer.Country;
        }
        public object Clone()
        {
            return new ProducerViewModel(this);
        }
    }
}
