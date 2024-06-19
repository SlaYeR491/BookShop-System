using BookShop.API.Aggregates;
using BookShop.API.Dtos;
using BookShop.API.Mapping;
using BookShop.Data;
using BookShop.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace BookShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CustomersController(ICustomerService customerService,
        JwtServices tokenServices,
        ICustomerBooksServices customerbooksServices,
        Mapper<CustomerAccount, CustomerAccountDto> accountmapper,
        Mapper<CustomerAccount, AuthenticationRequest> requestmapper,
        Mapper<CustomerBookDto, CustomerBook> customerbookmapper,
        Hashing hashing) : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async ValueTask<ActionResult<string>> Login(AuthenticationRequest request)
        {
            request.Password = hashing.Hash(Encoding.UTF8.GetBytes(request.Password));
            var acc = await customerService.ExistenceAsync(requestmapper.Map(request));
            if (acc == null)
                return Unauthorized();
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, acc.Id.ToString()),
                new Claim(ClaimTypes.Name, acc.UserName)
            });
            return Ok(tokenServices.Create(claims));
        }
        [HttpPost]
        [AllowAnonymous]
        public async ValueTask<ActionResult<string>> SignUp(CustomerAccountDto Acc)
        {
            Acc.Password = hashing.Hash(Encoding.UTF8.GetBytes(Acc.Password));
            if (await customerService.ExistenceAsync(accountmapper.Map(Acc)) != null)
                return Conflict();
            var acc = await customerService.AddAsync(accountmapper.Map(Acc));
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, acc.Id.ToString()),
                new Claim(ClaimTypes.Name, acc.UserName)
            });
            return Ok(tokenServices.Create(claims));
        }
        [HttpPut]
        public async ValueTask<ActionResult<CustomerBookDto>> UpdateAccount(CustomerAccountDto Acc)
        {
            var acc = await customerService.UpdateAsync(accountmapper.Map(Acc));
            return Ok(accountmapper.Map(acc));
        }
        [HttpPost]
        public async ValueTask<ActionResult<IEnumerable<CustomerBookDto>?>> AddBookToList(CustomerBookDto customerBook)
        {
            var book = await customerbooksServices.AddAsync(customerbookmapper.Map(customerBook));
            if (book == null)
                return BadRequest();
            var books = await customerbooksServices.ReadAllAsync(customerBook.CustomerId);
            return Ok(books.Select(customerbookmapper.Map));
        }
        [HttpDelete]
        public async ValueTask<ActionResult<IEnumerable<CustomerBookDto>>> RemoveBookFromList(CustomerBookDto customerBook)
        {
            var deleted = await customerbooksServices.DeleteAsync(customerbookmapper.Map(customerBook));
            if (deleted == null)
                return BadRequest();
            return Ok(customerbookmapper.Map(deleted));
        }
        [HttpGet]
        public async ValueTask<ActionResult<IEnumerable<CustomerBookDto>>> GetBooksList(int CustomerId)
        {
            var books = await customerbooksServices.ReadAllAsync(CustomerId);
            return Ok(books.Select(customerbookmapper.Map));
        }
        [HttpPut]
        public async ValueTask<ActionResult<CustomerBookDto>> UpdateBooksList(CustomerBookDto bookDto)
        {
            var book = await customerbooksServices.UpdateAsync(customerbookmapper.Map(bookDto));
            return Ok((customerbookmapper.Map(book)));
        }

    }
}
