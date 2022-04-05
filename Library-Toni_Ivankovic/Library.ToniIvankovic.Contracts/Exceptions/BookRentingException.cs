using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Exceptions
{
    public class BookRentingException : Exception
    {
        public BookRentingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public BookRentingException() : base()
        {
        }

        public BookRentingException(string? message) : base(message)
        {
        }
    }
}
