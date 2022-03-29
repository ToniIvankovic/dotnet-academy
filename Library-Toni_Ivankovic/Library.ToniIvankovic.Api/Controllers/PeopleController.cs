using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.ToniIvankovic.Api.Controllers
{
    /// <summary>
    /// The controller for requests on people.
    /// </summary>
    [Route("host/api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService peopleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleController"/> class.
        /// </summary>
        /// <param name="peopleService"> The peopleService implementation to be used. </param>
        public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        [HttpGet("all")]
        [Authorize]
        public async Task<IActionResult> GetPersonsAllAsync()
        {
            return Ok(await peopleService.GetAllPersonsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonFromCityAsync([FromQuery] string city)
        {
            return Ok(await peopleService.GetAllPersonsByCity(city));
        }

        [HttpGet]
        [Route("{personId:int}")]
        public async Task<IActionResult> GetPersonByIdAsync([FromRoute] int personId)
        {
            return Ok(await peopleService.GetPersonByIdAsync(personId));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonAsync([FromBody] PersonDTO personDTO)
        {
            return Ok(await peopleService.CreatePersonAsync(personDTO));
        }
    }
}
