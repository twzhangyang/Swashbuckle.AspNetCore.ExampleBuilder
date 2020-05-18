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
            var pet = new Pet
            {
                Id = 123,
                Name = "dog",
                Category = new Category
                {
                    Id = 1234,
                    Name = "Animal",
                },
                PhotoUrls = new List<string>
                {
                    "www.photo1.com",
                    "www.photo2.com"
                },
                Status = Pet.StatusEnum.AvailableEnum,
                Tags = new List<Tag>
                {
                    new Tag {Id = 1111, Name = "tag1"},
                    new Tag {Id = 222, Name = "tag2"}
                }
            };
            
            //Act
            var openApiObject = new OpenApiObjectBuilder().Build(pet);
            
            //Assert
            Assert.AreEqual(openApiObject.Count, 1);
        }
    }
}