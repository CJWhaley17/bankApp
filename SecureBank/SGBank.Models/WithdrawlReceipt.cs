using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public class WithdrawlReceipt
    {
        public int AccountNumber { get; set; }
        public decimal WithdrawlAmount { get; set; }
        public decimal NewBalance { get; set; }
    }
}
