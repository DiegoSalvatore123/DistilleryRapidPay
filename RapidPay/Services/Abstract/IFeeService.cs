using RapidPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services.Abstract
{
    public interface IFeeService
    {
        void New(double Amount);
        Fee Get();
    }
}
