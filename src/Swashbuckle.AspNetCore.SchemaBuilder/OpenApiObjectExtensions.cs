using System;
using Microsoft.Extensions.DependencyInjection;

namespace Swashbuckle.AspNetCore.SchemaBuilder
{
    public static class OpenApiObjectExtensions
    {
       public static void AddSwaggerSchemaBuilder(this IServiceCollection services, Action<SchemaSettings> configure = null)
       {
           var settings = new SchemaSettings();
           configure?.Invoke(settings);

           services.AddSingleton(c => settings);
           services.AddTransient<IOpenApiObjectBuilder, OpenApiObjectBuilder>();
           services.AddTransient<PropertiesGraphTransformer>();
       } 
    }
}