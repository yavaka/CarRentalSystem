using CarRentalSystem.Application.Contracts;
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
        private readonly IRepository<CarAd> _carAds;


        public CarAdsController(IRepository<CarAd> carAds)
        {
            this._carAds = carAds;
        }


        [HttpGet]
        //Get car ads of the given dealer
        public IEnumerable<CarAd> Get() 
        {
            return this._carAds.All()
                .Where(a =>a.IsAvailable);
        }
    }
}
