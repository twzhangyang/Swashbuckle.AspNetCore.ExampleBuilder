using System.Collections.Generic;
using Swashbuckle.AspNetCore.ExampleBuilder.Tests.Models;

namespace Swashbuckle.AspNetCore.ExampleBuilder.Tests
{
    public class PetCreator
    {
        public Pet Create()
        {
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
                    new Tag {Id = 2222, Name = "tag2"}
                }
            };
            return pet;
        }
    }
}