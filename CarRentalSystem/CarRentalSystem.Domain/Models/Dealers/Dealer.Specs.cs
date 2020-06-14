using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAds;
using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace CarRentalSystem.Domain.Models.Dealers
{
    public class DealerSpecs
    {
        [Fact]
        public void ValidDealerShouldSaveCarAd() 
        {
            //Arrange
            var dealer = new Dealer(
                name:"Private dealer",
                phoneNumber: "+123456789");

            //Instantiate a new CarAd entity from Fake Factory
            var carAd = A.Dummy<CarAd>();

            //Act
            dealer.AddCarAd(carAd);

            //Assert
            dealer.CarAds.Should()
                .Contain(carAd);
        }

        [Fact]
        public void InvalidDealerShouldThrowException()
        {
            //Act
            Action act = () => new Dealer(
                name: "",
                phoneNumber: "+123456789");

            //Assert
            act.Should().Throw<InvalidDealerException>();
        }
    }
}
