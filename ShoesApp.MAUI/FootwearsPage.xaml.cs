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
    }


    private void ListView_ItemTapped_1(object sender, ItemTappedEventArgs e)
    {
        var footwearViewModel = (e.Item as FootwearViewModel).Clone() as FootwearViewModel;
        footwearViewModel.Producer = (BindingContext as FootwearCollectionViewModel).AllProducers.FirstOrDefault(p => p.Id == footwearViewModel.Producer.Id);
        Debug.WriteLine(footwearViewModel.Producer.Name);
        (BindingContext as FootwearCollectionViewModel).ReloadProducers();
        (BindingContext as FootwearCollectionViewModel).EditFootwear(footwearViewModel);
        
    }

    private void FilterCriteriaPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedFilter = (string)FilterCriteriaPicker.SelectedItem;
        // You can store or use the selected filter criteria as needed.
    }

}