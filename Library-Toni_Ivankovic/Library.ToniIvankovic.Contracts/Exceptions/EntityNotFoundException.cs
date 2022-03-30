using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public EntityNotFoundException() : base()
        {
        }

        public EntityNotFoundException(string? message) : base(message)
        {
        }
    }
}
