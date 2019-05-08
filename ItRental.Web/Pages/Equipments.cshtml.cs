using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ItRental.Dal;
using ItRental.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItRental.Web.Pages
{
    public class EquipmentsModel : PageModel
    {
        [BindProperty]
        public Equipment Equipment { get; set; }
        public List<Equipment> Equipments { get; set; } = new List<Equipment>();

        public EquipmentsModel()
        {
            EquipmentRepository equipmentRepository = new EquipmentRepository();
            Equipments = equipmentRepository.GetEquipments();
        }
        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            EquipmentRepository equipmentRepository = new EquipmentRepository();
            equipmentRepository.InsertEquipment(Equipment);
            Equipments = equipmentRepository.GetEquipments();
        }
    }
}