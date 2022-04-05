using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.ToniIvankovic.Api.Controllers
{
    [Route("host/books")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            return Ok(await booksService.GetAllBooksAsync());
        }

        [HttpPut("{bookId:int}")]
        public async Task<IActionResult> RentBookAsync([FromRoute] int bookId)
        {
            await booksService.RentBookAsync(GetCurrentUserId(), bookId);
            return Ok();
        }

        [HttpDelete("{bookId:int}")]
        public async Task<IActionResult> ReturnBookAsync([FromRoute] int bookId)
        {
            await booksService.ReturnBookAsync(GetCurrentUserId(), bookId);
            return Ok();
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetRentedBooksAsync()
        {
            return Ok(await booksService.GetAllRentedBooks(GetCurrentUserId()));
        }

        private int GetCurrentUserId()
        {
            var idClaim = this.User.Claims.First(claim => claim.Type == "Id");
            return int.Parse(idClaim.Value);
        }

    }
}
