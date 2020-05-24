![.NET Core](https://github.com/twzhangyang/Swashbuckle.AspNetCore.ExampleBuilder/workflows/.NET%20Core/badge.svg)
![Nuget](https://img.shields.io/nuget/v/Swashbuckle.AspNetCore.SchemaBuilder)

## Why Swashbuckle.AspNetCore.SchemaBuilder

As we know, swagger is a good tool that help us document apis,  api consumers can use it complete api integration. 
Generally the more swagger was written completed the more convenient  for API consumers.
Example in swagger is quite useful for consumer, for request body and response object, example will give api consumers intuitive feelings.
In ASP.NET Core 3.0, we can use swashbuckle generate OpenAPI swagger and ISchemaFilter is used for generating example.

[According to official document](https://github.com/domaindrivendev/Swashbuckle.AspNetCore#apply-schema-filters-to-specific-types), below code used to generate example for `Pet` model:

``` c#
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

```
As you can see above code is easy to make mistake, imaging the Pet model was changed but this example still keep building success. 
This library offer you writing an example like you are defining object:

``` c#
public class PetSchemaByBuilderFilter : ISchemaFilter
{
    private readonly IOpenApiObjectBuilder _objectBuilder;

    public PetSchemaByBuilderFilter(IOpenApiObjectBuilder objectBuilder)
    {
        _objectBuilder = objectBuilder;
    }
    
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var pet = new PetCreator().Create();

        schema.Example = _objectBuilder.Build(pet);
    }
}

public class PetCreator
{
    public Pet Create()
    {
        var pet = new Pet
        {
            Id = 123,
            Name = "dog",
            Category = new Category
            {
                Id = 1234,
                Name = "Animal",
            },
            PhotoUrls = new List<string>
            {
                "www.photo1.com",
                "www.photo2.com"
            },
            Status = Pet.StatusEnum.AvailableEnum,
            Tags = new List<Tag>
            {
                new Tag {Id = 1111, Name = "tag1"},
                new Tag {Id = 2222, Name = "tag2"}
            }
        };
        return pet;
    }
}

```

## Getting Started

* Install Nuget package:

```
dotnet add package Swashbuckle.AspNetCore.SchemaBuilder --version 1.3.0
```

* Register services in DI container:
``` c#
services.AddSwaggerSchemaBuilder();
```

* Disable camelcase 
``` c#
services.AddSwaggerSchemaBuilder(s => {
    s.Camelcase = false;
})
```

* Define SchemaFilter for request or response model
* [See example](https://github.com/twzhangyang/Swashbuckle.AspNetCore.ExampleBuilder/blob/master/src/Petstore/Models/PetSchemaFilter.cs)
* Run Petstore api project in local, Api `POST /pet` have both request and response examples in swagger:
![example](https://user-images.githubusercontent.com/22952792/82415107-97325f00-9aaa-11ea-8fe4-bad4fb5a2c9e.png)
