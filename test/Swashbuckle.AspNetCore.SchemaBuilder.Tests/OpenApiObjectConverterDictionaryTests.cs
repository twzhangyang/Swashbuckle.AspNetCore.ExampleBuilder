using System.Collections.Generic;
using NUnit.Framework;

namespace Swashbuckle.AspNetCore.SchemaBuilder.Tests
{
    public class OpenApiObjectConverterDictionaryTests
    {
        [Test]
        public void ShouldConvertDictionary()
        {
            //Arrange
            var pet = new Pet();
            var converter = new OpenApiObjectConverter(new SchemaSettings());
            
            //Act
            var apiObject = converter.Convert(pet);
            
            //Assert
        }

        private class Pet
        {
            public Pet()
            {
                Items = new Dictionary<int, string>();
                
                Items.Add(1, "hello");
            }

            public Dictionary<int, string> Items { get; set; }
        }
    }
}