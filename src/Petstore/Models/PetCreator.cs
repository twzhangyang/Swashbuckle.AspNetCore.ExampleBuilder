using System;
using System.Collections.Generic;
using System.Text;

namespace Petstore.Models
{
    public class PetCreator
    {
        public Pet Create()
        {
            var pet = new Pet
            {
                Id = 123,
                Name = "dog",
                BinaryValue = Encoding.UTF8.GetBytes("hello"),
                ByteValue = new byte(),
                DecimalValue = 123.12m,
                DoubleValue = 123.12d,
                FloatValue = 123.1f,
                Int64Value = 123,
                IntValue = 123,
                IsDog = false,
                NullValue = null,
                DateTimeValue = DateTime.Now.Date,
                DateTimeOffsetValue = DateTimeOffset.Now,
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
                    new Tag {Id = 2222, Name = "tag2"}
                }
            };

            // pet.DictionaryValue.Add("a", "b");
            return pet;
        }
    }
}