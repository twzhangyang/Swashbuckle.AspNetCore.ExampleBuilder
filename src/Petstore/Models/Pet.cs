using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Petstore.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    // [SwaggerSchemaFilter(typeof(PetSchemaFilter))]
    // [SwaggerSchemaFilter(typeof(PetSchemaByBuilderFilter))]
    public partial class Pet
    {
        public Pet()
        {
            DictionaryValue = new Dictionary<int, string>();
            DictionaryValue2 = new Dictionary<int, Category>();
        }
        
        public long? Id { get; set; }
        
        public int IntValue { get; set; }
        
        public Int64 Int64Value { get; set; }
        
        public int? NullValue { get; set; }
        
        public bool IsDog { get; set; }
        
        public float FloatValue { get; set; }
        
        public Decimal DecimalValue { get; set; }
        
        public Double DoubleValue { get; set; } 
        
        public byte ByteValue { get; set; }

        public byte[] BinaryValue { get; set; }
        
        public DateTime DateTimeValue { get; set; }
        
        public DateTimeOffset DateTimeOffsetValue { get; set; }
        
        public Dictionary<int, string> DictionaryValue { get; set; }
        
        public Dictionary<int, Category> DictionaryValue2 { get; set; }

        [Required]
        public string Name { get; set; }
        
        public Category Category { get; set; }

        [Required]
        public List<string> PhotoUrls { get; set; }

        public List<Tag> Tags { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "available")] AvailableEnum = 1,

            [EnumMember(Value = "pending")] PendingEnum = 2,

            [EnumMember(Value = "sold")] SoldEnum = 3
        }
        public StatusEnum? Status { get; set; }
    }
}