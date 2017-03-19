using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public class Teller
    {
        public int TellerNumber { get; set; }
        public string Name { get; set; }
        public int Accesslevel { get; set; }
        public string Password { get; set; }
    }
}
