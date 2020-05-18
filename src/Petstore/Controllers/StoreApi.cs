using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Petstore.Attributes;
using Petstore.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Petstore.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("store")]
    public class StoreApiController : ControllerBase
    { 
        /// <summary>
        /// Delete purchase order by ID
        /// </summary>
        /// <remarks>For valid response try integer IDs with positive integer value.         Negative or non-integer values will generate API errors</remarks>
        /// <param name="orderId">ID of the order that needs to be deleted</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Order not found</response>
        [HttpDelete]
        [Route("/order/{orderId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteOrder")]
        public virtual IActionResult DeleteOrder([FromRoute][Required]long? orderId)
        { 
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns pet inventories by status
        /// </summary>
        /// <remarks>Returns a map of status codes to quantities</remarks>
        /// <response code="200">successful operation</response>
        [HttpGet]
        [Route("/store/inventory")]
        [ValidateModelState]
        [SwaggerOperation("GetInventory")]
        [SwaggerResponse(statusCode: 200, type: typeof(Dictionary<string, int?>), description: "successful operation")]
        public virtual IActionResult GetInventory()
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Dictionary<string, int?>));

            string exampleJson = null;
            exampleJson = "{\n  \"key\" : 0\n}";
            
            var example = exampleJson != null
            ? JsonSerializer.Deserialize<Dictionary<string, int?>>(exampleJson)
            : default;
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Find purchase order by ID
        /// </summary>
        /// <remarks>For valid response try integer IDs with value &gt;&#x3D; 1 and &lt;&#x3D; 10.         Other values will generated exceptions</remarks>
        /// <param name="orderId">ID of pet that needs to be fetched</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Order not found</response>
        [HttpGet]
        [Route("/order/{orderId}")]
        [ValidateModelState]
        [SwaggerOperation("GetOrderById")]
        [SwaggerResponse(statusCode: 200, type: typeof(Order), description: "successful operation")]
        public virtual IActionResult GetOrderById([FromRoute][Required][Range(1, 10)]long? orderId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Order));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            string exampleJson = null;
            exampleJson = "<Order>\n  <id>123456789</id>\n  <petId>123456789</petId>\n  <quantity>123</quantity>\n  <shipDate>2000-01-23T04:56:07.000Z</shipDate>\n  <status>aeiou</status>\n  <complete>true</complete>\n</Order>";
            exampleJson = "{\n  \"petId\" : 6,\n  \"quantity\" : 1,\n  \"id\" : 0,\n  \"shipDate\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"complete\" : false,\n  \"status\" : \"placed\"\n}";
            
            var example = exampleJson != null
            ? JsonSerializer.Deserialize<Order>(exampleJson)
            : default(Order);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Place an order for a pet
        /// </summary>
        
        /// <param name="body">order placed for purchasing the pet</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid Order</response>
        [HttpPost]
        [Route("/store/order")]
        [ValidateModelState]
        [SwaggerOperation("PlaceOrder")]
        [SwaggerResponse(statusCode: 200, type: typeof(Order), description: "successful operation")]
        public virtual IActionResult PlaceOrder([FromBody]Order body)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Order));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            string exampleJson = null;
            exampleJson = "<Order>\n  <id>123456789</id>\n  <petId>123456789</petId>\n  <quantity>123</quantity>\n  <shipDate>2000-01-23T04:56:07.000Z</shipDate>\n  <status>aeiou</status>\n  <complete>true</complete>\n</Order>";
            exampleJson = "{\n  \"petId\" : 6,\n  \"quantity\" : 1,\n  \"id\" : 0,\n  \"shipDate\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"complete\" : false,\n  \"status\" : \"placed\"\n}";
            
            var example = exampleJson != null
            ? JsonSerializer.Deserialize<Order>(exampleJson)
            : default(Order);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
