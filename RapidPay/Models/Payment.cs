using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidPay.Models
{
    public class Payment
    {
        public string CardNumber { get; set; }
        public double Amount { get; set; }
    }
}