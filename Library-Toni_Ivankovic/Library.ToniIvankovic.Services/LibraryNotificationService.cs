using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Repositories;
using Library.ToniIvankovic.Contracts.Services;

namespace Library.ToniIvankovic.Services
{
    public class LibraryNotificationService : ILibraryNotificationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IEmailService _emailService;
        public LibraryNotificationService(IUnitOfWork uow, IEmailService emailService)
        {
            _uow = uow;
            _emailService = emailService;
        }

        public async Task SendReturnBookNotification()
        {
            const int days = 30;
            IEnumerable<Person> peopleWithUnreturnedBooks =
                await _uow
                .People
                .GetPeopleWithBookRentedBeforeDate(DateTime.UtcNow.AddDays(days));
            foreach (Person person in peopleWithUnreturnedBooks)
            {
                Console.WriteLine("Sending mail to " + person.Email);
                await _emailService
                    .Send(person.Email,
                    "Books not returned"
                    , $"Hello, \nyou have rented books which have not yet been returned, and the maximum limit of {days} days has passed. " +
                    $"\nPlease return the books in shortest notice. Thank you.");
            }
        }
    }
}
