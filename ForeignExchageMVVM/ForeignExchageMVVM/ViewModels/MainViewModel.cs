namespace ForeignExchageMVVM.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using System;
    using System.ComponentModel;

    public class MainViewModel : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Attributes

        string _dollars;
        string _euros;
        string _pounds;

        #endregion

        #region Properties

        public string Pesos
        {
            get;
            set;
        }

        public string Dollars
        {
            get
            {
                return _dollars;
            }

            set
            {
                if (value != _dollars)
                {
                    _dollars = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Dollars)));
                }
            }
        }

        public string Euros
        {
            get
            {
                return _euros;
            }

            set
            {
                if (value != _euros)
                {
                    _euros = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Euros)));
                }
            }
        }

        public string Pounds
        {
            get
            {
                return _pounds;
            }

            set
            {
                if (value != _pounds)
                {
                    _pounds = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Pounds)));
                }
            }
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand ConvertCommand
        {
            get { return new RelayCommand(Convert); }
        }

        async private void Convert()
        {
            if (string.IsNullOrEmpty(Pesos))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a value in pesos...", "Accept");
                return;
            }

            decimal pesos = 0;
            if (!decimal.TryParse(Pesos, out pesos))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a value numeric in pesos...", "Accept");
                return;
            }

            var dollars = pesos / 3003.003M;
            var euros = pesos / 3531.050M;
            var pounds = pesos / 3907.2372M;

            Dollars= String.Format("{0:C2}", dollars);
            Euros = String.Format("{0:C2}", euros);
            Pounds = String.Format("{0:C2}", pounds);
        }

        public ICommand ClearCommand
        {
            get { return new RelayCommand(Clear); }
        }

        private void Clear()
        {
            Dollars = null;
            Euros = null;
            Pounds = null;
        }
        #endregion
    }
}
