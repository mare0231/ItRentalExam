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
            return Rentals[0];
        }

        public bool GotOverdueRental()
        {
            if (Rentals[0].ReturnTime < DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
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
