using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class CreateAccountWorkflow
    {
        Random _rng = new Random();
        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            Account newAccount = new Account();

            newAccount = GetDataForNewAccount();

            DisplayNewAccountInformation(newAccount);

            AccountManager manager = new AccountManager();

            manager.AddNewAccount(newAccount);
        }

        private void DisplayNewAccountInformation(Account newAccount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The account name is {newAccount.Name}");

            Console.WriteLine($"The account number is {newAccount.AccountNumber}");

            //change color to green if over 100, yell w if 51-99, red 51>
            if (newAccount.Balance >= 100)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (newAccount.Balance >= 51 && newAccount.Balance < 100)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (newAccount.Balance > 51)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.WriteLine($"The account balance is {newAccount.Balance:c}");
            Console.WriteLine("*In regards to color for balance color:\nGreen is 100+(good)\nYellow is 51-99(caution)\nRed is 0-51(danger)");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Your account type is {newAccount.Type}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }

        private Account GetDataForNewAccount()
        {
            Account newAccount = new Account();

            int newAccountNumberInt = GenerateNewRandomAccountNumber();

            newAccount.AccountNumber = newAccountNumberInt;

            newAccount.Name = UserPrompts.GetStringFromUser("Please enter a name for the new account.");

            newAccount.Balance = UserPrompts.GetDecimalFromUser("Starting deposit: ");

            newAccount.Type =
                (AccountType)
                UserPrompts.GetIntFromUser("Please enter an acct type \n1 for Free, 2 for Basic, 3 for Premium");

            return newAccount;
        }

        private int GenerateNewRandomAccountNumber()
        {
            List<Account> accounts = new List<Account>();

            var myFile = @"DataFiles\Bank.txt";
            
            var result = File.ReadLines(myFile);

            int count = 1;

            foreach (var line in result)
            {
                count += 1;
            }

            count = (count + 2) * 3 + _rng.Next(1, 1000);

            return count;
        }
    }
}
