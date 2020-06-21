using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using static CarRentalSystem.Domain.Models.ValidationConstants.Common;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class Make : Entity<int>
    {
        //DDD rule: only aggregate root entities` constructors should be public
        //DDD rule: the constructor should validate object/s
        internal Make(string name) 
        {
            this.Validate(name);

            this.Name = name;
        }


        public string Name { get; }

        private void Validate(string name)
        {
            Guard.ForStringLength<InvalidCarAdException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(name));
        }
    }
}