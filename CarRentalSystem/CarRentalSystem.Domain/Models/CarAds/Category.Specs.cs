using CarRentalSystem.Domain.Exceptions;
using FluentAssertions;
using System;
using System.Security.Cryptography;
using Xunit;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class CategorySpecs
    {
        [Fact]
        public void ValidCategoryShouldNotThrowException()
        {
            //Act
            Action act = () => new Category(
                name: "Saloon",
                description: "Saloon, A.K.A sedans, has longer wheelbase than conventional family hatchback.");

            //Assert
            act.Should().NotThrow<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            //Act
            Action act = () => new Category(
                name: "",
                description: "It is a valid description.");

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidDescriptionShouldThrowException()
        {
            //Act
            Action act = () => new Category(
                name: "Valid name.",
                description: "");

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }
    }
}
