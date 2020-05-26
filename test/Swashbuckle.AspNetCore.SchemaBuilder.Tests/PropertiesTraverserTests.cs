using FluentAssertions;
using NUnit.Framework;
using Swashbuckle.AspNetCore.SchemaBuilder.Tests.Models;

namespace Swashbuckle.AspNetCore.SchemaBuilder.Tests
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
            graph.SimpleValueProperties.Count.Should().Be(14);
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

        [Test]
        public void ShouldGetObjectProperties()
        {
            //Arrange
            var pet = new PetCreator().Create();

            //Act
            var graph = new PropertiesTraverser(pet).Walk();

            //Assert
            graph.ObjectProperties[0].PropertyName.Should().Be("Category");

            graph.ObjectProperties[0].SimpleValueProperties[0].PropertyName.Should().Be("Id");
            graph.ObjectProperties[0].SimpleValueProperties[0].PropertyType.Should().Be(typeof(long));
            graph.ObjectProperties[0].SimpleValueProperties[0].PropertyValue.Should().Be(1234);

            graph.ObjectProperties[0].SimpleValueProperties[1].PropertyName.Should().Be("Name");
            graph.ObjectProperties[0].SimpleValueProperties[1].PropertyType.Should().Be(typeof(string));
            graph.ObjectProperties[0].SimpleValueProperties[1].PropertyValue.Should().Be("Animal");

            graph.ObjectProperties[0].ArrayProperties.Should().HaveCount(0);
            graph.ObjectProperties[0].ObjectProperties.Should().HaveCount(0);
        }

        [Test]
        public void ShouldGetArrayProperties()
        {
            //Arrange
            var pet = new PetCreator().Create();

            //Act
            var graph = new PropertiesTraverser(pet).Walk();
            
            //Assert
            graph.ArrayProperties.ContainsKey("PhotoUrls").Should().BeTrue();
            var photoUrls = graph.ArrayProperties["PhotoUrls"];
            photoUrls.Should().HaveCount(2);
            photoUrls[0].SimpleValueProperties.Should().HaveCount(1);
            photoUrls[0].SimpleValueProperties[0].PropertyName.Should().BeNull();
            photoUrls[0].SimpleValueProperties[0].PropertyType.Should().Be(typeof(string));
            photoUrls[0].SimpleValueProperties[0].PropertyValue.Should().Be("www.photo1.com");

            photoUrls[1].SimpleValueProperties.Should().HaveCount(1);
            photoUrls[1].SimpleValueProperties[0].PropertyName.Should().BeNull();
            photoUrls[1].SimpleValueProperties[0].PropertyType.Should().Be(typeof(string));
            photoUrls[1].SimpleValueProperties[0].PropertyValue.Should().Be("www.photo2.com");
            
            //tag
            graph.ArrayProperties.ContainsKey("Tags").Should().BeTrue();
            var tags = graph.ArrayProperties["Tags"];
            tags.Should().HaveCount(2);
            tags[0].ObjectProperties.Should().HaveCount(1);
            tags[0].ObjectProperties[0].SimpleValueProperties.Should().HaveCount(4);
            tags[0].ObjectProperties[0].SimpleValueProperties[0].PropertyName.Should().Be("Id");
            tags[0].ObjectProperties[0].SimpleValueProperties[0].PropertyType.Should().Be(typeof(long));
            tags[0].ObjectProperties[0].SimpleValueProperties[0].PropertyValue.Should().Be(1111);
        }
    }
}