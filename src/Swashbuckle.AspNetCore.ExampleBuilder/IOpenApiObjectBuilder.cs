using Microsoft.OpenApi.Any;

namespace Swashbuckle.AspNetCore.ExampleBuilder
{
    public interface IOpenApiObjectBuilder
    {
        OpenApiObject Build(object o);
    }
}