using System;
using System.Collections.Generic;
using System.Text;

namespace ItRental.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentalTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public Equipment Equipment { get; set; }
        public int Units { get; set; }
        public Renter Renter { get; set; }
        public bool IsRentalOverdue()
        {
            throw new NotImplementedException();
        }
    }
}
