namespace Library.ToniIvankovic.Api.Controllrs
{
    using Library.ToniIvankovic.Contracts.Dtos;
    using Library.ToniIvankovic.Contracts.Entities;
    using Library.ToniIvankovic.Contracts.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

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
            //TODO ok?
            return Ok(peopleService.GetAllPersons());
        }
        [HttpGet]
        public IActionResult GetPersonFromCity([FromQuery] string city)
        {
            //TODO ok?
            return Ok(peopleService.GetAllPersonsByCity(city));
        }
        [HttpGet]
        [Route("{personId:int}")]
        public IActionResult GetPersonById([FromRoute] int personId)
        {
            //TODO ok?
            return Ok(peopleService.GetPersonById(personId));
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] PersonDTO PersonDTO)
        {
            //TODO ok?
            return Ok(peopleService.CreatePerson(PersonDTO));
        }
    }

}
