using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelObliOpgave.Common;
using HotelObliOpgave.Handler;
using HotelObliOpgave.Model;


namespace HotelObliOpgave.ViewModel
{
    class GuestViewModel : INotifyPropertyChanged
    {

        public GuestCatalogSingleton GuestCatalogSingleton { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateGuestCommand { get; set; }
        public ICommand DeleteGuestCommand { get; set; }
        public ICommand UpdateGuestCommand { get; set; }


        public int Guest_No
        {
            get { return Guest_No; }
            set { Guest_No = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private Guest selectedguest;

        public Guest SelectedGuest
        {
            get { return selectedguest; }
            set { selectedguest = value; OnPropertyChanged(nameof(SelectedGuest)); }
        }

        public GuestViewModel()
        {
            //CreateGuestCommand = new RelayCommand(GuestHandler.CreateGuest, null);
            //DeleteGuestCommand = new RelayCommand(DeleteGuest, CanDeleteGuest);
            //UpdateGuestCommand = new RelayCommand(UpdateGuest, CanUpdateGuest);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
