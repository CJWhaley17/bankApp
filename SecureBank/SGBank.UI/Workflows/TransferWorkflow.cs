using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class TransferWorkflow
    {
        public void Execute(Account currentAccount, decimal amount)
        {
            Console.Clear();
            DisplayHeading();
            int transferAccountNumber = UserPrompts.GetIntFromUser("Please enter the account number you would like to transfer to.");

            var transferAccount = new AccountManager();

            var transferToAccount = transferAccount.GetAccount(transferAccountNumber);

            if (transferToAccount.Success)
            {
                Account MoveThatMoneyAcct = new Account();

                MoveThatMoneyAcct = transferToAccount.Data;
                
                WithdrawlWorkflow transferFrom = new WithdrawlWorkflow();

                transferFrom.Execute(currentAccount, "Please enter an amount to transfer.", true, MoveThatMoneyAcct);

                Console.WriteLine($"You successfully transfered money to {MoveThatMoneyAcct.Name}");
            }
        }
        private void DisplayHeading()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("===================================================");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Welcome to The Software Bank of Code");
            Console.WriteLine("Transferring Funds");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("===================================================");

            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
