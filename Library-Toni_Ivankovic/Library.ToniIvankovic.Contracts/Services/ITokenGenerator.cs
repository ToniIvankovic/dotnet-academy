using System.Security.Claims;
using Library.ToniIvankovic.Contracts.Dtos;

namespace Library.ToniIvankovic.Services
{
    public interface ITokenGenerator
    {
        public TokenDTO GenerateToken(List<Claim> claims);
    }
}
