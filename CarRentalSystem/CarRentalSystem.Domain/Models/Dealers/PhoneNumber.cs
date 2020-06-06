using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using static CarRentalSystem.Domain.Models.ValidationConstants.PhoneNumber;

namespace CarRentalSystem.Domain.Models.Dealers
{
    public class PhoneNumber : ValueObject
    {
        //DDD rule: Value objects should be internal
        internal PhoneNumber(string phoneNumber)
        {
            this.Validate(phoneNumber);

            this.Number = phoneNumber;
        }


        public string Number { get; }


        public static implicit operator string(PhoneNumber phoneNumber) 
        {
            return phoneNumber.Number;
        }

        public static implicit operator PhoneNumber(string phoneNumber) 
        {
            return new PhoneNumber(phoneNumber);
        }

        private void Validate(string phoneNumber)
        {
            Guard.ForStringLength<InvalidPhoneNumberException>(
                phoneNumber, 
                MinPhoneNumberLength,
                MaxPhoneNumberLength, 
                nameof(PhoneNumber));

            if (!phoneNumber.StartsWith(PhoneNumberFirstSymbol))
            {
                throw new InvalidPhoneNumberException($"Phone number must start with a '+'.");
            }
        }
    }
}