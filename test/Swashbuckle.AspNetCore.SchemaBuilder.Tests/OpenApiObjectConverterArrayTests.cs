using NUnit.Framework;

namespace Swashbuckle.AspNetCore.SchemaBuilder.Tests
{
    public class OpenApiObjectConverterArrayTests
    {
        [Test]
        public void ShouldConvertArray()
        {
            //Arrange
            var pet = new Pet();
            var converter = new OpenApiObjectConverter(new SchemaSettings());

            //Act
            var openApiObject = converter.Convert(pet);

            //Assert
        }

        private class Pet
        {
            public int[] Numbers { get; set; }
        }
    }
}