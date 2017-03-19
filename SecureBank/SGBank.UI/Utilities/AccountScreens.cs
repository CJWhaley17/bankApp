using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.UI.Utilities
{
    public static class AccountScreens
    {
        public static void PrintAccountDetailsView(Account account)
        {
            Console.WriteLine("Account Information");
            Console.WriteLine("======================================");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Account Balance: {account.Balance:c}");
        }

        internal static void WithdrawlDetails(WithdrawlReceipt receipt)
        {
            Console.Clear();
            Console.WriteLine("Withdrew {0:c} from account {1}", receipt.WithdrawlAmount, receipt.AccountNumber);
            Console.WriteLine("New balance is {0:c}", receipt.NewBalance);
            UserPrompts.PressKeyforContinue();
        }

        public static void DepositDetails(DepositReceipt receipt)
        {
            Console.Clear();
            Console.WriteLine("Deposited {0:c} to account {1}.", receipt.DepositAmount, receipt.AccountNumber);
            Console.WriteLine("New balance is {0:c}", receipt.NewBalance);
            UserPrompts.PressKeyforContinue();
        }

        public static void WorkflowErrorScreen(string message)
        {
            Console.Clear();
            Console.WriteLine($"An error occured.  {message}");
            UserPrompts.PressKeyforContinue();
        }
    }
}
