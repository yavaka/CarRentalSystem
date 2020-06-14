using CarRentalSystem.Domain.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class MakeSpecs
    {
        [Fact]
        public void ValidMakeShouldNotThrowException() 
        {
            //Act
            Action act = () => new Make(name: "Subaru");

            //Assert
            act.Should().NotThrow<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidMakeShouldThrowException()
        {
            //Act
            Action act = () => new Make(name: "");

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }
    }
}
