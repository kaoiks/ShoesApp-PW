using INF148151_148140.ShoesApp.MAUI.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace INF148151_148140.ShoesApp.MAUI;

public partial class FootwearsPage : ContentPage
{

    public FootwearsPage(FootwearCollectionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == nameof(viewModel.Footwears))
            {
                var updatedFootwears = viewModel.Footwears;
                FootwearList.ItemsSource = updatedFootwears;
            }
        };

    }


    private void ListView_ItemTapped_1(object sender, ItemTappedEventArgs e)
    {
        var footwearViewModel = (e.Item as FootwearViewModel).Clone() as FootwearViewModel;
        footwearViewModel.Producer = (BindingContext as FootwearCollectionViewModel).AllProducers.FirstOrDefault(p => p.Id == footwearViewModel.Producer.Id);
        Debug.WriteLine(footwearViewModel.Producer.Name);
        (BindingContext as FootwearCollectionViewModel).ReloadProducers();
        (BindingContext as FootwearCollectionViewModel).EditFootwear(footwearViewModel);
        
    }

}