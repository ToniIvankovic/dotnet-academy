using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Exceptions
{
    public class UserAuthenticationException : Exception
    {
        public UserAuthenticationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public UserAuthenticationException() : base()
        {
        }

        public UserAuthenticationException(string? message) : base(message)
        {
        }
    }
}
