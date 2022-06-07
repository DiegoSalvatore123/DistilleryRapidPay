using RapidPay.Helper;
using RapidPay.Models;
using RapidPay.Services.Abstract;


namespace RapidPay.Services.Concrete
{
    public class FeeService: IFeeService
    {
        private const string FeeCache = "Fee";
        private const int Start = 0;
        private const int End = 2;
       
        public void New(double Amount)
        {
            Fee fee = new Fee(Amount);
            var cache = new CacheHelper<Fee>(FeeCache);
            cache.SetToCache(fee);
        }
        public Fee Get()
        {
            var cache = new CacheHelper<Fee>(FeeCache);
            Fee fee = cache.GetToCache();
            fee = NewRandom(fee: fee);
            cache.SetToCache(fee);
            return fee;
        }

        private Fee NewRandom(Fee fee)
        {
            return new Fee(amount: fee.Amount, random: fee.Random, lastRandom: fee.LastRandom);
        }
    }
}