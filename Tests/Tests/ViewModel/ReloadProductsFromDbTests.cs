using System.Data;
using Database;
using Database.Broker;
using NUnit.Framework;
using ViewModel.Commands;
using ViewModel;
using Product = Domain.Product;

namespace Tests.ViewModel
{
    [TestFixture]
    class ReloadProductsFromDbTests
    {
        [Test]
        public void CanExecuteTest()
        {
            ReloadProductsFromDb cmd = new ReloadProductsFromDb(null);
            Assert.IsFalse(cmd.CanExecute(null));
            ReloadProductsFromDb cmd2 = new ReloadProductsFromDb(new Products());
            Assert.IsTrue(cmd2.CanExecute(null));
        }

        [Test]
        public void ExecuteTest()
        {
            // Note: Of course it would be nicer, if this Unit test would be independent,
            // like how it should be. For this to work, the layers underneath should be mocked.

            // Ensure that the database is not empty
            DapperConfiguration.Initialize();
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
            Products products = new Products();
            Assert.IsEmpty(products.ProductsList);
            ReloadProductsFromDb cmd = new ReloadProductsFromDb(products);
            cmd.Execute(null);
            Assert.IsNotEmpty(products.ProductsList);

            // Clean up the database
            broker.Delete(iDbConnection, entity);
            iDbConnection.Close();
        }
    }
}
