﻿using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAds;
using System.Collections.Generic;
using System.Linq;
using static CarRentalSystem.Domain.Models.ValidationConstants.Common;

namespace CarRentalSystem.Domain.Models.Dealers
{
    public class Dealer : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<CarAd> _carAds;

        //DDD rule: only aggregate root entities` constructors should be public
        //DDD rule: the constructor should validate object/s
        //PhoneNumber validation is not required as it is in other class where the validation happen
        public Dealer(string name, PhoneNumber phoneNumber)
        {
            this.Validate(name);

            this.Name = name;
            this.PhoneNumber = phoneNumber;

            this._carAds = new HashSet<CarAd>();
        }

        //DDD rule: entities cannot be created with an invalid state.
        //EF Core wants constructors that bind non-navigational props.
        private Dealer(string name)
        {
            this.Name = name;
            this.PhoneNumber = default!;
            this._carAds = new HashSet<CarAd>();
        }


        public string Name { get; }

        public PhoneNumber PhoneNumber { get; }

        //DDD rule: all collections to be immutable
        public IReadOnlyCollection<CarAd> CarAds => this._carAds.ToList().AsReadOnly();


        public void AddCarAd(CarAd carAd) 
        {
            this._carAds.Add(carAd);
        }

        private void Validate(string name)
        {
            Guard.ForStringLength<InvalidDealerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
        }
    }
}
