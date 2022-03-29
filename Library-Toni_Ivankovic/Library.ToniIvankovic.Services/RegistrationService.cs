using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace Library.ToniIvankovic.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<Person> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        public RegistrationService(ITokenGenerator tokenGenerator, UserManager<Person> userManager)
        {
            this._userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<TokenDTO> LoginPersonAsync(LoginDTO loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);
            if (user == null)
            {
                throw new Exception("User non-existent!");
            }

            bool validPassword = await _userManager.CheckPasswordAsync(user, loginData.Password);
            if (!validPassword)
            {
                throw new Exception("Invalid password!");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName", user.FirstName + " " + user.LastName),
                new Claim("Id", user.Id.ToString()),
            };

            return _tokenGenerator.GenerateToken(claims);
        }

        public async Task<Person> RegisterPersonAsync(RegisterDTO person)
        {
            var existing = await _userManager.FindByEmailAsync(person.Email);
            if (existing != null)
            {
                throw new Exception("User already exists!");
            }

            Person newPerson = new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Address = new Address()
                {
                    Street = person.Street,
                    City = person.City,
                    Country = person.Country,
                },
                Email = person.Email,
                UserName = person.Email,
            };
            var result = await _userManager.CreateAsync(newPerson, person.Password);

            if (!result.Succeeded)
            {
                throw new Exception(
                    string.Join(",", result.Errors.SelectMany(x => x.Description))
                    );
            }

            return newPerson;
        }
    }
}
