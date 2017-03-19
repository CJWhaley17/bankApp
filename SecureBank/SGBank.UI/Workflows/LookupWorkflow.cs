using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.UI.Utilities;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    class LookupWorkflow
    {
        private Account _currentAccount;
        public void Execute()
        {
            //TODO: Create a heading here so I can console.clear
            Console.ForegroundColor = ConsoleColor.White;
            int accountNumber = UserPrompts.GetIntFromUser("Please provide an account number: ");
            DisplayAccountInformation(accountNumber);
        }

        private void DisplayAccountInformation(int accountNumber)
        {
            var manager = new AccountManager();
            var result = manager.GetAccount(accountNumber);
            Console.Clear();
            if (result.Success)
            {
                _currentAccount = result.Data;
                AccountScreens.PrintAccountDetailsView(_currentAccount);
                DisplayLookupMethod();
            }
        }

        private void DisplayLookupMethod()
        {
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===================================================");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Currently using the account of:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{_currentAccount.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===================================================");
                ShowAccountInfoToTeller(_currentAccount);


                Console.WriteLine("\n1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("0. Delete Account");
                Console.WriteLine("\nQ to return to main menu");

                string input = UserPrompts.GetStringFromUser("\nEnter choice: ");
                if (input.Substring(0, 1).ToUpper() == "Q")
                {
                    break;
                }
                ProcessChoice(input);
            } while (true);
        }
        private void ProcessChoice(string input)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Account notAccount = new Account();
            decimal amount = 0;
            switch (input)
            {
                case "1":
                    DepositWorkflow dep = new DepositWorkflow();
                    dep.Execute(_currentAccount, amount);
                    break;
                case "2":
                    WithdrawlWorkflow withdrawl = new WithdrawlWorkflow();
                    withdrawl.Execute(_currentAccount, "Please enter an amount to withdrawl", false, notAccount);
                    break;
                case "3":
                    TransferWorkflow transfer = new TransferWorkflow();
                    transfer.Execute(_currentAccount, amount);
                    break;
                case "0":
                    DeleteWorkflow delete = new DeleteWorkflow();
                    delete.Execute(_currentAccount);
                    break;
            }
        }

        private void ShowAccountInfoToTeller(Account _currentAccount)
        {
            Console.WriteLine($"Account number: {_currentAccount.AccountNumber}");
            if (_currentAccount.Balance >= 100)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (_currentAccount.Balance >= 51 && _currentAccount.Balance < 100)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (_currentAccount.Balance > 51)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.WriteLine($"Account balance: {_currentAccount.Balance:c}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Account type: {_currentAccount.Type}");
        }
    }
}
