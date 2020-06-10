﻿using System;
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

        public class CarAd 
        {
            public const int MinModelLength = 2;
            public const int MaxModelLength = 20;

        }

        public class Category
        {
            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 2000;

        }
        
        public class Options
        {
            public const int MinNumberOfSeats = 2;
            public const int MaxNumberOfSeats = 10;
        }
    }
}
