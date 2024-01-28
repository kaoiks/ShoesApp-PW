using INF148151_148140.ShoesApp.MAUI.ViewModels;

namespace INF148151_148140.ShoesApp.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            string location = args.Current?.Location?.ToString();

            if (location is $"//{nameof(FootwearsPage)}")
            {
                var footwearsPage = (FootwearsPage)Shell.Current.CurrentPage;

                var viewModel = (FootwearCollectionViewModel)footwearsPage.BindingContext;
                viewModel.MaxPrice = 0;
                viewModel.MinPrice = 0;
                viewModel.SearchText = "";
                viewModel.ReloadProducers();
                viewModel.ReloadFootwears();
                if (viewModel.IsCurrentlyEditing()){ 
                    viewModel.CancelCommand.Execute(null);
                }

                base.OnNavigated(args);
                
            }
            if (location is $"//{nameof(ProducersPage)}")
            {
                var producersPage = (ProducersPage)Shell.Current.CurrentPage;

                var viewModel = (ProducerCollectionViewModel)producersPage.BindingContext;
                if (viewModel.IsCurrentlyEditing())
                {
                    viewModel.CancelCommand.Execute(null);
                }

                base.OnNavigated(args);

            }
        }

    }
}
