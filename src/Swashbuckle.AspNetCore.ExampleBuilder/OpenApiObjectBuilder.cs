using System;
using System.Reflection;
using Microsoft.OpenApi.Any;

namespace Swashbuckle.AspNetCore.ExampleBuilder
{
    public class OpenApiObjectBuilder : IOpenApiObjectBuilder
    {
        public OpenApiObject Build(object o)
        {
            if (!o.GetType().IsClass)
            {
                throw new ArgumentException("waiting for input a class object");
            }

            var properties = o.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            
            return new OpenApiObject()
            {
                ["hell"] = new OpenApiString("hello")
            }; 
        }
    }
}