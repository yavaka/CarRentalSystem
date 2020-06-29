using CarRentalSystem.Domain.Models.Dealers;

namespace CarRentalSystem.Domain.Factories.Dealers
{
    internal class DealerFactory : IDealerFactory
    {
        private string dealerName = default!;
        private string dealerPhoneNumber = default!;


        public Dealer Build()
        {
            return new Dealer(
                name: this.dealerName,
                phoneNumber: this.dealerPhoneNumber);
           
        }

        public IDealerFactory WithName(string name)
        {
            this.dealerName = name;
            return this;
        }

        public IDealerFactory WithPhoneNumber(string phoneNumber)
        {
            this.dealerPhoneNumber = phoneNumber;
            return this;
        }
    }
}
