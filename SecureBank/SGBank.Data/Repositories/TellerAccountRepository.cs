﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data.Interfaces;
using SGBank.Models;

namespace SGBank.Data.Repositories
{
    public class TellerAccountRepository : ITellerRepository
    {
        private string _filePath = @"DataFiles\Tellers.txt";
        public List<Teller> ListTellers()
        {
            List<Teller> results = new List<Teller>();

            var rows = File.ReadAllLines(_filePath);

            for (int i = 1; i < rows.Length; i++)
            {
                var columns = rows[i].Split(',');

                var teller = new Teller();
                teller.TellerNumber = int.Parse(columns[0]);
                teller.Name = columns[1];
                teller.Accesslevel = int.Parse(columns[2]);
                teller.Password = columns[3];

                results.Add(teller);
            }
            return results;
        }

        public Teller LoadTeller(int tellerNumber)
        {
            List<Teller> tellers = ListTellers();
            return tellers.FirstOrDefault(a => a.TellerNumber == tellerNumber);
        }

        public void AddTeller(Teller teller)
        {
            var tellers = ListTellers();
            tellers.Add(teller);
            OverwriteFile(tellers);
        }

        public void UpdateTeller(Teller teller)
        {
            var tellers = ListTellers();
            var tellersToUpdate = tellers.First(a => a.TellerNumber == teller.TellerNumber);
            tellersToUpdate.Name = teller.Name;
            tellersToUpdate.Accesslevel = teller.Accesslevel;
            tellersToUpdate.Password = teller.Password;
            OverwriteFile(tellers);
        }

        public void OverwriteFile(List<Teller> tellers)
        {
            File.Delete(_filePath);

            using (var writer = File.CreateText(_filePath))
            {
                writer.WriteLine("TellerNumber,Name,AccessLevel,Password");
                foreach (var teller in tellers)
                {
                    writer.WriteLine($"{teller.TellerNumber},{teller.Name},{teller.Accesslevel},{teller.Password}");
                }
            }
        }
    }
}
