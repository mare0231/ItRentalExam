using ItRental.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ItRental.Dal
{
    public class RentalRepository : BaseRepository
    {
        public List<Rental> GetRentals()
        {
            string sql = "SELECT * FROM Rentals";
            return HandleData(ExecuteQuery(sql));
        }

        private List<Rental> HandleData(DataTable dataTable)
        {
            List<Rental> rentals = new List<Rental>();
            if (dataTable is null)
                return rentals;

            RenterRepository renterRepository = new RenterRepository();

            foreach (DataRow row in dataTable.Rows)
            {
                Rental rental = new Rental()
                {
                    Id = (int)row["RentalId"],
                    RentalTime = (DateTime)row["RentalTime"],
                    ReturnTime = (DateTime)row["ReturnTime"],
                    Equipment = (Equipment)row["Equipment"],
                    Units = (int)row["Units"],
                    Renter = renterRepository.GetRenter((int)row["RenterId"])
                };
                rentals.Add(rental);
            }
            return rentals;
        }
    }
}
