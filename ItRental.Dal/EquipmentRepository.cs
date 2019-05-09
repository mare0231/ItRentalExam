using ItRental.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ItRental.Dal
{
    public class EquipmentRepository : BaseRepository
    {
        /// <summary>
        /// Retrieves all equipments from the database
        /// </summary>
        /// <returns></returns>
        public List<Equipment> GetEquipments()
        {
            string sql = "SELECT * FROM Equipments";
            return HandleData(ExecuteQuery(sql));
        }

        public Equipment GetEquipment(int id)
        {
            string sql = $"SELECT * FROM Equipment WHERE EquipmentId = '{id}'";
            return HandleData(ExecuteQuery(sql))[0];
        }

        /// <summary>
        /// Helper method used to convert DataTable to a list of Equipments.
        /// Returns an empty list if the parameter is null.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<Equipment> HandleData(DataTable dataTable)
        {
            List<Equipment> equipments = new List<Equipment>();
            if (dataTable is null)
                return equipments;

            foreach (DataRow row in dataTable.Rows)
            {
                Equipment equipment = new Equipment()
                {
                    Id = (int)row["EquipmentId"],
                    Name = (string)row["Name"],
                    Category = (string)row["Category"],
                    Units = (int)row["Units"]
                };
                equipments.Add(equipment);
            }
            return equipments;
        }

        public string InsertEquipment(Equipment equipment)
        {
            bool isValid = IsValid(equipment, out string message);
            if (!isValid)
            {
                return message;
            }
            string sql = $"SELECT * FROM Equipments WHERE Name = '{equipment.Name}' AND Category = '{equipment.Category}'";
            List<Equipment> equipments = HandleData(ExecuteQuery(sql));
            if (equipments.Count > 0)
            {
                ExecuteNonQuery($"UPDATE Equipments SET Units = Units + {equipment.Units} WHERE Name = '{equipment.Name}' AND Category = '{equipment.Category}'");
            }
            else
            {
                ExecuteNonQuery($"INSERT INTO Equipments VALUES ('{equipment.Name}', '{equipment.Category}', {equipment.Units})");
            }
            return message;
        }

        private bool IsValid(Equipment equipment, out string message)
        {
            if (string.IsNullOrWhiteSpace(equipment.Name) || string.IsNullOrWhiteSpace(equipment.Category))
            {
                message = "Alle felter skal udfyldes";
                return false;
            }
            message = $"{equipment.Units} {equipment.Name} er tilføjet";
            return true;
        }
    }
}
