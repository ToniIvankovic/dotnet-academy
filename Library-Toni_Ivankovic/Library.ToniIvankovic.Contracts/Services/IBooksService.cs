using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;

namespace Library.ToniIvankovic.Contracts.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task RentBookAsync(int id);
        Task<Book> GetBookByIdAsync(int id);
        Task ReturnBookAsync(int id);
        Task<List<Book>> GetAllReturnedBooks(int personId);
    }
}
