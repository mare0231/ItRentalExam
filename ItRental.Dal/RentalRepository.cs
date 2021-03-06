﻿using ItRental.Entities;
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

        public List<Rental> GetRentalsByRenterId(int id)
        {
            string sql = $"SELECT * FROM Rentals WHERE RenterId = {id} ORDER BY ReturnTime ASC";
            return HandleData(ExecuteQuery(sql));
        }

        private List<Rental> HandleData(DataTable dataTable)
        {
            List<Rental> rentals = new List<Rental>();
            if (dataTable is null)
                return rentals;

            EquipmentRepository equipmentRepository = new EquipmentRepository();
            RenterRepository renterRepository = new RenterRepository();

            foreach (DataRow row in dataTable.Rows)
            {
                Rental rental = new Rental()
                {
                    Id = (int)row["RentalId"],
                    RentalTime = (DateTime)row["RentalTime"],
                    ReturnTime = (DateTime)row["ReturnTime"],
                    Units = (int)row["Units"]
                };
                rentals.Add(rental);
            }
            return rentals;
        }
    }
}
