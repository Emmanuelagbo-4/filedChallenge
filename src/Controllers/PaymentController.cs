using System.Threading.Tasks;
using filedChallenge.Models.Request;
using filedChallenge.Models.Response;
using filedChallenge.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace filedChallenge.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        PaymentService _paymentService;
        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Process Payment.
        /// </summary>
        [HttpPost("process-payment")]
        [ProducesResponseType(typeof(APIResponse<PaymentResponseModel>), 200)]
        [ProducesResponseType(typeof(APIResponse), 400)]
        [AllowAnonymous]
        public async Task<IActionResult> ProcessPayment(PaymentRequestModel model)
        {
            var response = await _paymentService.ProcessPayment(model);

            if (response.status)
            {
                return Ok(new APIResponse { message = response.response, data = response.data });
            }
            return BadRequest(new APIResponse { message = response.response });
        }
    }
}