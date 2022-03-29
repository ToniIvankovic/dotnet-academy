using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.ToniIvankovic.Api.Controllers
{
    [Route("host/api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationService registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO registerPersonDTO)
        {
            return Ok(await registrationService.RegisterPersonAsync(registerPersonDTO));
        }
    }

}
