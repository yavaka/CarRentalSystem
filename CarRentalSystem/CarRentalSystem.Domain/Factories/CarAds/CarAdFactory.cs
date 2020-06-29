using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAds;
using System;

namespace CarRentalSystem.Domain.Factories.CarAds
{
    public class CarAdFactory : ICarAdFactory
    {
        private Make make = default!;
        private string model = default!;
        private Category category = default!;
        private string imageUrl = default!;
        private decimal pricePerDay = default!;
        private Options options = default!;

        private bool isMakeSet = false;
        private bool isCategorySet = false;
        private bool areOptionsSet = false;


        public CarAd Build()
        {
            if (!this.isMakeSet || !this.isCategorySet || !this.areOptionsSet)
            {
                throw new InvalidCarAdException("Make, Category, Options must have value.");
            }

            return new CarAd(
                make: this.make,
                model: this.model,
                category: this.category,
                imageUrl: this.imageUrl,
                pricePerDay: this.pricePerDay,
                options: this.options,
                isAvailable: true);
        }


        public ICarAdFactory WithMake(string name)
        {
            return this.WithMake(
                new Make(name));
        }

        public ICarAdFactory WithMake(Make make)
        {
            this.make = make;
            this.isMakeSet = true;
            return this;
        }

        public ICarAdFactory WithModel(string model)
        {
            this.model = model;
            return this;
        }

        public ICarAdFactory WithCategory(string name, string description)
        {
            return this.WithCategory(
                new Category(name, description));
        }

        public ICarAdFactory WithCategory(Category category)
        {
            this.category = category;
            this.isCategorySet = true;
            return this;
        }

        public ICarAdFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;
            return this;
        }

        public ICarAdFactory WithPricePerDay(decimal pricePerDay)
        {
            this.pricePerDay = pricePerDay;
            return this;
        }

        public ICarAdFactory WithOptions(bool hasClimateControl, int seats, TransmissionType transmissionType)
        {
            return this.WithOptions(
                new Options(
                    hasClimateControl,
                    seats,
                    transmissionType));
        }

        public ICarAdFactory WithOptions(Options options)
        {
            this.options = options;
            this.areOptionsSet = true;
            return this;
        }
    }
}
