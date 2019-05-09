using ItRental.Entities.OpeningAPI;
using Newtonsoft.Json;
using System;
using System.Net;

namespace ItRental.Services
{
    public class OpeningService
    {
        public Opening GetOpeningHours()
        {
            string json;
            using (WebClient webClient = new WebClient())
            {
                json = webClient.DownloadString($"http://api.aspitcloud.dk/openinghours");
            }
            return JsonConvert.DeserializeObject<Opening>(json);
        }
    }
}
