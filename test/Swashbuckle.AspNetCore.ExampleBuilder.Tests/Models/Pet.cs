using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Swashbuckle.AspNetCore.ExampleBuilder.Tests.Models
{
    public class Pet
    {
        public long? Id { get; set; }

        public Category Category { get; set; }

        [Required] public string Name { get; set; }
        
        public StatusEnum? Status { get; set; }

        [Required] public List<string> PhotoUrls { get; set; }

        public List<Tag> Tags { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "available")] AvailableEnum = 1,

            [EnumMember(Value = "pending")] PendingEnum = 2,

            [EnumMember(Value = "sold")] SoldEnum = 3
        }

    }
}