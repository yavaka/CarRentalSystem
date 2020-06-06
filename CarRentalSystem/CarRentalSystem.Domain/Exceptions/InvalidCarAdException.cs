using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Domain.Exceptions
{
    public class InvalidCarAdException : BaseDomainException
    {
        public InvalidCarAdException() { }

        public InvalidCarAdException(string message) => this.Message = message;
    }
}
