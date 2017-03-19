using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data.Interfaces;
using SGBank.Models;

namespace SGBank.Data.Repositories
{
    public class MockAccountRepository : IAccountRepository
    {
        private static List<Account> accounts;

        static MockAccountRepository()
        {
            accounts = new List<Account>()
            {
                new Account() {AccountNumber = 1, Balance = 10.00M, Name = "John", Type = AccountType.Free},
                new Account() {AccountNumber = 2, Balance = 1250.00M, Name = "Larry", Type = AccountType.Basic},
                new Account() {AccountNumber = 3, Balance = 100000000.00M, Name = "CJ", Type = AccountType.Premium},
            };

        }

        public List<Account> ListAccounts()
        {
            return accounts;
        }

        public Account LoadAccount(int accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(Account account)
        {
            var accountToUpdate = accounts.First(a => a.AccountNumber == account.AccountNumber);
            accountToUpdate.Name = account.Name;
            accountToUpdate.Balance = account.Balance;
            accountToUpdate.Type = account.Type;
        }

        public void DeleteAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
