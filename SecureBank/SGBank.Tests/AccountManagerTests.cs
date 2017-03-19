using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL;

namespace SGBank.Tests
{
    [TestFixture]
    public class AccountManagerTests
    {
        [Test]
        public void FoundAccountReturnsSuccess()
        {
            var manager = new AccountManager();
            var response = manager.GetAccount(1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Data.AccountNumber);
            Assert.AreEqual("John", response.Data.Name);
        }

        [Test]
        public void NotFoundAccountReturnsFailure()
        {
            var manager = new AccountManager();
            var response = manager.GetAccount(999999998);

            Assert.IsFalse(response.Success);
            Assert.AreEqual("Account was not found", response.Message);
        }
    }
}
