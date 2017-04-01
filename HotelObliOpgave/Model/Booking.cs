using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelObliOpgave.Model
{
    public class Booking
    {
        public int Booking_id { get; set; }
        public int Hotel_No { get; set; }
        public int Guest_No { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Room_No { get; set; }
    }
}
