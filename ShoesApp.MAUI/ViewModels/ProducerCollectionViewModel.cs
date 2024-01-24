using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using INF148151_148140.ShoesApp.Intefaces;
using System.Diagnostics;
using INF148151_148140.ShoesApp.BLC;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Globalization;


namespace INF148151_148140.ShoesApp.MAUI.ViewModels
{

    public partial class ProducerCollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ProducerViewModel> producers;

        private BLController _blc;

        private ProducerViewModel producerEdit;

        public ProducerViewModel ProducerEdit
        {
            get { return producerEdit; }
            set { SetProperty(ref producerEdit, value); }
        }

        [ObservableProperty]
        private bool isEditing = false;
        [ObservableProperty]
        private bool isCreating = false;

        public ICommand CancelCommand { get; set; }


        public ProducerCollectionViewModel(BLController blc)
        {
            _blc = blc;
            Producers = new ObservableCollection<ProducerViewModel>();
            foreach (IProducer producer in _blc.GetAllProducers())
            {
                Producers.Add(new ProducerViewModel(producer));
            }

            CancelCommand = new Command(
                execute: () =>
                {
                    ProducerEdit.PropertyChanged -= OnProducerEditPropertyChanged;
                    ProducerEdit = null;
                    IsEditing = false;
                    isCreating = false;
                    RefreshCanExecute();
                },
                canExecute: () =>
                {
                    return IsEditing || isCreating;
                });


        }

        public bool IsCurrentlyEditing()
        {
            return IsEditing || isCreating;
        }

        [RelayCommand(CanExecute = nameof(CanCreateNewProducer))]
        private void CreateNewProducer()
        {
            ProducerEdit = new ProducerViewModel();
            ProducerEdit.PropertyChanged += OnProducerEditPropertyChanged;
            isCreating = true;
            RefreshCanExecute();
        }

        private bool CanCreateNewProducer()
        {
            return !IsEditing;
        }

        [RelayCommand(CanExecute = nameof(CanEditProducerBeSaved))]
        private void SaveProducer()
        {

            if (isCreating)
            {
                var producer = _blc.CreateProducer();
                producer.Name = ProducerEdit.Name;
                producer.Country = ProducerEdit.Country;
                _blc.AddProducer(producer);
            }
            else
            {
                var producer = _blc.GetProducer(ProducerEdit.Id);
                producer.Name = ProducerEdit.Name;
                producer.Country = ProducerEdit.Country;
                _blc.UpdateProducer(producer);
            }
            ProducerEdit.PropertyChanged -= OnProducerEditPropertyChanged;
            ProducerEdit = null;
            IsEditing = false;
            isCreating = false;
            RefreshCanExecute();
            reloadProducers();
        }

        private bool CanEditProducerBeSaved()
        {
            return this.ProducerEdit != null &&
                   ProducerEdit.Name != null &&
                   ProducerEdit.Name.Length >= 1 &&
                   ProducerEdit.Country != null &&
                   ProducerEdit.Country.Length >= 1;
        }

        public void EditProducer(ProducerViewModel producer)
        {
            ProducerEdit = producer;
            ProducerEdit.PropertyChanged += OnProducerEditPropertyChanged;
            IsEditing = true;
            isCreating = false;
            RefreshCanExecute();
        }

        [RelayCommand(CanExecute = nameof(CanEditProducerBeSaved))]
        public void DeleteProducer()
        {
            _blc.DeleteProducer(ProducerEdit.Id);
            isCreating = false;
            IsEditing = false;
            ProducerEdit = null;
            RefreshCanExecute();
            reloadProducers();
        }

        private void RefreshCanExecute()
        {
            CreateNewProducerCommand.NotifyCanExecuteChanged();
            SaveProducerCommand.NotifyCanExecuteChanged();
            DeleteProducerCommand.NotifyCanExecuteChanged();
            (CancelCommand as Command)?.ChangeCanExecute();
        }

        void OnProducerEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            SaveProducerCommand.NotifyCanExecuteChanged();
        }

        void reloadProducers()
        {
            Producers.Clear();
            foreach (IProducer producer in _blc.GetAllProducers())
            {
                Producers.Add(new ProducerViewModel(producer));
            }
            OnPropertyChanged(nameof(Producers));
        }

    }
}
