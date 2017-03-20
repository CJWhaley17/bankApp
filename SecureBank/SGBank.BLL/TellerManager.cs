using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data.Factories;
using SGBank.Data.Interfaces;
using SGBank.Data.Repositories;
using SGBank.Models;
using SGBank.Models.Classes;

namespace SGBank.BLL
{
    public class TellerManager
    {
        private static ITellerRepository _repo;

        public TellerManager()
        {
            try
            {
                _repo = TellerRepositoryFactory.GetTellerRepository();
            }
            catch(Exception ex) { }
        }

        public void AddNewTeller(Teller newTeller)
        {
            try
            {
                _repo.AddTeller(newTeller);
            }
            catch(Exception ex) { }
        }

        public Response<Teller> GetTelleResponse(int tellerNumber)
        {
            var result = new Response<Teller>();
            try
            {
                var teller = _repo.LoadTeller(tellerNumber);

                if (teller == null)
                {
                    result.Success = false;
                    result.Message = "Teller was not found";

                }
                else
                {
                    result.Success = true;
                    result.Data = teller;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "There was an error. Please try again";
                //log.error(ex.Message);
            }
            return result;
        }

        public bool GetUserInfo(int tellerNumber, string password)
        {
            //Teller teller = new Teller();
            //teller = _repo.LoadTeller(tellerNumber);
            Person person = new Person();
            var tell = _repo.LoadTeller(tellerNumber);
            try
            {
                person.TellerNumber = tell.TellerNumber;
                person.AccessLevel = tell.Accesslevel;
                person.Password = tell.Password;

                if (person.TellerNumber == tellerNumber && person.Password == password)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public Teller GetTeller(int tellerNumber)
        {
            Teller teller = new Teller();
            teller = _repo.LoadTeller(tellerNumber);
            return teller;
        }
    }
}
