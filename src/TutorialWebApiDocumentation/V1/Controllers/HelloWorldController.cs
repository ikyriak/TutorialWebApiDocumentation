using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TutorialWebApiDocumentation.V1.DTOs;

namespace TutorialWebApiDocumentation.V1.Controllers
{
[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class HelloWorldController : ControllerBase
{
        /// <summary>
        /// Get a list with all "<see cref="SampleResponse"/>" items.
        /// </summary>
        /// <response code="200">Returns a list with the available sample responses.</response>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<SampleResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IEnumerable<SampleResponse> Get()
        {
            return new List<SampleResponse>(){
                new SampleResponse()
                {
                    Id = 1,
                    Name = "Actual Value 1"
                },
                new SampleResponse()
                {
                    Id = 2,
                    Name = "Actual Value 2"
                }
            };
        }

        // GET api/<HelloWorldController>/5
        /// <summary>
        /// Get details of the specified sample response <paramref name="id"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Returns details of the specified sample response id.</response>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(SampleResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public SampleResponse GetById(int id)
        {
            return new SampleResponse()
            {
                Id = id,
                Name = "value3"
            };
        }


        
        /// <summary>
        /// Create a sample based on the requested data.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(SampleResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public ActionResult<SampleResponse> Post([FromBody] SampleRequest value)
        {

            SampleResponse createdSamples = new SampleResponse()
            {
                Id = value.Id,
                Name = value.Name ?? String.Empty,
            };


            return CreatedAtAction(nameof(GetById), new { createdSamples.Id }, createdSamples);
        }

        // PUT api/<HelloWorldController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SampleRequest value)
        {

        }

        // DELETE api/<HelloWorldController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
