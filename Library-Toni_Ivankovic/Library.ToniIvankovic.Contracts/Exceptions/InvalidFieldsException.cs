using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Exceptions
{
    public class InvalidFieldsException : Exception
    {
        public InvalidFieldsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public InvalidFieldsException() : base()
        {
        }

        public InvalidFieldsException(string? message) : base(message)
        {
        }
    }
}
