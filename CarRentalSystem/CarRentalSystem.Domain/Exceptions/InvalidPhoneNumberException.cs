using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Domain.Exceptions
{
    class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException() { }

        public InvalidPhoneNumberException(string message) => this.Message = message;
    }
}
