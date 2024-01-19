using CommunityToolkit.Mvvm.ComponentModel;
using INF148151_148140.ShoesApp.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesApp.MAUI.ViewModels
{
    public partial class ProducerViewModel: ObservableObject, IProducer
    {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string country;
    }
}
