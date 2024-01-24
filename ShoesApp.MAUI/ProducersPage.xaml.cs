using INF148151_148140.ShoesApp.MAUI.ViewModels;

namespace INF148151_148140.ShoesApp.MAUI;

public partial class ProducersPage : ContentPage
{
	public ProducersPage(ProducerCollectionViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == nameof(viewModel.Producers))
            {
                // Refresh the ListView when the Producers property changes
                var updatedProducers = viewModel.Producers;
                ProducersList.ItemsSource = updatedProducers;
            }
        };

    }


    private void ListView_ItemTapped_1(object sender, ItemTappedEventArgs e)
    {
        var producerViewModel = (e.Item as ProducerViewModel).Clone() as ProducerViewModel;
        (BindingContext as ProducerCollectionViewModel).EditProducer(producerViewModel);
    }
}