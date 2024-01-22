using INF148151_148140.ShoesApp.MAUI.ViewModels;

namespace INF148151_148140.ShoesApp.MAUI;

public partial class FootwearsPage : ContentPage
{
	public FootwearsPage()
	{
		InitializeComponent();
	}


    public FootwearsPage(FootwearCollectionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }


    private void ListView_ItemTapped_1(object sender, ItemTappedEventArgs e)
    {
        var footwearViewModel = (e.Item as FootwearViewModel).Clone() as FootwearViewModel;
        (BindingContext as FootwearCollectionViewModel).EditFootwear(footwearViewModel);
    }
}