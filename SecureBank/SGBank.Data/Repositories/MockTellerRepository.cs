using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data.Interfaces;
using SGBank.Models;

namespace SGBank.Data.Repositories
{
    public class MockTellerRepository : ITellerRepository
    {
        private static List<Teller> tellers;
        static MockTellerRepository()
        {
            tellers = new List<Teller>()
            {
                new Teller() {TellerNumber = 1, Name = "Corey Whaley", Accesslevel = 5, Password = "qwerty123"},
                new Teller() {TellerNumber = 2, Name = "Dave Balzer", Accesslevel = 5, Password = "daveiscool"},
                new Teller() {TellerNumber = 3, Name = "Randall Clapper", Accesslevel = 2, Password = "iamevil"}
            };

        }
        public List<Teller> ListTellers()
        {
            return tellers;
        }

        public Teller LoadTeller(int tellerNumber)
        {
            return tellers.FirstOrDefault(a => a.TellerNumber == tellerNumber);
        }

        public void AddTeller(Teller teller)
        {
            throw new NotImplementedException();
        }
        public void UpdateTeller(Teller teller)
        {
            throw new NotImplementedException();
        }
    }
}
