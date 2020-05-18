using FluentAssertions;
using NUnit.Framework;

namespace Swashbuckle.AspNetCore.ExampleBuilder.Tests
{
    public class PropertiesWalkerTests
    {
        [Test]
        public void ShouldWalkThroughPet()
        {
            //Arrange
            var pet = new PetCreator().Create();

            //Act
            var graph = new PropertiesWalker(pet).Walk();

            //Assert
            graph.ArrayProperties.Count.Should().Be(2);
            graph.ObjectProperties.Count.Should().Be(1);
            graph.SimpleValueProperties.Count.Should().Be(3);
        }
    }
}