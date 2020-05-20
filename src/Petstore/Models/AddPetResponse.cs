using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.ExampleBuilder;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Petstore.Models
{
    [SwaggerSchemaFilter(typeof(AddPetResponseSchemaFilter))]
    public class AddPetResponse
    {
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }

    public class AddPetResponseSchemaFilter : ISchemaFilter
    {
        private readonly IOpenApiObjectBuilder _objectBuilder;

        public AddPetResponseSchemaFilter(IOpenApiObjectBuilder objectBuilder)
        {
            _objectBuilder = objectBuilder;
        }
        
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var response = new AddPetResponse
            {
                Id = 1234,
                Name = "Add pet",
                Category = new Category
                {
                    Id = 1111,
                    Name = "dog"
                }
            };

            schema.Example = _objectBuilder.Build(response);
        }
    }
}