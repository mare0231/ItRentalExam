using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItRental.Dal;
using ItRental.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItRental.Web.Pages
{
    public class RentersModel : PageModel
    {
        [BindProperty]
        public Renter Renter { get; set; }
        public List<Renter> Renters { get; set; } = new List<Renter>();
        public List<Renter> RenterLevels { get; set; }
        public string Message { get; set; }

        public RentersModel()
        {
            RenterRepository renterRepository = new RenterRepository();
            Renters = renterRepository.GetRenters();
            List<RenterLevel> RenterLevelList = new List<RenterLevel>() { RenterLevel.Starter, RenterLevel.Normal, RenterLevel.TopRenter };
            RenterLevels = new List<Renter>();
            foreach (RenterLevel renterLevel in RenterLevelList)
            {
                RenterLevels.Add(new Renter() { RenterLevel = renterLevel });
            }
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            RenterRepository renterRepository = new RenterRepository();
            Renters = renterRepository.GetRenters();
        }
    }
}