using System;
using System.Collections.Generic;
using System.Text;

namespace ItRental.Entities
{
    public class Renter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RenterLevel RenterLevel { get; set; }
        public List<Rental> Rentals { get; set; }
        public int NumberOfRentals { get { return Rentals.Count; } }

        public Rental NextRentalDue()
        {
            if (Rentals.Count > 0)
            {
                return Rentals[0];
            }
            else
            {
                return null;
            }
        }

        public bool GotOverdueRental()
        {
            if (Rentals.Count == 0 || Rentals[0].ReturnTime > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string TranslateRenterLevel()
        {
            switch (RenterLevel)
            {
                case RenterLevel.Starter:
                    return "Begynder";
                case RenterLevel.Normal:
                    return "Normal";
                case RenterLevel.TopRenter:
                    return "Toplåner";
                default:
                    return "";
            }
        }
    }
}
