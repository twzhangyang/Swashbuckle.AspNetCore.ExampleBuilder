using System;
using System.Reflection;
using Microsoft.OpenApi.Any;

namespace Swashbuckle.AspNetCore.SchemaBuilder
{
    public class OpenApiObjectBuilder : IOpenApiObjectBuilder
    {
        private readonly OpenApiObjectConverter _converter;

        public OpenApiObjectBuilder(OpenApiObjectConverter converter)
        {
            _converter = converter;
        }
        
        public OpenApiObject Build(object o)
        {
            return _converter.Convert(o);
        }
    }
}