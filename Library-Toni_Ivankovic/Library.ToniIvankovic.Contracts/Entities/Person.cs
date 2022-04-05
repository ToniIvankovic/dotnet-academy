using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Library.ToniIvankovic.Contracts.Entities
{
    public class Person : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }
    }
}
