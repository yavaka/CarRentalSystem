using CarRentalSystem.Domain.Models.CarAds;

namespace CarRentalSystem.Domain.Factories.CarAds
{
    public interface ICarAdFactory : IFactory<CarAd>
    {
        ICarAdFactory WithMake(string name);

        ICarAdFactory WithMake(Make make);

        ICarAdFactory WithModel(string model);

        ICarAdFactory WithCategory(string name, string description);

        ICarAdFactory WithCategory(Category category);

        ICarAdFactory WithImageUrl(string imageUrl);

        ICarAdFactory WithPricePerDay(decimal pricePerDay);

        ICarAdFactory WithOptions(
            bool hasClimateControl,
            int seats,
            TransmissionType transmissionType);

        ICarAdFactory WithOptions(Options options);
    }
}
