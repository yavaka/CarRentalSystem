using CarRentalSystem.Domain.Models.CarAds;
using FluentAssertions;
using Xunit;

namespace CarRentalSystem.Domain.Common
{
    public class EntitySpecs
    {
        [Fact]
        public void EntitiesWithEqualIdsShouldBeEqual() 
        {
            //Arrange
            var first = new Make(name: "Subaru Impreza").SetId(1);
            var second = new Make(name: "Subaru Legacy").SetId(1);

            //Act
            var result = first == second;

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithDifferentIdsShouldNotBeEqual()
        {
            //Arrange
            var first = new Make(name: "Subaru Impreza").SetId(1);
            var second = new Make(name: "Mercedes E63").SetId(2);

            //Act
            var result = first == second;

            //Assert
            result.Should().BeFalse();
        }
    }

    internal static class EntityExtensions
    {
        //This method is used for test cases only
        public static Entity<T> SetId<T>(this Entity<T> entity, int id)
            where T : struct
        {
            entity
                .GetType()
                .BaseType!
                .GetProperty(nameof(Entity<T>.Id))!
                .GetSetMethod(true)!
                .Invoke(entity, new object[] { id });

            return entity;
        }
    }
}
