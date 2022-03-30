using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Exceptions
{
    public class BookNotAvailableException : Exception
    {
        public BookNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public BookNotAvailableException() : base()
        {
        }

        public BookNotAvailableException(string? message) : base(message)
        {
        }
    }
}
