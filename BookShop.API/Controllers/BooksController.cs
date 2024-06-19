using BookShop.API.Dtos;
using BookShop.API.Mapping;
using BookShop.Data;
using BookShop.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BooksController(IBookServices bookService
        , Mapper<Book, BookDto> mapper) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBook(BookDto book)
        {
            var bk = await bookService.AddAsync(mapper.Map(book));
            if (bk != null)
                return Ok(bk);
            return BadRequest("The Book Already Exist Try Update Instead");
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(BookDto book)
        {
            var bk = await bookService.UpdateAsync(mapper.Map(book));
            if (bk != null)
                return Ok(mapper.Map(bk));
            return BadRequest("The Book is not Exist Try Add Instead");
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveBook(int BookId)
        {
            var bk = await bookService.DeleteAsync(BookId);
            if (bk != null)
                return Ok(mapper.Map(bk));
            return BadRequest("The book is not exist");
        }
        [HttpGet]
        [AllowAnonymous]
        public async ValueTask<ActionResult<IEnumerable<BookDto>?>> SearchForBook(string BookTitle)
        {
            var book = await bookService.SearchAsync(BookTitle);
            return Ok(mapper.Map(book));
        }
        [HttpGet]
        [AllowAnonymous]
        public async ValueTask<ActionResult<IEnumerable<BookDto>>> ShowAllBooks()
        {
            var books = await bookService.ReadAllAsync();
            return Ok(books.Select(mapper.Map));
        }
    }
}
