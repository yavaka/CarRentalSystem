using CarRentalSystem.Application;
using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Models.Dealers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalSystem.Web.Features
{

    [ApiController]
    [Route("[controller]")]
    public class CarAdsController : ControllerBase
    {
        private readonly IRepository<CarAd> _carAds;
        private readonly IOptions<ApplicationSettings> _settings;

        public CarAdsController(IRepository<CarAd> carAds,
            IOptions<ApplicationSettings> settings)
        {
            this._carAds = carAds;
            this._settings = settings;
        }


        [HttpGet]
        //Get car ads of the given dealer
        public IEnumerable<CarAd> Get()
        {
            return this._carAds.All()
                .Where(a => a.IsAvailable);
        }
    }
}
