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
            try
            {
                var rows = File.ReadAllLines(_filePath);

                for (int i = 1; i < rows.Length; i++)
                {
                    var columns = rows[i].Split(',');

                    var account = new Account();
                    account.AccountNumber = int.Parse(columns[0]);
                    account.Name = columns[1];
                    account.Balance = decimal.Parse(columns[2]);
                    account.Type = (AccountType)int.Parse(columns[3]);

                    results.Add(account);
                }
            }
            catch (Exception ex)
            {

            }
            return results;
        }

        public Account LoadAccount(int accountNumber)
        {
            try
            {
                List<Account> accounts = ListAccounts();
                return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            }
            catch (Exception ex) { return null; }
        }

        public void AddAccount(Account account)
        {
            try
            {
                var accounts = ListAccounts();
                accounts.Add(account);
                OverwriteFile(accounts);

            }
            catch (Exception ex) { }
        }

        public void UpdateAccount(Account account)
        {
            try
            {
                var accounts = ListAccounts();
                var accountToUpdate = accounts.First(a => a.AccountNumber == account.AccountNumber);
                accountToUpdate.Name = account.Name;
                accountToUpdate.Balance = account.Balance;
                accountToUpdate.Type = account.Type;
                OverwriteFile(accounts);
            }
            catch (Exception ex) { }
        }

        public void DeleteAccount(int accountNumber)
        {
            try
            {
                var accounts = ListAccounts();
                var accountToRemove = accounts.First(a => a.AccountNumber == accountNumber);
                accounts.Remove(accountToRemove);
                OverwriteFile(accounts);
            }
            catch (Exception ex) { }
        }

        public void OverwriteFile(List<Account> accounts)
        {
            try
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
            catch (Exception ex) { }            
        }
    }
}
