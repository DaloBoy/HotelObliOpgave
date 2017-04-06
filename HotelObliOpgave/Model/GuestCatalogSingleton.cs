using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelObliOpgave.Persistency;

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
            PersistencyService.PostGuestAsync(GuestAdd);
        }

        public void RemoveGuest(Guest GuestRemove)
        {
            Guests.Remove(GuestRemove);
            PersistencyService.DeleteGuestAsync(GuestRemove);
        }

        public void UpdateGuest(Guest g)
        {

        }

        public async Task GetGuestsAsync()
        {
            foreach (var item in await PersistencyService.GetGuestAsync())
            {
                this.Guests.Add(item);
            }
        }
    }
}
