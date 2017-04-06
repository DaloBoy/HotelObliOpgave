using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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

        private ObservableCollection<Guest> guestCollection;

        public ObservableCollection<Guest> GuestCollection
        {
            get { return guestCollection; }
            set { guestCollection = value; }
        }

        //Icommand Prop
        public ICommand CreateGuestCommand { get; set; }
        public ICommand DeleteGuestCommand { get; set; }
        public ICommand UpdateGuestCommand { get; set; }
        public ICommand GetGuestCommand { get; set; }

        //Props
        private int guest_no;
        public int Guest_No
        {
            get { return guest_no; }
            set
            {
                guest_no = value;
                OnPropertyChanged(nameof(Guest_No));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private Guest selectedguest;

        public Guest SelectedGuest
        {
            get { return selectedguest; }
            set { selectedguest = value; OnPropertyChanged(nameof(SelectedGuest)); }
        }

        //Handler
        public Handler.GuestHandler GuestHandler { get; set; }

        //ViewModel
        public GuestViewModel()
        {
            GuestCollection = GuestCatalogSingleton.Instance.Guests;
            GuestCatalogSingleton = GuestCatalogSingleton.Instance;
            GuestHandler = new HotelObliOpgave.Handler.GuestHandler(this);

            CreateGuestCommand = new RelayCommand(GuestHandler.CreateGuest, null);
            DeleteGuestCommand = new RelayCommand(GuestHandler.DeleteGuest);
            //UpdateGuestCommand = new RelayCommand(UpdateGuest, CanUpdateGuest);
            GetGuestCommand = new RelayCommand(GuestHandler.GetGuest, null);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool CanDeleteGuest()
        {
            if (GuestCollection.Count > 0)
                return true;
            else
            {
                return false;
            }
        }
    }
}
