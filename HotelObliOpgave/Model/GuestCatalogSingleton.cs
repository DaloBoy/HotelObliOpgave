using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelObliOpgave.Model
{
    class GuestCatalogSingleton
    {
        private ObservableCollection<Guest> guests;
        public ObservableCollection<Guest> Guests
        {
            get { return guests; }
            set { guests = value; }
        }

        private static GuestCatalogSingleton instance;

        public static GuestCatalogSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GuestCatalogSingleton();
                }
                return instance;
            }
        }
        public GuestCatalogSingleton()
        {
            Guests = new ObservableCollection<Guest>();

        }

        public void AddGuest(Guest GuestAdd)
        {
            Guests.Add(GuestAdd);
        }

        public void RemoveGuest(Guest GuestRemove)
        {
            Guests.Remove(GuestRemove);
        }

        public void UpdateGuest(Guest g)
        {

        }   
    }
}
