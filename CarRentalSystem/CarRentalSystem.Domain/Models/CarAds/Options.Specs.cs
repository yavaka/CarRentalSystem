using CarRentalSystem.Domain.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class OptionsSpecs
    {
        [Fact]
        public void ValidOptionsShouldNotThrowException() 
        {
            //Act
            Action act = () => new Options(
                hasClimateControl: true,
                seats: 5,
                transmissionType: TransmissionType.Manual);

            act.Should().NotThrow<InvalidOptionsException>();
        }

        [Fact]
        public void InvalidOptionsShouldThrowException()
        {
            //Act
            Action act = () => new Options(
                hasClimateControl: true,
                seats: 22,
                transmissionType: TransmissionType.Manual);

            act.Should().Throw<InvalidOptionsException>();
        }
    }
}
