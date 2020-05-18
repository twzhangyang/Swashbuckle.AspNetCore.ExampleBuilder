using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swashbuckle.AspNetCore.ExampleBuilder.Tests.Models
{
    public class PetSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                ["id"] = new OpenApiLong(123),
                ["name"] = new OpenApiString("food"),
                ["photoUrls"] = new OpenApiArray()
                {
                    new OpenApiString("http://photo1.com"),
                    new OpenApiString("http://photo2.com")
                },
                ["category"] = new OpenApiObject()
                {
                    ["name"] = new OpenApiString("food"),
                    ["id"] = new OpenApiLong(1234)
                },
                ["tags"] = new OpenApiArray()
                {
                    new OpenApiObject()
                    {
                        ["name"] = new OpenApiString("tag1"),
                        ["id"] = new OpenApiLong(111)
                    },
                    new OpenApiObject()
                    {
                        ["name"] = new OpenApiString("tag2"),
                        ["id"] = new OpenApiLong(222)
                    }
                },
                ["status"] = new OpenApiString(Pet.StatusEnum.AvailableEnum.ToString())
            };
        }
    }
}