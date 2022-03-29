using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Repositories;
using Library.ToniIvankovic.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace Library.ToniIvankovic.Services
{
    public class RegistrationService : IRegistrationService
    {
        private IUnitOfWork unitOfWork;
        private readonly UserManager<Person> _userManager;
        public RegistrationService(IUnitOfWork unitOfWork, UserManager<Person> userManager)
        {
            this.unitOfWork = unitOfWork;
            this._userManager = userManager;
        }

        public async Task<Person> LoginPersonAsync(LoginDTO loginData)
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

            return user;
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
