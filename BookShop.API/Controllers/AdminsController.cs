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
    public class AdminsController(IAdminServices adminServices,
        JwtServices tokenServices,
        Mapper<AuthenticationRequest, AdminAccount> mapper,
        Hashing hashing) : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(AuthenticationRequest request)
        {
            request.Password = hashing.Hash(Encoding.UTF8.GetBytes(request.Password));
            var acc = await adminServices.Login(mapper.Map(request));
            if (acc != null)
            {
                var claims = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier,acc.Id.ToString()),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Name,acc.UserName)
                });
                return Ok(tokenServices.Create(claims));
            }
            return Unauthorized();
        }
    }
}
