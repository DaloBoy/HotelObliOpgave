using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelObliOpgave.ViewModel;

namespace HotelObliOpgave.Handler
{
    class HandlerGuest
    {
        public GuestViewModel GuestViewModel { get; set; }

        public void GuestHandler(GuestViewModel gvm)
        {
            this.GuestViewModel = gvm;
        }

        public void CreateGuest()
        {
            Guest tempGuest = new Guest(GuestViewModel.Guest_No, GuestViewModel.Name, GuestViewModel.Address);

        }
    }
}
