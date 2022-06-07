using RapidPay.Models;
using RapidPay.Services.Abstract;

using System.Web.Http;


namespace RapidPay.Controllers
{
    [RoutePrefix("api/FeePayment")]
    public class FeePaymentController : ApiController
    {
        private readonly IFeeService ifeeService;
        public FeePaymentController(IFeeService _ifeeService)
        {
            this.ifeeService = _ifeeService;
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Fee fee)
        {
            if (fee.Amount == 0)
            {
                return Ok("Bad data");
            }
            ifeeService.New(Amount:fee.Amount);
            return Ok();
        }
    }
}