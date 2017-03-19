using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data.Interfaces;
using SGBank.Data.Repositories;

namespace SGBank.Data.Factories
{
    public static class AccountRepositoryFactory
    {
        public static IAccountRepository GetAccountRepository()
        {
            var mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
               case "Prod":
                    return new FileAccountRepository();
                case "Test":
                    return new MockAccountRepository();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
