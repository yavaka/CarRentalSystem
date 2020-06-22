using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.Dealers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        //DDD rule: only aggregate root entities` constructors should be public
        //DDD rule: the constructor should validate object/s
        internal User(string email)
            : base(email)
        {
            this.Email = email;
        }


        public Dealer? Dealer { get; private set; }


        public void BecomeDealer(Dealer dealer) 
        {
            if (this.Dealer != null)
            {
                throw new InvalidDealerException($"User '{this.UserName}' is already a dealer.");
            }

            this.Dealer = dealer;
        }
    }
}
