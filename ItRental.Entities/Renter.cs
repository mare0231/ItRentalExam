using System;
using System.Collections.Generic;
using System.Text;

namespace ItRental.Entities
{
    class Renter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RenterLevel RenterLevel { get; set; }
        public List<Rental> Rentals { get; set; }
        public int NumberOfRentals { get; }
        public Rental NextRentalDue()
        {
            throw new NotImplementedException();
        }
        public bool GotOverdueRental()
        {
            throw new NotImplementedException();
        }
    }
}
