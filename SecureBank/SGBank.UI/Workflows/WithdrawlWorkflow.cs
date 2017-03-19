using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class WithdrawlWorkflow
    {
        public void Execute(Account account, string message, bool transfer, Account transferAccount, bool deleting = false)
        {
            decimal amount;
            if (deleting == false)
            {
                amount = UserPrompts.GetDecimalFromUser(message);
            }
            else
            {
                amount = account.Balance;
            }

            var manager = new AccountManager();

            var response = manager.Withdrawl(amount, account);

            if (response.Success)
            {
                AccountScreens.WithdrawlDetails(response.Data);
                if (transfer == true)
                {
                    DepositWorkflow depositTransfer = new DepositWorkflow();
                    depositTransfer.Execute(transferAccount, amount);
                }
            }
            else
            {
                AccountScreens.WorkflowErrorScreen(response.Message);
            }
        }
    }
}
