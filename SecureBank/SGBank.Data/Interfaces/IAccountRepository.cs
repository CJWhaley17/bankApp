using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data.Interfaces
{
    public interface IAccountRepository
    {
        List<Account> ListAccounts();
        Account LoadAccount(int accountNumber);
        void AddAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(int accountNumber);
    }
}
