using FluentAssertions;
using NUnit.Framework;
using Swashbuckle.AspNetCore.ExampleBuilder.Tests.Models;

namespace Swashbuckle.AspNetCore.ExampleBuilder.Tests
{
    public class PropertiesTraverserTests
    {
        [Test]
        public void ShouldGetAllPropertiesForPet()
        {
            //Arrange
            var pet = new PetCreator().Create();

            //Act
            var graph = new PropertiesTraverser(pet).Walk();

            //Assert
            graph.ArrayProperties.Count.Should().Be(2);
            graph.ObjectProperties.Count.Should().Be(1);
            graph.SimpleValueProperties.Count.Should().Be(3);
        }
        
        [Test]
        public void ShouldGetSimpleValueProperties()
        {
            //Arrange
            var pet = new PetCreator().Create();
            
            //Act
            var graph = new PropertiesTraverser(pet).Walk();
            
            //Assert
            graph.SimpleValueProperties[0].PropertyName.Should().Be("Id");
            graph.SimpleValueProperties[0].PropertyType.Should().Be(typeof(long));
            graph.SimpleValueProperties[0].PropertyValue.Should().Be(123);

            graph.SimpleValueProperties[1].PropertyName.Should().Be("Name");
            graph.SimpleValueProperties[1].PropertyType.Should().Be(typeof(string));
            graph.SimpleValueProperties[1].PropertyValue.Should().Be("dog");

            graph.SimpleValueProperties[2].PropertyName.Should().Be("Status");
            graph.SimpleValueProperties[2].PropertyType.Should().Be(typeof(Pet.StatusEnum));
            graph.SimpleValueProperties[2].PropertyValue.Should().Be(Pet.StatusEnum.AvailableEnum);

        }
    }
}