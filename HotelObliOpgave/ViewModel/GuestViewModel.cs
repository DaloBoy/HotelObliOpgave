using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelObliOpgave.Common;

namespace HotelObliOpgave.ViewModel
{
    class GuestViewModel : INotifyPropertyChanged
    {
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

        public GuestViewModel()
        {
            
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
