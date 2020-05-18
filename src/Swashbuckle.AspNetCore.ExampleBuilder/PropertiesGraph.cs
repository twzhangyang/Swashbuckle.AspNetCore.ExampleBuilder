using System;
using System.Collections.Generic;

namespace Swashbuckle.AspNetCore.ExampleBuilder
{
    public class PropertiesGraph
    {
        public PropertiesGraph(string name, object value, Type t)
        {
            ObjectProperties = new List<PropertiesGraph>();
            SimpleValueProperties = new List<Property>();
            ArrayProperties = new Dictionary<string, List<PropertiesGraph>>();
            PropertyName = name;
            PropertyType = t;
            PropertyValue = value;
        }
        
        public string PropertyName { get; private set; }

        public Type PropertyType { get; private set; }

        public object PropertyValue { get; private set; }
        
        public List<PropertiesGraph> ObjectProperties { get; private set; }
        
        public List<Property> SimpleValueProperties { get; private set; }
        
        public Dictionary<string, List<PropertiesGraph>> ArrayProperties { get; private set; }

        public void AddArrayProperty(string name, PropertiesGraph item)
        {
            if(!ArrayProperties.ContainsKey(name))
            {
                ArrayProperties[name] = new List<PropertiesGraph>();
            }
            
            ArrayProperties[name].Add(item);
        }
        
        public void AddSimpleValueProperty(string name, object value, Type t)
        {
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                t = t.GetGenericArguments()[0];
            }
            
            SimpleValueProperties.Add(new Property(name, value, t));
        }

        public class Property
        {
            public Property(string name, object value, Type t)
            {
                PropertyName = name;
                PropertyType = t;
                PropertyValue = value;
            }
            
            public string PropertyName { get; private set; }

            public Type PropertyType { get; private set; }

            public object PropertyValue { get; private set; }
        }
    }
}