using BookShop.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController(IPaymentServices paymentService) : ControllerBase
    {
        [HttpPost]
        [Route("ConfirmPayment")]
        public ActionResult ConfirmPayment(int CustomerId)
        {
            return Ok(paymentService.ConfirmPayment(CustomerId));
        }
        [HttpGet]
        [Route("GetPaymentStatus")]
        public async Task<ActionResult> GetPaymentStatus(int PaymentId)
        {
            return Ok(await paymentService.CheckStatusAsync(PaymentId));
        }
    }
}
