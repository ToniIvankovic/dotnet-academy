using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.ToniIvankovic.Api.Controllrs
{
    [Route("host/api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public IActionResult GetPersonsAll()
        {
            //TODO ok?
            return Ok(_peopleService.GetAllPersons());
        }
        [HttpGet]
        public IActionResult GetPersonFromCity([FromQuery] string city)
        {
            //TODO ok?
            return Ok(_peopleService.GetAllPersonsByCity(city));
        }
        [HttpGet]
        [Route("{personId:int}")]
        public IActionResult GetPersonById([FromRoute] int personId)
        {
            //TODO ok?
            return Ok(_peopleService.GetPersonById(personId));
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] PersonDTO PersonDTO)
        {
            //TODO
            return Ok(PersonDTO);
        }
    }

}
