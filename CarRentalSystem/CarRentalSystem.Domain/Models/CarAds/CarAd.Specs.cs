using CarRentalSystem.Domain.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class CarAdSpecs
    {
        [Fact]
        public void ValidCarAdShouldNotThrowException()
        {
            //Act
            Action act = () => new CarAd(
                 make: new Make(name: "Subaru"),
                 model: "Impreza",
                 category: new Category(
                     name: "Saloon",
                     description: "Saloon, A.K.A sedans, has longer wheelbase than conventional family hatchback."),
                 imageUrl: "https://www.subaru.co.uk/",
                 pricePerDay: 50.00m,
                 options: new Options(
                     hasClimateControl: true,
                     seats: 5,
                     transmissionType: TransmissionType.Manual),
                 isAvailable: true);

            //Assert
            act.Should().NotThrow<InvalidCarAdException>();
            act.Should().NotThrow<InvalidOptionsException>();
        }

        [Fact]
        public void InvalidModelShouldThrowException()
        {
            //Act
            Action act = () => new CarAd(
                 make: new Make(name: "Subaru"),
                 model: "Twenty symbols is the max length!",
                 category: new Category(
                     name: "Saloon",
                     description: "Saloon, A.K.A sedans, has longer wheelbase than conventional family hatchback."),
                 imageUrl: "https://www.subaru.co.uk/",
                 pricePerDay: 50.00m,
                 options: new Options(
                     hasClimateControl: true,
                     seats: 5,
                     transmissionType: TransmissionType.Manual),
                 isAvailable: true);

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidImageUrlShouldThrowException() 
        {
            //Act
            Action act = () => new CarAd(
                 make: new Make(name: "Subaru"),
                 model: "Impreza",
                 category: new Category(
                     name: "Saloon",
                     description: "Saloon, A.K.A sedans, has longer wheelbase than conventional family hatchback."),
                 imageUrl: "Invalid url!",
                 pricePerDay: 50.00m,
                 options: new Options(
                     hasClimateControl: true,
                     seats: 5,
                     transmissionType: TransmissionType.Manual),
                 isAvailable: true);

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidPricePerDayShouldThrowException()
        {
            //Act
            Action act = () => new CarAd(
                 make: new Make(name: "Subaru"),
                 model: "Impreza",
                 category: new Category(
                     name: "Saloon",
                     description: "Saloon, A.K.A sedans, has longer wheelbase than conventional family hatchback."),
                 imageUrl: "https://www.subaru.co.uk/",
                 pricePerDay: -10.00m,
                 options: new Options(
                     hasClimateControl: true,
                     seats: 5,
                     transmissionType: TransmissionType.Manual),
                 isAvailable: true);

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void ChangeAvailabilityShouldMutateIsAvailable()
        {
            //Arrange
            var carAd = new CarAd(
                 make: new Make(name: "Subaru"),
                 model: "Impreza",
                 category: new Category(
                     name: "Saloon",
                     description: "Saloon, A.K.A sedans, has longer wheelbase than conventional family hatchback."),
                 imageUrl: "https://www.subaru.co.uk/",
                 pricePerDay: 50.00m,
                 options: new Options(
                     hasClimateControl: true,
                     seats: 5,
                     transmissionType: TransmissionType.Manual),
                 isAvailable: true);

            //Act
            carAd.ChangeAvailability();

            //Assert
            carAd.IsAvailable.Should().BeFalse();
        }
    }
}
