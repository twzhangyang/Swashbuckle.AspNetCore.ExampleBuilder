using System;
using System.Linq;
using Microsoft.OpenApi.Any;

namespace Swashbuckle.AspNetCore.ExampleBuilder
{
    public class PropertiesGraphTransform
    {
        public void TransformToOpenApiObject(PropertiesGraph graph, OpenApiObject root, OpenApiArray openApiArray)
        {
            foreach (var property in graph.SimpleValueProperties)
            {
                var openApiAny = GetOpenApiType(property);
                var name = property.PropertyName;

                root.Add(name, openApiAny);
            }

            foreach (var property in graph.ObjectProperties)
            {
                var item = new OpenApiObject();
                TransformToOpenApiObject(property, item, openApiArray);
                if (root == null)
                {
                    openApiArray.Add(item);
                }
                else
                {
                    root.Add(property.PropertyName, item);
                }
            }

            foreach (var arrayProperty in graph.ArrayProperties)
            {
                var items = new OpenApiArray();
                foreach (var property in arrayProperty.Value)
                {
                    if (property.PropertyType.IsSimpleType())
                    {
                        var propertyItem = property.SimpleValueProperties.First();
                        var openApiAny = GetOpenApiType(propertyItem);
                        items.Add(openApiAny);
                    }
                    else
                    {
                        TransformToOpenApiObject(property, null, items);
                    }
                }

                root.Add(arrayProperty.Key, items);
            }
        }

        private IOpenApiAny GetOpenApiType(PropertiesGraph.Property property)
        {
            var t = property.PropertyType;
            var value = property.PropertyValue;

            if (value == null)
            {
                return new OpenApiNull();
            }

            if (t.IsEnum)
            {
                return new OpenApiString(value.ToString());
            }

            if (t == typeof(string))
            {
                return new OpenApiString(value.ToString());
            }

            if (t == typeof(int))
            {
                return new OpenApiInteger(Convert.ToInt32(value));
            }

            if (t == typeof(DateTime))
            {
                return new OpenApiDateTime(Convert.ToDateTime(value));
            }

            if (t == typeof(long))
            {
                return new OpenApiLong(Convert.ToInt64(value));
            }

            if (t == typeof(Int64))
            {
                return new OpenApiLong(Convert.ToInt64(value));
            }

            if (t == typeof(decimal))
            {
                return new OpenApiDouble(Convert.ToDouble(value));
            }

            if (t == typeof(double))
            {
                return new OpenApiDouble(Convert.ToDouble(value));
            }

            if (t == typeof(bool))
            {
                return new OpenApiBoolean(Convert.ToBoolean(value));
            }

            if (t == typeof(byte))
            {
                return new OpenApiByte(Convert.ToByte(value));
            }

            return new OpenApiObject();
        }
    }
}