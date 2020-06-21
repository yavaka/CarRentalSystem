using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using static CarRentalSystem.Domain.Models.ValidationConstants.CarAd;
using static CarRentalSystem.Domain.Models.ValidationConstants.Common;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class CarAd : Entity<int>, IAggregateRoot
    {
        //DDD rule: only aggregate root entities` constructors should be public
        //DDD rule: the constructor should validate object/s
        public CarAd(
            Make make,
            string model,
            Category category,
            string imageUrl,
            decimal pricePerDay,
            Options options,
            bool isAvailable) 
        {
            this.Validate(model, imageUrl, pricePerDay);

            this.Make = make;
            this.Model = model;
            this.Category = category;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;
            this.Options = options;
            this.IsAvailable = isAvailable;
        }

        //DDD rule: entities cannot be created with an invalid state.
        //EF Core wants constructors that bind non-navigational props.
        private CarAd(
            string model,
            string imageUrl,
            decimal pricePerDay,
            bool isAvailable)
        {
            this.Model = model;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;
            this.IsAvailable = isAvailable;

            this.Make = default!;
            this.Category = default!;
            this.Options = default!;
        }


        public Make Make{ get; }

        public string Model{ get; }

        public Category Category{ get; }

        public string ImageUrl { get; }

        public decimal PricePerDay { get; }

        public Options Options{ get; }

        public bool IsAvailable { get; private set; }


        public void ChangeAvailability() 
        {
            this.IsAvailable = !this.IsAvailable;
        }

        private void Validate(string model, string imageUrl, decimal pricePerDay)
        {
            Guard.ForStringLength<InvalidCarAdException>(
                model,
                MinModelLength,
                MaxModelLength,
                nameof(this.Model));

            Guard.ForValidUrl<InvalidCarAdException>(imageUrl, nameof(this.ImageUrl));

            Guard.AgainstOutOfRange<InvalidCarAdException>(
                pricePerDay,
                Zero,
                decimal.MaxValue,
                nameof(this.PricePerDay));
        }
    }
}
