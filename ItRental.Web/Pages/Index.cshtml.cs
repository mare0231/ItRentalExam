using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItRental.Dal.Services;
using ItRental.Entities.OpeningAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItRental.Web.Pages
{
    public class IndexModel : PageModel
    {
        public Opening OpeningHours { get; set; }
        public void OnGet()
        {
            OpeningService openingService = new OpeningService();
            OpeningHours = openingService.GetOpeningHours();
        }
    }
}