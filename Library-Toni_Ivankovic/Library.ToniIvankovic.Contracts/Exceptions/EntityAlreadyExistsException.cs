using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public EntityAlreadyExistsException() : base()
        {
        }

        public EntityAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
