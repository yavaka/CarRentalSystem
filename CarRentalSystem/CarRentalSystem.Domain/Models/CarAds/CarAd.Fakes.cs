using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class CarAdFakes
    {
        public class CarAdDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type)
            {
                return true;
            }

            public object? Create(Type type)
            {
               return new CarAd(
                 make: new Make(name: "Subaru"),
                 model: "Impreza",
                 category: new Category(
                     name: "Saloon",
                     description: "Saloon, A.K.A sedans, has longer wheelbase than conventional family hatchback."),
                 imageUrl: "https://www.subaru.co.uk/",
                 pricePerDay: 50.00m,
                 options: new Options(
                     hasClimateControl: true,
                     seats: 5,
                     transmissionType: TransmissionType.Manual),
                 isAvailable: true);
            }
        }
    }
}
