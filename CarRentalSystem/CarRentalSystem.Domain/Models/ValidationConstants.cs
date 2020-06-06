using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Domain.Models
{
    public class ValidationConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class PhoneNumber
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberFirstSymbol = "+";
        }

    }
}
