using INF148151_148140.ShoesApp.MAUI.ViewModels;

namespace INF148151_148140.ShoesApp.MAUI;

public partial class ProducersPage : ContentPage
{
	public ProducersPage(ProducerCollectionViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        ProducerViewModel artistViewModel = (e.Item as ProducerViewModel).Clone() as ProducerViewModel;
    }

}