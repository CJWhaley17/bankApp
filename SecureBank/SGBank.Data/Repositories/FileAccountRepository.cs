using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data.Interfaces;
using SGBank.Models;

namespace SGBank.Data.Repositories
{
    public class FileAccountRepository : IAccountRepository
    {

        private string _filePath = @"DataFiles\Bank.txt";
        public List<Account> ListAccounts()
        {
            List<Account> results = new List<Account>();

            var rows = File.ReadAllLines(_filePath);

            for (int i = 1; i < rows.Length; i++)
            {
                var columns = rows[i].Split(',');

                var account = new Account();
                account.AccountNumber = int.Parse(columns[0]);
                account.Name = columns[1];
                account.Balance = decimal.Parse(columns[2]);
                account.Type = (AccountType) int.Parse(columns[3]);

                results.Add(account);
            }
            return results;
        }

        public Account LoadAccount(int accountNumber)
        {
            List<Account> accounts = ListAccounts();
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void AddAccount(Account account)
        {
            var accounts = ListAccounts();
            accounts.Add(account);
            OverwriteFile(accounts);
        }

        public void UpdateAccount(Account account)
        {
            var accounts = ListAccounts();
            var accountToUpdate = accounts.First(a => a.AccountNumber == account.AccountNumber);
            accountToUpdate.Name = account.Name;
            accountToUpdate.Balance = account.Balance;
            accountToUpdate.Type = account.Type;
            OverwriteFile(accounts);
        }

        public void DeleteAccount(int accountNumber)
        {
            var accounts = ListAccounts();
            var accountToRemove = accounts.First(a => a.AccountNumber == accountNumber);
            accounts.Remove(accountToRemove);
            OverwriteFile(accounts);
        }

        public void OverwriteFile(List<Account> accounts)
        {
            File.Delete(_filePath);

            using (var writer = File.CreateText(_filePath))
            {
                writer.WriteLine("AccountNumber,Name,Balance,AccountType");
                foreach (var account in accounts)
                {
                    writer.WriteLine($"{account.AccountNumber},{account.Name},{account.Balance},{(int)account.Type}");
                }
            }
        }
    }
}
