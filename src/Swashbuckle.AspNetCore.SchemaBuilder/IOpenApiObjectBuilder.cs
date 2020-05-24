using Microsoft.OpenApi.Any;

namespace Swashbuckle.AspNetCore.SchemaBuilder
{
    public interface IOpenApiObjectBuilder
    {
        OpenApiObject Build(object o);
    }
}