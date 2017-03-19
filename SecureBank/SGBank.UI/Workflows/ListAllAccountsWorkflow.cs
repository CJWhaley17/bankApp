using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.BLL;

namespace SGBank.UI.Workflows
{
    public class ListAllAccountsWorkflow
    {
        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("===================================================");
            Console.WriteLine("Welcome to The Software Bank of Code");
            Console.WriteLine("===================================================");
            //Console.WriteLine("Not Implemented yet.");
            //Console.ReadKey();
            var myFile = File.ReadLines(@"Datafiles\Bank.txt");
            foreach (var line in myFile)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
