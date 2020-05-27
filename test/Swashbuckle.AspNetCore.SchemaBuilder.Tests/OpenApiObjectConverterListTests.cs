using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.OpenApi.Any;
using NUnit.Framework;

namespace Swashbuckle.AspNetCore.SchemaBuilder.Tests
{
    public class OpenApiObjectConverterListTests
    {
        [Test]
        public void ShouldConvertListProperty()
        {
           //Arrange
           var pet = new Pet();
           var converter = new OpenApiObjectConverter(new SchemaSettings());
           
           //Act
           var apiObject = converter.Convert(pet);
           
           //Assert
           apiObject.Keys.Contains("items");
           var items = (OpenApiArray) apiObject["items"];
           items.Count.Should().Be(3);
           
           //Item1
           var item1 = (OpenApiObject)items[0];
           item1.Keys.Contains("name");
           item1.Keys.Contains("id");
           item1.Keys.Contains("petCategory");
           item1.Keys.Contains("categories");

           var item1Name = (OpenApiString) item1["name"];
           item1Name.Value.Should().Be("name1");
           var item1Id = (OpenApiInteger) item1["id"];
           item1Id.Value.Should().Be(1);
           
           //Item1 petCategory
           var item1PetCategory = (OpenApiObject) item1["petCategory"];
           item1PetCategory.Keys.Contains("name");
           var item1PetCategoryName = (OpenApiString) item1PetCategory["name"];
           item1PetCategoryName.Value.Should().Be("category1");
           
           //Item1 categories
           var item1Categories = (OpenApiArray) item1["categories"];
           item1Categories.Count.Should().Be(1);
           var item1CategoriesItem1 = (OpenApiObject)item1Categories[0];
           var item1CategoriesItem1Name = (OpenApiString) item1CategoriesItem1["name"];
           item1CategoriesItem1Name.Value.Should().Be("categories-name1");
           
           //Item2
           var item2 = (OpenApiObject)items[1];
           var item2Name = (OpenApiString) item2["name"];
           item2Name.Value.Should().Be("name2");
           var item2Id = (OpenApiInteger) item2["id"];
           item2Id.Value.Should().Be(0); 

           var item2PetCategory = item2["petCategory"];
           item2PetCategory.AnyType.Should().Be(AnyType.Null);
           var item2Categories = (OpenApiArray) item2["categories"];
           item2Categories.Count.Should().Be(0);

           //Item3
           var item3 = (OpenApiObject)items[2];
           var item3Name = (OpenApiString) item3["name"];
           item3Name.Value.Should().Be("name3");
           var item3Id = (OpenApiInteger) item3["id"];
           item3Id.Value.Should().Be(0); 

           var item3PetCategory = item3["petCategory"];
           item3PetCategory.AnyType.Should().Be(AnyType.Null);
           var item3Categories = item3["categories"];
           item3Categories.AnyType.Should().Be(AnyType.Null);
        }
        
        private class Pet
        {
            public Pet()
            {
                Items = new List<Item>();
                Items.Add(new Item()
                {
                    Id = 1,
                    Name = "name1",
                    PetCategory = new Item.Category
                    {
                        Name = "category1",
                    },
                    Categories = new List<Item.Category>()
                    {
                        new Item.Category() {Name = "categories-name1"}
                    }
                });
                
                Items.Add(new Item()
                {
                    Name = "name2",
                    Categories = new List<Item.Category>()
                });
                
                Items.Add(new Item()
                {
                    Name = "name3",
                });
            }
            public List<Item> Items { get; set; }
            
           public class Item
           {
              public string Name { get; set; } 
              
              public int Id { get; set; }
              
              public Category PetCategory { get; set; }
              
              public List<Category> Categories { get; set; }
              
              public class Category
              {
                 public string Name { get; set; } 
              }
           }
        }
    }
}