using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.UI.Utilities;
using SGBank.UI.Workflows;

namespace SGBank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = false;
            do
            {

                Teller teller = new Teller();
                teller = UserPrompts.AccessLevel();
                MainMenu menu = new MainMenu();
                menu.Execute(teller);

            } while (true);

        }
    }
}
