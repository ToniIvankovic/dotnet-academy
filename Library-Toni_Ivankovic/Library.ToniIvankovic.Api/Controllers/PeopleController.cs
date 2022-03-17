using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.ToniIvankovic.Api.Controllers
{
    [Route("host/api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult GetPersonsAll()
        {
            //TODO
            return Ok();
        }
        [HttpGet]
        public IActionResult GetPersonFromCity([FromQuery] string city)
        {
            //TODO
            return Ok(city);
        }
        [HttpGet]
        [Route("{personId:int}")]
        public IActionResult GetPersonById([FromRoute] int personId)
        {
            //TODO
            return Ok("a" + personId);
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] PersonDTO PersonDTO)
        {
            //TODO
            return Ok(PersonDTO);
        }
    }

}
