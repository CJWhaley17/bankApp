using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class AddTellerWorkflow
    {
        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            DisplayHeading();

            Teller newTeller = new Teller();

            newTeller = GenerateNewTeller();

            DisplayNewTellerInformation();

            TellerManager manager = new TellerManager();

            manager.AddNewTeller(newTeller);

        }

        private void DisplayNewTellerInformation()
        {
            Teller newTeller = new Teller();

            newTeller = GenerateNewTeller();

            Console.WriteLine($"The name of the new teller is {newTeller.Name}.");

            Console.WriteLine($"Your teller number is {newTeller.TellerNumber}.");

            Console.WriteLine($"Your teller password is {newTeller.Password}");

            if (newTeller.Accesslevel < 3)
            {
                Console.WriteLine("With your access level, you can work with accounts.");
            }
            else
            {
                Console.WriteLine("You can work with accounts as well as teller accounts.");
            }
        }

        private Teller GenerateNewTeller()
        {
            Teller newTeller = new Teller();

            newTeller.Name = GetTellerName("Please enter your name");

            newTeller.TellerNumber = GetTellerNumber("Please enter a desired Teller number.");

            newTeller.Password = GetTellerPassword("Please enter a secure password.");

            newTeller.Accesslevel = EnterTellerAccessLevel("Manager, please enter an Access Level");

            return newTeller;
        }

        private void DisplayHeading()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("===================================================");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Welcome to The Software Bank of Code");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("===================================================");

            Console.ForegroundColor = ConsoleColor.White;

        }

        private int EnterTellerAccessLevel(string message)
        {
            Console.Clear();

            Console.WriteLine(message);

            return int.Parse(Console.ReadLine());

        }

        private string GetTellerPassword(string message)
        {
            string password;

            bool pwordOK = false;

            do
            {
                Console.Clear();

                Console.WriteLine(message);

                password = Console.ReadLine();

                if (password.Length < 5)
                {
                    Console.WriteLine("Password is too short");
                }
                else if (password.Length > 16)
                {
                    Console.WriteLine("Password is too long");
                }
                else if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("You did not enter anything.");
                }
                else if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("You did not enter anything.");
                }
                else if (password == "password")
                {
                    Console.WriteLine("Password is too generic.");
                }
                else
                {
                    return password;
                }

            } while (pwordOK == false);

            return password;
        }

        private string GetTellerName(string message)
        {
            Console.Clear();

            Console.WriteLine(message);

            return Console.ReadLine();
        }

        private int GetTellerNumber(string message = "")
        {
            Console.Clear();

            Console.WriteLine(message);

            string input = Console.ReadLine();

            int x;

            bool parsing = int.TryParse(input, out x);

            while (parsing == false)
            {
                Console.WriteLine("Invalid entry. Please try again.");

                input = Console.ReadLine();

                parsing = int.TryParse(input, out x);
            }
            return x;
        }

        public void ListAllTellers()
        {
            Console.Clear();
            
            var myFile = File.ReadLines(@"Datafiles\Tellers.txt");

            foreach (var line in myFile)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
        }
    }
}
