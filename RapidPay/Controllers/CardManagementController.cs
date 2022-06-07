using RapidPay.Helper;
using RapidPay.Models;
using RapidPay.Services.Abstract;
using System.Web.Http;

namespace RapidPay.Controllers
{

    [RoutePrefix("api/CardManagement")]
    public class CardManagementController : ApiController
    {
        private readonly ICardService iCardService;
        public CardManagementController(ICardService _cardService)
        {
            this.iCardService = _cardService;
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Card card)
        {

            if (card.Number.Length != 15)
            {
                return Ok("Bad data");
            }
            var cache = new CacheHelper<Card>(card.Number);
            if (cache.CheckCache())
            {
                return Ok("Card already Exist.");
            }
            cache.SetToCache(card);
            return Ok();
        }

        [HttpPost]
        [Route("Pay")]
        public IHttpActionResult Pay(Payment payment)
        {
            Card card = new Card();
            var cache = new CacheHelper<Card>(payment.CardNumber);
            if (!cache.CheckCache())
            {
                return Ok("Card Not Exist.");
            }
            card = cache.GetToCache();
            iCardService.Pay(card: card, amount: payment.Amount);
            cache.SetToCache(card);
            return Ok();
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(string cardNumber)
        {
            Card card = new Card();
            var cache = new CacheHelper<Card>(cardNumber);
            if (!cache.CheckCache())
            {
                return Ok("Card Does not Exist.");
            }
            card = cache.GetToCache();
            return Ok(card.Balance);
        }
    }
}