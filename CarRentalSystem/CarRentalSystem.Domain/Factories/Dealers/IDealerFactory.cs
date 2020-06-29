using CarRentalSystem.Domain.Models.Dealers;

namespace CarRentalSystem.Domain.Factories.Dealers
{
    public interface IDealerFactory : IFactory<Dealer>
    {
        IDealerFactory WithName(string name);

        IDealerFactory WithPhoneNumber(string phoneNumber);
    }
}
