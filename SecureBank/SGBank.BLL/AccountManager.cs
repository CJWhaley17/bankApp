using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data.Factories;
using SGBank.Data.Interfaces;
using SGBank.Models;

namespace SGBank.BLL
{
    public class AccountManager
    {
        private IAccountRepository _repo;

        public AccountManager()
        {
            _repo = AccountRepositoryFactory.GetAccountRepository();
        }

        public Response<DepositReceipt> Deposit(decimal amount, Account account)
        {
            var result = new Response<DepositReceipt>();

            try
            {
                if (amount <= 0)
                {
                    result.Success = false;
                    result.Message = "Must provide a positive value to deposit.";
                }
                else
                {
                    account.Balance += amount;
                    _repo.UpdateAccount(account);

                    result.Success = true;
                    result.Data = new DepositReceipt()
                    {
                        AccountNumber = account.AccountNumber,
                        DepositAmount = amount,
                        NewBalance = account.Balance
                    };
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Account no longer valid.";
            }
            return result;
            
        }

        public void AddNewAccount(Account newAccount)
        {
            _repo.AddAccount(newAccount);
        }

        public void DeleteAccount(Account account)
        {
            _repo.DeleteAccount(account.AccountNumber);

        }

        public Response<WithdrawlReceipt> Withdrawl(decimal amount, Account account)
        {
            var result = new Response<WithdrawlReceipt>();

            try
            {
                if (amount <= 0 || amount > account.Balance)
                {
                    result.Success = false;
                    result.Message = "That amount cannont be withdrawn.";
                }
                else
                {
                    account.Balance -= amount;
                    _repo.UpdateAccount(account);

                    result.Success = true;
                    result.Data = new WithdrawlReceipt()
                    {
                        AccountNumber = account.AccountNumber,
                        WithdrawlAmount = amount,
                        NewBalance = account.Balance
                    };
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Account no longer valid.";
            }
            return result;

        }

        public Response<Account> GetAccount(int accountNumber)
        {
            var result = new Response<Account>();
            try
            {
                var account = _repo.LoadAccount(accountNumber);

                if (account == null)
                {
                    result.Success = false;
                    result.Message = "Account was not found";

                }
                else
                {
                    result.Success = true;
                    result.Data = account;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "There was an error. Please try again";
                //log.error(ex.Message);
            }
            return result;
        }
    }
}
