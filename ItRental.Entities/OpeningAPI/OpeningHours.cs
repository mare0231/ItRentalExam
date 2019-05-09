using System;
using System.Collections.Generic;
using System.Text;

namespace ItRental.Entities.OpeningAPI
{
    public class OpeningHours
    {
        public string Day { get; set; }
        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }
    }
}
