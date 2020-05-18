using FluentAssertions;
using Microsoft.OpenApi.Any;
using NUnit.Framework;

namespace Swashbuckle.AspNetCore.ExampleBuilder.Tests
{
    public class PropertiesGraphTraverserTests
    {
        [Test]
       public void ShouldCreateOpenApiObject()
       {
           //Arrange
           var pet = new PetCreator().Create(); 
           var propertiesGraph = new PropertiesWalker(pet).Walk();
           var root = new OpenApiObject();
           
           //Act
           new PropertiesGraphTraverser().TraverseProperty(propertiesGraph, root);
           
           //Assert
           root.Count.Should().NotBe(0);
       } 
    }
}