using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using INF148151_148140.ShoesApp.BLC;
using INF148151_148140.ShoesApp.Core;
using INF148151_148140.ShoesApp.Intefaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace INF148151_148140.ShoesApp.MAUI.ViewModels
{
    public partial class FootwearCollectionViewModel: ObservableObject
    {
        [ObservableProperty]
        private List<FootwearViewModel> footwearCollection;


        [ObservableProperty]
        private ObservableCollection<FootwearViewModel> footwears;

        private BLController _blc;

        private FootwearViewModel footwearEdit;

        public FootwearViewModel FootwearEdit
        {
            get { return footwearEdit; }
            set { SetProperty(ref footwearEdit, value); }
        }

        [ObservableProperty]
        private bool isEditing = false;
        [ObservableProperty]
        private bool isCreating = false;

        public ICommand CancelCommand { get; set; }


        public FootwearCollectionViewModel(BLController blc)
        {
            _blc = blc;
            Footwears = new ObservableCollection<FootwearViewModel>();
            foreach (IFootwear footwear in _blc.GetAllFootwear())
            {
                Footwears.Add(new FootwearViewModel(footwear));
            }

            CancelCommand = new Command(
                execute: () =>
                {
                    FootwearEdit.PropertyChanged -= OnFootwearEditPropertyChanged;
                    FootwearEdit = null;
                    IsEditing = false;
                    isCreating = false;
                    RefreshCanExecute();
                },
                canExecute: () =>
                {
                    return IsEditing || isCreating;
                });
        }


        [RelayCommand(CanExecute = nameof(CanCreateNewFootwear))]
        private void CreateNewFootwear()
        {
            FootwearEdit = new FootwearViewModel();
            FootwearEdit.PropertyChanged += OnFootwearEditPropertyChanged;
            isCreating = true;
            RefreshCanExecute();
        }

        private bool CanCreateNewFootwear()
        {
            return !IsEditing;
        }

        [RelayCommand(CanExecute = nameof(CanEditFootwearBeSaved))]
        private void SaveFootwear()
        {

            if (isCreating)
            {
                var footwear = _blc.CreateFootwear();
                footwear.Name = FootwearEdit.Name;
                _blc.AddFootwear(footwear);
            }
            else
            {
                var footwear = _blc.GetFootwear(FootwearEdit.Id);
                footwear.Name = FootwearEdit.Name;
                _blc.UpdateFootwear(footwear);
            }
            FootwearEdit.PropertyChanged -= OnFootwearEditPropertyChanged;
            FootwearEdit = null;
            IsEditing = false;
            isCreating = false;
            RefreshCanExecute();
            reloadFootwears();
        }

        private bool CanEditFootwearBeSaved()
        {
            return this.FootwearEdit != null &&
                   FootwearEdit.Name != null &&
                   FootwearEdit.Name.Length >= 1;
        }

        public void EditFootwear(FootwearViewModel footwear)
        {
            FootwearEdit = footwear;
            FootwearEdit.PropertyChanged += OnFootwearEditPropertyChanged;
            IsEditing = true;
            isCreating = false;
            RefreshCanExecute();
        }

        [RelayCommand(CanExecute = nameof(CanEditFootwearBeSaved))]
        public void DeleteFootwear()
        {
            _blc.DeleteFootwear(FootwearEdit.Id);
            isCreating = false;
            IsEditing = false;
            FootwearEdit = null;
            RefreshCanExecute();
            reloadFootwears();
        }

        private void RefreshCanExecute()
        {
            CreateNewFootwearCommand.NotifyCanExecuteChanged();
            SaveFootwearCommand.NotifyCanExecuteChanged();
            DeleteFootwearCommand.NotifyCanExecuteChanged();
            (CancelCommand as Command)?.ChangeCanExecute();
        }

        void OnFootwearEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            SaveFootwearCommand.NotifyCanExecuteChanged();
        }

        void reloadFootwears()
        {
            Footwears.Clear();
            foreach (IFootwear footwear in _blc.GetAllFootwear())
            {
                Footwears.Add(new FootwearViewModel(footwear));
            }
        }



    }
    public class MyEnumToIntConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            FootwearType footwearType = (FootwearType)value;
            int result = (int)footwearType;
            return result;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            int val = (int)value;
            if (val != -1)
                return (FootwearType)value;
            else
                return 0;

        }
    }
}
