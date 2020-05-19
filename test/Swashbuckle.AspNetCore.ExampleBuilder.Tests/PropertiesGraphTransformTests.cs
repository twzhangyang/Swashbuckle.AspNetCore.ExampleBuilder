using FluentAssertions;
using Microsoft.OpenApi.Any;
using NUnit.Framework;

namespace Swashbuckle.AspNetCore.ExampleBuilder.Tests
{
    public class PropertiesGraphTransformTests
    {
        [Test]
       public void ShouldCreateOpenApiObject()
       {
           //Arrange
           var pet = new PetCreator().Create(); 
           var propertiesGraph = new PropertiesTraverser(pet).Walk();
           var root = new OpenApiObject();
           
           //Act
           new PropertiesGraphTransform().TransformToOpenApiObject(propertiesGraph, root);
           
           //Assert
           root.Count.Should().NotBe(0);
       } 
    }
}