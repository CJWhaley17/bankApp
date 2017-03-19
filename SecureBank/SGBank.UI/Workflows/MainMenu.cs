using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SGBank.Models;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    class MainMenu
    {
        public void Execute(Teller teller)
        {
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.Clear();
                DrawSeperatorBar();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Welcome to The Software Bank of Code");
                DrawSeperatorBar();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter an action.");
                DrawSeperatorBar();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("2. Lookup Account");
                if (teller.Accesslevel > 2)
                {
                    Console.WriteLine("3. List all accounts");
                }
                if (teller.Accesslevel == 5)
                {
                    Console.WriteLine("6. List all tellers");
                    Console.WriteLine("9. Add Tellers");
                }
                Console.WriteLine("\nQ to quit");

                string input = UserPrompts.GetStringFromUser("\nEnter Choice: ");

                if (input.Substring(0, 1).ToUpper() == "Q")
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for banking with The Software Bank of Code!\nPlease come again!");
                    Thread.Sleep(2600);
                    Environment.Exit(0);
                }

                ProcessChoice(input, teller);
            } while (true);
        }//end of execute

        private void DrawSeperatorBar()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("===================================================");
        }

        private void ProcessChoice(string input, Teller teller)
        {
            switch (input)
            {
                case "1":
                    CreateAccountWorkflow create = new CreateAccountWorkflow();
                    create.Execute();
                    break;
                case "2":
                    LookupWorkflow lookup = new LookupWorkflow();
                    lookup.Execute();
                    break;
                case "3":
                    if (teller.Accesslevel > 2)
                    {
                        ListAllAccountsWorkflow listAll = new ListAllAccountsWorkflow();
                        listAll.Execute();
                    }
                    break;
                case "6":
                    if (teller.Accesslevel == 5)
                    {
                        AddTellerWorkflow at = new AddTellerWorkflow();
                        at.ListAllTellers();
                    }
                    break;
                case "9":
                    if (teller.Accesslevel == 5)
                    {
                        AddTellerWorkflow et = new AddTellerWorkflow();
                        et.Execute();
                    }
                    break;
            }
        }
    }
}
