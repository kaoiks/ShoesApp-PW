using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148151_148140.ShoesApp.MAUI.ViewModels
{
    public partial class FootwearCollectionViewModel: ObservableObject
    {
        [ObservableProperty]
        private List<FootwearViewModel> footwearCollection;

    }
}
