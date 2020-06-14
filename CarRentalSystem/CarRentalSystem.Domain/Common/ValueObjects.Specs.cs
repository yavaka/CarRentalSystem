using CarRentalSystem.Domain.Models.CarAds;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CarRentalSystem.Domain.Common
{
    public class ValueObjectsSpecs
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual() 
        {
            //Arrange
            var first = new Options(
                hasClimateControl: true,
                seats: 4,
                transmissionType: TransmissionType.Manual);

            var second = new Options(
                hasClimateControl: true,
                seats: 4,
                transmissionType: TransmissionType.Manual);

            //Act
            var result = first == second;

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            //Arrange
            var first = new Options(
                hasClimateControl: true,
                seats: 2,
                transmissionType: TransmissionType.Manual);

            var second = new Options(
                hasClimateControl: true,
                seats: 4,
                transmissionType: TransmissionType.Manual);

            //Act
            var result = first == second;

            //Assert
            result.Should().BeFalse();
        }
    }
}
