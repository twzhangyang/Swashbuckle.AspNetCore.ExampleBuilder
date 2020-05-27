using System.Linq;
using FluentAssertions;
using Microsoft.OpenApi.Any;
using NUnit.Framework;

namespace Swashbuckle.AspNetCore.SchemaBuilder.Tests
{
    public class OpenApiObjectConverterTest2
    {
        [Test]
        public void ShouldConvertObjectProperty()
        {
            //Arrange
            var pet = new Pet();
            var converter = new OpenApiObjectConverter(new SchemaSettings());
            
            //Act
            var openApiObject = converter.Convert(pet);
            
            //Assert
            openApiObject.Keys.Contains("name");
            openApiObject.Keys.Contains("id");
            openApiObject.Keys.Contains("owner");

            var name = (OpenApiString) openApiObject["name"];
            name.PrimitiveType.Should().Be(PrimitiveType.String);
            name.Value.Should().Be("dog");

            var id = (OpenApiInteger) openApiObject["id"];
            id.PrimitiveType.Should().Be(PrimitiveType.Integer);
            id.Value.Should().Be(100);
            
            //Owner
            var owner = (OpenApiObject) openApiObject["owner"];
            owner.Keys.Contains("family");
            owner.Keys.Contains("address");
            owner.Keys.Contains("ownerFavorite");

            var family = (OpenApiString) owner["family"];
            family.PrimitiveType.Should().Be(PrimitiveType.String);
            family.Value.Should().Be("family1"); 

            var address = (OpenApiString) owner["address"];
            address.PrimitiveType.Should().Be(PrimitiveType.String);
            address.Value.Should().Be("address1"); 
            
            //Favorite
            var favorite = (OpenApiObject)owner["ownerFavorite"];
            favorite.Keys.Contains("name");
            favorite.Keys.Contains("category");

            var favoriteName = (OpenApiString) favorite["name"];
            favoriteName.PrimitiveType.Should().Be(PrimitiveType.String);
            favoriteName.Value.Should().Be("name1");

            var favoriteCategory = (OpenApiString) favorite["category"];
            favoriteCategory.Value.Should().Be("category1");
        }

        private class Pet
        {
            public Pet()
            {
                Name = "dog";
                Id = 100;
                Owner = new Person();
            }

            public string Name { get; set; }

            public int Id { get; set; }

            public Person Owner { get; set; }

            public class Person
            {
                public Person()
                {
                    Family = "family1";
                    Address = "address1";
                    OwnerFavorite = new Favorite();
                }

                public string Family { get; set; }

                public string Address { get; set; }

                public Favorite OwnerFavorite { get; set; }

                public class Favorite
                {
                    public Favorite()
                    {
                        Name = "name1";
                        Category = "category1";
                    }

                    public string Name { get; set; }

                    public string Category { get; set; }
                }
            }
        }
    }
}