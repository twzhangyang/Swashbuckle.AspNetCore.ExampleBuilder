using System.Collections.Generic;
using NUnit.Framework;
using Swashbuckle.AspNetCore.ExampleBuilder.Tests.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swashbuckle.AspNetCore.ExampleBuilder.Tests
{
    public class OpenApiObjectBuilderTests
    {
        [Test]
        public void ShouldBuildOpenApiObject()
        {
            //Arrange
            var pet = new PetCreator().Create();
            
            //Act
            var openApiObject = new OpenApiObjectBuilder().Build(pet);
            
            //Assert
            Assert.AreEqual(openApiObject.Count, 6);
        }
    }
}