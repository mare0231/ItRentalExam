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
            if (other is null) return 1;
            return ReturnTime.CompareTo(other.ReturnTime);
        }

        public bool IsRentalOverdue()
        {
            if (ReturnTime < DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
