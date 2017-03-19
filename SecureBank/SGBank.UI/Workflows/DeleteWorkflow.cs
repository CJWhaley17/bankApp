using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class DeleteWorkflow
    {
        public void Execute(Account account)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Account nullAccount = new Account(); // because I goofed with all of my parameters earlier and need to pass in a blank
            Console.Clear();
            string input = UserPrompts.GetStringFromUser(
                $"Are you sure you would like to delete {account.Name}'s account?\n(Yes) - (N)o").ToUpper();
            if (input.Substring(0, 1) == "Y" || input == "YES")
            {
                WithdrawlWorkflow wd = new WithdrawlWorkflow();
                wd.Execute(account, "The balance is being drained and returned.", false, nullAccount, true);
                //Delete the account
                AccountManager manager = new AccountManager();
                manager.DeleteAccount(account);
            }
            else
            {
                Console.WriteLine("Account was not deleted.");
            }

        }
    }
}
