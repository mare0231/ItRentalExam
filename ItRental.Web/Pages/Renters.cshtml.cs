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
        public string Heading { get; set; }
        [BindProperty]
        public string SearchName { get; set; }
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
            Heading = "Oversigt over lånere";
        }

        public void OnGet()
        {
            
        }

        public void OnGetOverdue()
        {
            Heading = "Oversigt over lånere med overskredne lån";
            List<Renter> renters = new List<Renter>();
            foreach (Renter renter in Renters)
            {
                if (renter.GotOverdueRental())
                {
                    renters.Add(renter);
                }
            }
            Renters = renters;
        }

        public void OnPost()
        {
            RenterRepository renterRepository = new RenterRepository();
            Message = renterRepository.InsertRenter(Renter);
            Renters = renterRepository.GetRenters();
        }

        public void OnPostSearch()
        {
            RenterRepository renterRepository = new RenterRepository();
            Renters = renterRepository.GetRentersByName(SearchName);
        }
    }
}