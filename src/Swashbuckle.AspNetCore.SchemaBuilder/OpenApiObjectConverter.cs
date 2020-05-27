using System;
using System.Collections;
using System.Reflection;
using Microsoft.OpenApi.Any;

namespace Swashbuckle.AspNetCore.SchemaBuilder
{
    public class OpenApiObjectConverter
    {
        private readonly SchemaSettings _settings;

        public OpenApiObjectConverter(SchemaSettings settings)
        {
            _settings = settings;
        }

        public OpenApiObject Convert(object o)
        {
            var t = o.GetType();
            var properties = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var openApiObject = new OpenApiObject();
            foreach (var property in properties)
            {
                var value = property.GetValue(o);

                ConvertRec(GetName(property.Name), value, property.PropertyType, openApiObject);
            }

            return openApiObject;
        }

        private void ConvertRec(string name, object value, Type type, OpenApiObject openApiObject)
        {
            if (type.IsArray)
            {
                var nestedType = type.GetElementType();
                CreateArrayOrListObject(name, value, type, nestedType, openApiObject);
            }
            else if (type.IsListType())
            {
                var nestedType = type.GetGenericArguments()[0];
                CreateArrayOrListObject(name, value, type, nestedType, openApiObject);
            }
            else if (!type.IsSimpleType())
            {
                if (value == null)
                {
                    openApiObject.Add(name, new OpenApiNull());
                    return;
                }

                var node = new OpenApiObject();

                foreach (var property in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    var itemValue = property.GetValue(value);

                    ConvertRec(GetName(property.Name), itemValue, property.PropertyType, node);
                }

                openApiObject.Add(name, node);
            }
            else
            {
                var node = CreateOpenApiObject(type, value);
                openApiObject.Add(name, node);
            }
        }

        private void CreateArrayOrListObject(string name, object value, Type type, Type nestedType,
            OpenApiObject openApiObject)
        {
            if (value == null)
            {
                openApiObject.Add(name, new OpenApiNull());
                return;
            }

            var arrayObject = new OpenApiArray();
            foreach (var item in value as IEnumerable)
            {
                if (nestedType.IsSimpleType())
                {
                    var node = CreateOpenApiObject(nestedType, item);
                    arrayObject.Add(node);
                }
                else
                {
                    var arrayItemObject = new OpenApiObject();
                    var properties = nestedType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var property in properties)
                    {
                        var nodeValue = property.GetValue(item);
                        ConvertRec(GetName(property.Name), nodeValue, property.PropertyType, arrayItemObject);
                    }

                    arrayObject.Add(arrayItemObject);
                }
            }

            openApiObject.Add(GetName(name), arrayObject);
        }

        private IOpenApiAny CreateOpenApiObject(Type type, object value)
        {
            if (value == null)
            {
                return new OpenApiNull();
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var nestedType = type.GetGenericArguments()[0];
                var node = CreateOpenApiObject(nestedType, value);
                return node;
            }

            if (type.IsEnum)
            {
                return new OpenApiString(value.ToString());
            }

            if (type == typeof(string))
            {
                return new OpenApiString(value.ToString());
            }

            if (type == typeof(int))
            {
                return new OpenApiInteger(System.Convert.ToInt32(value));
            }

            if (type == typeof(DateTime))
            {
                return new OpenApiDateTime(System.Convert.ToDateTime(value));
            }

            if (type == typeof(DateTimeOffset))
            {
                return new OpenApiDateTime((DateTimeOffset) value);
            }

            if (type == typeof(long))
            {
                return new OpenApiLong(System.Convert.ToInt64(value));
            }

            if (type == typeof(Int64))
            {
                return new OpenApiLong(System.Convert.ToInt64(value));
            }

            if (type == typeof(Single))
            {
                return new OpenApiDouble(System.Convert.ToSingle(value));
            }

            if (type == typeof(decimal))
            {
                return new OpenApiDouble(System.Convert.ToDouble(value));
            }

            if (type == typeof(double))
            {
                return new OpenApiDouble(System.Convert.ToDouble(value));
            }

            if (type == typeof(bool))
            {
                return new OpenApiBoolean(System.Convert.ToBoolean(value));
            }

            if (type == typeof(byte))
            {
                return new OpenApiByte((byte) value);
            }

            return new OpenApiNull();
        }

        private string GetName(string original)
        {
            return _settings.CamelCase ? original.FirstLower() : original;
        }
    }
}