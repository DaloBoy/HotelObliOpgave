using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelObliOpgave.Model;
using HotelObliOpgave.ViewModel;

namespace HotelObliOpgave.Handler
{
    class GuestHandler
    {
        public GuestViewModel GuestViewModel { get; set; }

        public GuestHandler(GuestViewModel gvm)
        {
            GuestViewModel = gvm;
        }

        public void CreateGuest()
        {
            Guest tempGuest = new Guest(GuestViewModel.Guest_No, GuestViewModel.Name, GuestViewModel.Address);
            GuestCatalogSingleton.Instance.AddGuest(tempGuest);
        }

        public void DeleteGuest()
        {
            GuestViewModel.GuestCatalogSingleton.RemoveGuest(GuestViewModel.SelectedGuest);
        }

        public void UpdateGuest()
        {
            GuestViewModel.GuestCatalogSingleton.UpdateGuest(GuestViewModel.SelectedGuest);
        }
    }
}
