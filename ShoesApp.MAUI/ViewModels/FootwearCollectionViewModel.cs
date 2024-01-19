using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesApp.MAUI.ViewModels
{
    public partial class FootwearCollectionViewModel: ObservableObject
    {
        [ObservableProperty]
        private List<FootwearViewModel> footwearCollection;

    }
}
