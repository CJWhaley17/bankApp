using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Utilities
{
    public static class UserPrompts
    {
        public static string GetStringFromUser(string message)
        {
            //we need to validate this by wrapping in a loop
            //TODO: Add validation to this input
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static decimal GetDecimalFromUser(string message)
        {
            do
            {
                Console.Clear();
                Console.WriteLine(message);
                string input = Console.ReadLine();
                decimal value;
                if (decimal.TryParse(input, out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("That was not a valid deciaml number.");
                    PressKeyforContinue();
                }


            } while (true);
        }

        public static int GetIntFromUser(string message)
        {

            do
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("That was not a valid number.");
                    PressKeyforContinue();
                }


            } while (true);
        }

        public static void PressKeyforContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }





        public static Teller AccessLevel()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Teller teller = new Teller();
            int count = 0;
            string pword = "";
            string input = "";


            int username = GetTellerNumber();

            while (count < 4)
            {
                Console.Clear();
                Console.WriteLine("You must enter a valid password to continue.\nWould you like to see your password?\n(Y)es to see password, otherwise hit any key.");
                string showPassword = GetYesorNo();
                Console.WriteLine();
                if (showPassword.Substring(0, 1) == "Y")
                {
                    Console.WriteLine("Please enter your password to continue.");
                    input = Console.ReadLine();
                }
                else
                {
                    input = GetPassword("Please enter your password to continue.");
                }
                TellerManager manager = new TellerManager();

                bool validUsernameAndPassword = manager.GetUserInfo(username, input);

                if (validUsernameAndPassword == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid password.");
                    Console.WriteLine("You have {0} attempts left.", 2 - count);
                    if (2 - count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Exceeded attempts. Goodbye.");
                        PressKeyforContinue();
                        Environment.Exit(0);
                    }
                    PressKeyforContinue();
                    Console.Clear();
                    count++;
                }
                else if (validUsernameAndPassword)
                {
                    teller = manager.GetTeller(username);
                    break;
                }

            }
            return teller;
        }

        private static string GetYesorNo()
        {
            for (;;)
            {
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    return input.ToUpper();
                }
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.ToUpper();
                }
            }
        }

        public static int GetTellerNumber()
        {
            for (;;)
            {
                Console.WriteLine("Please enter your Teller Number.");
                string userInput = Console.ReadLine();
                int tellerNumber = 0;

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    tellerNumber = int.Parse(userInput);
                    return tellerNumber;
                }
                else if (!string.IsNullOrEmpty(userInput))
                {
                    tellerNumber = int.Parse(userInput);
                    return tellerNumber;
                }
                else
                {
                    Console.WriteLine("Cannot enter an empty Teller Number.");
                }

            }

        }

        private static string GetPassword(string message)
        {
            Console.WriteLine(message);
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            return password;
        }
    }
}
