using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using Microsoft.OpenApi.Any;
using Newtonsoft.Json;
using NUnit.Framework;
using Swashbuckle.AspNetCore.SchemaBuilder.Tests.Models;

namespace Swashbuckle.AspNetCore.SchemaBuilder.Tests
{
    public class OpenApiObjectConverterSimpleTypeTests
    {
        [Test]
        public void ShouldConvertStringType()
        {
            //Arrange
            var pet = new
            {
                name = "Pet",
            };

            var converter = new OpenApiObjectConverter(new SchemaSettings());

            //Act
            var openApiObject = converter.Convert(pet);

            //Assert
            openApiObject.Keys.First().Should().Be("name");
            openApiObject["name"].AnyType.Should().Be(AnyType.Primitive);
            openApiObject["name"].GetType().Should().Be(typeof(OpenApiString));

            var stringObject = (OpenApiString) openApiObject["name"];
            stringObject.Value.Should().Be("Pet");
        }

        [Test]
        public void ShouldConvertIntType()
        {
            //Arrange
            var pet = new
            {
                id = 1,
            };

            var converter = new OpenApiObjectConverter(new SchemaSettings());

            //Act
            var openApiObject = converter.Convert(pet);

            //Assert
            openApiObject.Keys.First().Should().Be("id");
            openApiObject["id"].AnyType.Should().Be(AnyType.Primitive);
            openApiObject["id"].GetType().Should().Be(typeof(OpenApiInteger));

            var stringObject = (OpenApiInteger) openApiObject["id"];
            stringObject.Value.Should().Be(1);
        }

        [Test]
        public void ShouldConvertEnumType()
        {
            //Arrange
            var pet = new
            {
                status = Pet.StatusEnum.AvailableEnum
            };

            var converter = new OpenApiObjectConverter(new SchemaSettings());

            //Act
            var openApiObject = converter.Convert(pet);

            //Assert
            openApiObject.Keys.First().Should().Be("status");
            openApiObject["status"].AnyType.Should().Be(AnyType.Primitive);
            openApiObject["status"].GetType().Should().Be(typeof(OpenApiString));

            var stringObject = (OpenApiString) openApiObject["status"];
            stringObject.Value.Should().Be("AvailableEnum");
        }

        [Test]
        public void ShouldConvertDateTimeType()
        {
            //Arrange
            var date = DateTime.Now;
            var pet = new
            {
                birthDay = date,
            };

            var converter = new OpenApiObjectConverter(new SchemaSettings());

            //Act
            var openApiObject = converter.Convert(pet);

            //Assert
            openApiObject.Keys.First().Should().Be("birthDay");
            openApiObject["birthDay"].AnyType.Should().Be(AnyType.Primitive);
            openApiObject["birthDay"].GetType().Should().Be(typeof(OpenApiDateTime));

            var stringObject = (OpenApiDateTime) openApiObject["birthDay"];
            stringObject.Value.Should().Be(date);
        }

        [Test]
        public void ShouldConvertDateTimeOffsetType()
        {
            //Arrange
            var date = DateTime.Now;
            var pet = new
            {
                birthDay = new DateTimeOffset(date),
            };

            var converter = new OpenApiObjectConverter(new SchemaSettings());

            //Act
            var openApiObject = converter.Convert(pet);

            //Assert
            openApiObject.Keys.First().Should().Be("birthDay");
            openApiObject["birthDay"].AnyType.Should().Be(AnyType.Primitive);
            openApiObject["birthDay"].GetType().Should().Be(typeof(OpenApiDateTime));

            var stringObject = (OpenApiDateTime) openApiObject["birthDay"];
            stringObject.Value.Should().Be(new DateTimeOffset(date));
        }

        [Test]
        public void ShouldConvertBoolType()
        {
            //Arrange
            var pet = new
            {
                isDog = true
            };

            var converter = new OpenApiObjectConverter(new SchemaSettings());

            //Act
            var openApiObject = converter.Convert(pet);

            //Assert
            openApiObject.Keys.First().Should().Be("isDog");
            openApiObject["isDog"].AnyType.Should().Be(AnyType.Primitive);
            openApiObject["isDog"].GetType().Should().Be(typeof(OpenApiBoolean));

            var stringObject = (OpenApiBoolean) openApiObject["isDog"];
            stringObject.Value.Should().Be(true);
        }

        [Test]
        public void ShouldConvertNullType()
        {
            //Arrange
            var pet = new NullPet();

            var converter = new OpenApiObjectConverter(new SchemaSettings());

            //Act
            var openApiObject = converter.Convert(pet);

            //Assert
            openApiObject.Keys.First().Should().Be("age");
            openApiObject["age"].AnyType.Should().Be(AnyType.Null);
            openApiObject["age"].GetType().Should().Be(typeof(OpenApiNull));
        }
        
        private class NullPet
        {
           public int? Age { get; set; } 
        }
    }
}