using System.Collections.Generic;
using NUnit.Framework;

namespace Swashbuckle.AspNetCore.SchemaBuilder.Tests.Models
{
    public class Tag
    {
        public long? Id { get; set; }

        public string Name { get; set; }
        
        public List<Item> Items { get; set; }
        
        public Item Item { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }
        
        public string Value { get; set; }
    }
}