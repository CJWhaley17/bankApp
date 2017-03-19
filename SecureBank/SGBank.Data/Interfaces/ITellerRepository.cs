using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data.Interfaces
{
    public interface ITellerRepository
    {
        List<Teller> ListTellers();
        Teller LoadTeller(int accountNumber);
        void AddTeller(Teller account);
        void UpdateTeller(Teller account);
    }
}
