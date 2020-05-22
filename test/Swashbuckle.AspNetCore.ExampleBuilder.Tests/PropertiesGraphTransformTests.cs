using System.Linq;
using FluentAssertions;
using Microsoft.OpenApi.Any;
using NUnit.Framework;
using Swashbuckle.AspNetCore.ExampleBuilder.Tests.Models;

namespace Swashbuckle.AspNetCore.ExampleBuilder.Tests
{
    public class PropertiesGraphTransformTests
    {
        [Test]
        public void ShouldCreateOpenApiObject()
        {
            //Arrange
            var pet = new PetCreator().Create();
            
            var graph = new PropertiesTraverser(pet).Walk();
            var root = new OpenApiObject();

            //Act
            new PropertiesGraphTransformer(new ExampleSettings()).TransformToOpenApiObject(graph, root, null);

            //Assert
            root.Count.Should().Be(6);
            root.Keys.Contains("id");
            root.Keys.Contains("name");
            root.Keys.Contains("status");
            root.Keys.Contains("category");
            root.Keys.Contains("tags");
            root.Keys.Contains("photoUrls");
        }
    }
}