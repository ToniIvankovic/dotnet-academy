using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Dtos
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
