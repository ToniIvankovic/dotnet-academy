using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.ToniIvankovic.Api.Controllrs
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
        public IActionResult GetPersonsAll()
        {
            return Ok(peopleService.GetAllPersonsAsync());
        }

        [HttpGet]
        public IActionResult GetPersonFromCity([FromQuery] string city)
        {
            return Ok(peopleService.GetAllPersonsByCity(city));
        }

        [HttpGet]
        [Route("{personId:int}")]
        public IActionResult GetPersonById([FromRoute] int personId)
        {
            return Ok(peopleService.GetPersonByIdAsync(personId));
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] PersonDTO personDTO)
        {
            return Ok(peopleService.CreatePerson(personDTO));
        }
    }

}