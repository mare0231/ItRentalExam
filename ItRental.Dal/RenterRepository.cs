using ItRental.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ItRental.Dal
{
    public class RenterRepository : BaseRepository
    {
        public List<Renter> GetRenters()
        {
            string sql = "SELECT * FROM Renters";
            return HandleData(ExecuteQuery(sql));
        }

        public string InsertRenter(Renter renter)
        {
            bool isValid = IsValid(renter, out string message);
            if (!isValid)
            {
                return message;
            }
            ExecuteNonQuery($"INSERT INTO Renters VALUES ('{renter.Name}', {(int) renter.RenterLevel})");
            return message;
        }

        private bool IsValid(Renter renter, out string message)
        {
            if (string.IsNullOrWhiteSpace(renter.Name))
            {
                message = "Alle felter skal udfyldes";
                return false;
            }
            message = $"{renter.Name} er oprettet";
            return true;
        }

        public Renter GetRenter(int id)
        {
            string sql = $"SELECT * FROM Renters WHERE RenterId = '{id}'";
            return HandleData(ExecuteQuery(sql))[0];
        }

        public List<Renter> GetRentersByName(string name)
        {
            string sql = $"SELECT * FROM Renters WHERE Name LIKE '%{name}%'";
            return HandleData(ExecuteQuery(sql));
        }

        private List<Renter> HandleData(DataTable dataTable)
        {
            List<Renter> renters = new List<Renter>();
            if (dataTable is null)
                return renters;

            RentalRepository rentalRepository = new RentalRepository();

            foreach (DataRow row in dataTable.Rows)
            {
                Renter renter = new Renter()
                {
                    Id = (int)row["RenterId"],
                    Name = (string)row["Name"],
                    RenterLevel = (RenterLevel)row["RenterLevel"]
                };
                renter.Rentals = rentalRepository.GetRentalsByRenterId(renter.Id);
                renters.Add(renter);
            }
            return renters;
        }
    }
}
