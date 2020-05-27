using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Swashbuckle.AspNetCore.SchemaBuilder.Tests.Models
{
    public class Pet
    {
        public Pet()
        {
            // DictionaryValue = new Dictionary<int, string>();
            // DictionaryValue2 = new Dictionary<string, Category>();
        }
        
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
        
        
        public int IntValue { get; set; }
        
        public Int64 Int64Value { get; set; }
        
        public int? NullValue { get; set; }
        
        public bool IsDog { get; set; }
        
        public float FloatValue { get; set; }
        
        public Decimal DecimalValue { get; set; }
        
        public Double DoubleValue { get; set; } 
        
        public byte ByteValue { get; set; }

        // public byte[] BinaryValue { get; set; }
        
        public DateTime DateTimeValue { get; set; }
        
        public DateTimeOffset DateTimeOffsetValue { get; set; }
        
        // public Dictionary<int, string> DictionaryValue { get; set; }
        
        // public Dictionary<string, Category> DictionaryValue2 { get; set; } 
    }
}