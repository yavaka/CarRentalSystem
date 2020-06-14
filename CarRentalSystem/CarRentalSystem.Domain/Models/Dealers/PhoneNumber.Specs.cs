using CarRentalSystem.Domain.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CarRentalSystem.Domain.Models.Dealers
{
    public class PhoneNumberSpecs
    {
        [Fact]
        public void ValidPhoneNumberShouldNotThrowException() 
        {
            //Act
            Action act = () => new PhoneNumber("+123456789");

            //Assert
            act.Should().NotThrow<InvalidPhoneNumberException>();
        }

        [Fact]
        public void InvalidPhoneNumberFirstSymbolShouldThrowException() 
        {
            //Act
            Action act = () => new PhoneNumber("*12455647773");

            //Assert
            act.Should().Throw<InvalidPhoneNumberException>();
        }

        [Fact]
        public void InvalidPhoneNumberLengthShouldThrowException() 
        {
            //Act
            Action act = () => new PhoneNumber("");

            //Assert
            act.Should().Throw<InvalidPhoneNumberException>();
        }
    }
}
