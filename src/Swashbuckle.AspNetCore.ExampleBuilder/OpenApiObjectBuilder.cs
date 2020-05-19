using System;
using System.Reflection;
using Microsoft.OpenApi.Any;

namespace Swashbuckle.AspNetCore.ExampleBuilder
{
    public class OpenApiObjectBuilder : IOpenApiObjectBuilder
    {
        public OpenApiObject Build(object o)
        {
            var propertiesGraph = new PropertiesTraverser(o).Walk();
            var openApiObject = new OpenApiObject();

            new PropertiesGraphTransform().TransformToOpenApiObject(propertiesGraph, openApiObject, null);

            return openApiObject;
        }
    }
}