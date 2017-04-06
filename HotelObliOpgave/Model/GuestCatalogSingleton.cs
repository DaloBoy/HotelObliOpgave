using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

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
            Load();
        }

        public void AddGuest(Guest GuestAdd)
        {
            Persistency.PersistencyService.PostGuest(GuestAdd);
            Guests.Add(GuestAdd);
        }

        public void RemoveGuest(Guest GuestDelete)
        {
            Persistency.PersistencyService.DeleteGuest(GuestDelete);
            if (GuestDelete != null)
            {
                Guests.Remove(GuestDelete);
            }
        }

        public void UpdateGuest(Guest GuestUpdate)
        {
            Persistency.PersistencyService.PutGuest(GuestUpdate);
            Load();
        }
        public void Load()
        {
            try
            {
                Guests = Persistency.PersistencyService.GetGuest();
            }
            catch (Exception e)
            {

                MessageDialog Error = new MessageDialog("Error : " + e);
                Error.Commands.Add(new UICommand { Label = "Ok" });
                Error.ShowAsync().AsTask();

            }
        }
    }
}
