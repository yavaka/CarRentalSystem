using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Models.Dealers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalSystem.Web.Features
{

    [ApiController]
    [Route("[controller]")]
    public class CarAdsController : ControllerBase
    {
        private static readonly Dealer _dealer = new Dealer(
            name: "Test dealer",
            phoneNumber: "+12342355436");

        [HttpGet]
        //Get car ads of the given dealer
        public IEnumerable<CarAd> Get() 
        {
            return _dealer.CarAds
                .Where(a =>a.IsAvailable);
        }
    }
}
