using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;

namespace Library.ToniIvankovic.Contracts.Services
{
    public interface IBooksService
    {
        Task<List<BookCatalogDTO>> GetAllBooksAsync();
        Task<BookCatalogDTO> GetBookByIdAsync(int id);
        Task RentBookAsync(int personId, int bookId);
        Task ReturnBookAsync(int personId, int bookId);
        Task<List<BookCatalogDTO>> GetAllRentedBooks(int personId);
    }
}
