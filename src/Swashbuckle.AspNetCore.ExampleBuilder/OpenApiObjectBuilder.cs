using System;
using System.Reflection;
using Microsoft.OpenApi.Any;

namespace Swashbuckle.AspNetCore.ExampleBuilder
{
    public class OpenApiObjectBuilder : IOpenApiObjectBuilder
    {
        private readonly PropertiesGraphTransformer _graphTransformer;

        public OpenApiObjectBuilder(PropertiesGraphTransformer graphTransformer)
        {
            _graphTransformer = graphTransformer;
        }
        
        public OpenApiObject Build(object o)
        {
            var propertiesGraph = new PropertiesTraverser(o).Walk();
            var openApiObject = new OpenApiObject();

            _graphTransformer.TransformToOpenApiObject(propertiesGraph, openApiObject, null);

            return openApiObject;
        }
    }
}