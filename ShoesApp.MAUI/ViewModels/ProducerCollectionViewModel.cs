using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using INF148151_148140.ShoesApp.Intefaces;
using System.Diagnostics;
using INF148151_148140.ShoesApp.BLC;

namespace INF148151_148140.ShoesApp.MAUI.ViewModels
{

    public partial class ProducerCollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ProducerViewModel> producers;

        private BLController _blc;

        [ObservableProperty]
        private ProducerViewModel editedProducer;

        [ObservableProperty]
        private bool editingExisting = false;

        public ProducerCollectionViewModel(BLController blc)
        {
            _blc = blc;
            Debug.WriteLine("LOADED BLC to ViewModel");
            Producers = new ObservableCollection<ProducerViewModel>();
            foreach(IProducer producer in _blc.GetAllProducers())
            {
                Debug.WriteLine(producer.Name.ToString());
                Producers.Add(new ProducerViewModel(producer));
            }

        }

    }
}
