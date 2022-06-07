using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidPay.Models
{
 
    public class Fee
    {
        private static int Start = 0;
        private static int End = 2;
        public double Amount { get; set; }
        public double Random { get; set; }
        public DateTime LastRandom { get; set; }

        public Fee (double amount)
        {
            this.Amount = amount;
            this.Random = GetRandom();
            this.LastRandom = GetLastRandom();
        }
        public Fee()
        {
        }
        public Fee(double amount, double random, DateTime lastRandom)
        {
            DateTime now = DateTime.Now;
            this.Amount = amount;
            var hours = (now - lastRandom).TotalHours;
            if (hours >= 1)
            {
                this.Random = GetRandom();
                this.LastRandom = GetLastRandom();
            }
            else
            {
                this.Random = random;
                this.LastRandom = lastRandom;
            }
        }
        private double GetRandom()
        {
            Random random = new Random();
            return (random.NextDouble() * Math.Abs(End - Start)) + Start;
        }
       
        private DateTime GetLastRandom()
        {
            return DateTime.Now;
        }

    }
}