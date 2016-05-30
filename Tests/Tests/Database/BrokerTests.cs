using System.Data;
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

        [SetUpFixture]
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

        [Test]
        public void InsertNoId()
        {
            IBroker<Product> broker = new Broker<Product>();
            Product entity = new Product()
            {
                Name = "Flux capacitor",
                Number = "42"
            };
            broker.Save(iDbConnection, ref entity);
            Product entityRetrieved = broker.Get(iDbConnection, entity.Id);
            Assert.NotNull(entityRetrieved);
            Assert.AreEqual(entity.Id, entityRetrieved.Id);
            Assert.AreEqual(entity.Name, entityRetrieved.Name);
            Assert.AreEqual(entity.Number, entityRetrieved.Number);
            // clean up
            broker.Delete(iDbConnection, entity);
        }

        [Test]
        public void Delete()
        {
            IBroker<Product> broker = new Broker<Product>();
            Product entity = new Product()
            {
                Name = "Flux capacitor",
                Number = "42"
            };
            broker.Save(iDbConnection, ref entity);
            Product entityRetrieved = broker.Get(iDbConnection, entity.Id);
            Assert.NotNull(entityRetrieved);
            broker.Delete(iDbConnection, entity.Id);
            entityRetrieved = broker.Get(iDbConnection, entity.Id);
            Assert.Null(entityRetrieved);
        }

        [Test]
        public void Update()
        {
            IBroker<Product> broker = new Broker<Product>();
            Product entity = new Product()
            {
                Name = "Batmobile",
                Number = "1337"
            };
            broker.Save(iDbConnection, ref entity);
            Product entityUpdated = new Product()
            {
                Id = entity.Id,
                Name = "Millennium Falcon",
                Number = entity.Number,
                Description = "Corellian YT-1300 light freighter"
            };
            broker.Save(iDbConnection, ref entityUpdated);

            Product entityRetrieved = broker.Get(iDbConnection, entity.Id);
            Assert.NotNull(entityRetrieved);
            Assert.AreEqual(entity.Id, entityRetrieved.Id);
            Assert.AreEqual(entityUpdated.Name, entityRetrieved.Name);
            Assert.AreEqual(entity.Number, entityRetrieved.Number);
            Assert.AreEqual(entityUpdated.Description, entityRetrieved.Description);
            // clean up
            broker.Delete(iDbConnection, entity.Id);
        }
        
    }
}
