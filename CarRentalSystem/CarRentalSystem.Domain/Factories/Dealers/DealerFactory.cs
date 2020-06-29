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

        //Such this methods are recommended for models with low amount of properties
        public Dealer Build(string name, string phoneNumber)
        {
            return this
                .WithName(name)
                .WithPhoneNumber(phoneNumber)
                .Build();

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
