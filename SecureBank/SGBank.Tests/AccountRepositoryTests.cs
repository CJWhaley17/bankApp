using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Data.Repositories;

namespace SGBank.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        [Test]
        public void CanLoadAllAccounts()
        {
            var repo = new MockAccountRepository();
            var accounts = repo.ListAccounts();

            Assert.AreEqual(3,accounts.Count);
        }
        [TestCase(1,"John")]
        [TestCase(3,"CJ")]
        public void CanLoadSpecificAccount(int accountNumber, string expected)
        {
            var repo = new MockAccountRepository();
            var account = repo.LoadAccount(accountNumber);

            Assert.AreEqual(expected, account.Name);
        }
        
    }
}
