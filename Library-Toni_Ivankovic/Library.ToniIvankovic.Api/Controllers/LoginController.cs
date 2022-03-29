using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.ToniIvankovic.Api.Controllers
{
    [Route("host/api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IRegistrationService registrationService;

        public LoginController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginPersonDTO)
        {
            return Ok(await registrationService.LoginPersonAsync(loginPersonDTO));
        }
    }

}
