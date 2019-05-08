using System;
using System.Collections.Generic;
using System.Text;

namespace ItRental.Entities
{
    public class Rental : IComparable<Rental>
    {
        public int Id { get; set; }
        public DateTime RentalTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public Equipment Equipment { get; set; }
        public int Units { get; set; }
        public Renter Renter { get; set; }

        public int CompareTo(Rental other)
        {
            throw new NotImplementedException();
        }

        public bool IsRentalOverdue()
        {
            throw new NotImplementedException();
        }
    }
}
