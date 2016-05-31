using System;
using System.Data;
using Database;
using Database.Broker;
using NUnit.Framework;
using Service;
using ViewModel.Commands;
using Product = Domain.Product;
using ProductViewModel = ViewModel.Product;

namespace Tests.ViewModel
{
    [TestFixture]
    class SaveProductToDbTests
    {
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

        [Test]
        public void CanExecuteTest()
        {
            Assert.Throws<ArgumentNullException>(() => new SaveProductToDb(null));

            ProductViewModel product = new ProductViewModel(new Product());
            SaveProductToDb cmd = new SaveProductToDb(product);
            Assert.IsFalse(cmd.CanExecute(null));
            
            product.Name = "Flux capacitor";
            product.Number = "42";
            Assert.IsTrue(cmd.CanExecute(null));
            cmd.Execute(null);
            Assert.IsFalse(cmd.CanExecute(null));   // Because there are no unsaved changes
            new CrudService<Product>().Delete(product.Id);
        }

        [Test]
        public void ExecuteTest()
        {
            // Note: Of course it would be nicer, if this Unit test would be independent,
            // like how it should be. For this to work, the layers underneath should be mocked.

            // Store something to the database which should be updated thereafter
            IDbConnection iDbConnection = new ConnectionManager(0).GetDbConnection();
            iDbConnection.Open();
            IBroker<Product> broker = new Broker<Product>();
            Product entity = new Product()
            {
                Name = "Flux capacitor",
                Number = "42"
            };
            broker.Save(iDbConnection, ref entity);

            // Do the actual test
            Product entityUpdated = new Product()
            {
                Name = "Batmobile",
                Number = "1337"
            };
            ProductViewModel entityViewModel = new ProductViewModel(entityUpdated);
            SaveProductToDb cmd = new SaveProductToDb(entityViewModel);
            cmd.Execute(null);
            Product entityFromDb = new CrudService<Product>().Get(entityViewModel.Model.Id);
            Assert.AreEqual(entityUpdated.Name, entityFromDb.Name);
            Assert.AreEqual(entityUpdated.Number, entityFromDb.Number);

            // Clean up the database
            broker.Delete(iDbConnection, entity.Id);
            broker.Delete(iDbConnection, entityViewModel.Model.Id);
            iDbConnection.Close();
        }
    }
}
