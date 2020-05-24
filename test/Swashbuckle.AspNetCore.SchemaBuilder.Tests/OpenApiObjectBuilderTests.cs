using System.Collections.Generic;
using NUnit.Framework;
using Swashbuckle.AspNetCore.SchemaBuilder.Tests.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swashbuckle.AspNetCore.SchemaBuilder.Tests
{
    public class OpenApiObjectBuilderTests
    {
        [Test]
        public void ShouldBuildOpenApiObject()
        {
            //Arrange
            var pet = new PetCreator().Create();
            
            //Act
            var openApiObject = new OpenApiObjectBuilder(new PropertiesGraphTransformer(new SchemaSettings())).Build(pet);
            
            //Assert
            Assert.AreEqual(openApiObject.Count, 6);
        }
    }
}