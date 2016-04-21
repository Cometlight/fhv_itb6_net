using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Database.Broker;
using Domain;
using NUnit.Framework;

namespace Tests.Database
{
    [TestFixture]
    class BrokerTests
    {
        private static readonly int databaseConnectionId = 0;

        /*[SetUpFixture]
        public class Config
        {
            [OneTimeSetUp]
            public void SetUp()
            {
                DapperConfiguration.Initialize();
            }

            [OneTimeTearDown]
            public void TearDown()
            {
                
            }
        }

        private IDbConnection iDbConnection;

        [SetUp]
        public void SetUp()
        {
            iDbConnection = new ConnectionManager(databaseConnectionId).GetDbConnection();
            iDbConnection.Open();
        }

        [TearDown]
        public void TearDown()
        {
            iDbConnection.Close();
        }

        [Test, Order(1)]
        public void Insert()
        {
            IBroker<User> broker = new Broker<User>();
            User entity = new User
            {
                Password = "password",
                Login = "login"
            };
            broker.Save(iDbConnection, ref entity);
        }

        [Test]
        [TestCase(1)]
        public void Get(int id)
        {
            IBroker<Product> broker = new Broker<Product>();
            Product entity = broker.Get(iDbConnection, id);
            Assert.AreEqual(id, entity.Id);
        }*/
    }
}
