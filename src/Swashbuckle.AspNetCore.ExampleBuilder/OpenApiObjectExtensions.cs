using System;
using Microsoft.Extensions.DependencyInjection;

namespace Swashbuckle.AspNetCore.ExampleBuilder
{
    public static class OpenApiObjectExtensions
    {
       public static void AddSwaggerExampleBuilder(this IServiceCollection services, Action<ExampleSettings> configure = null)
       {
           var settings = new ExampleSettings();
           configure?.Invoke(settings);

           services.AddSingleton(c => settings);
           services.AddTransient<IOpenApiObjectBuilder, OpenApiObjectBuilder>();
           services.AddTransient<PropertiesGraphTransformer>();
       } 
    }
}