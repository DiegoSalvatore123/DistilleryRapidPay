
using RapidPay.Models;
using RapidPay.Services.Abstract;


namespace RapidPay.Services.Concrete
{
    public class CardService : ICardService
    {
        private FeeService _feeService;
        private FeeService feeService
        {
            get
            {
                if (_feeService == null)
                {
                    _feeService = new FeeService();
                }
                return _feeService;
            }
        }
  
        public void Pay(Card card, double amount)
        {
            Fee fee= feeService.Get();
            card.Balance -= amount+(fee.Amount*fee.Random);
        }
    }
}