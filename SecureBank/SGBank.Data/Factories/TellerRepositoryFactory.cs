using SGBank.Data.Interfaces;
using SGBank.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data.Factories
{
    public static class TellerRepositoryFactory
    {
        public static ITellerRepository GetTellerRepository()
        {
            var mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "Prod":
                    return new TellerAccountRepository();
                case "Test":
                    return new MockTellerRepository();
                default:
                    throw new ArgumentException();
            }
        }
    }
}

