using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;

namespace Library.ToniIvankovic.Contracts.Services
{
    public interface IRegistrationService
    {
        public Task<Person> RegisterPersonAsync(RegisterDTO person);
        public Task<TokenDTO> LoginPersonAsync(LoginDTO loginData);
    }
}
