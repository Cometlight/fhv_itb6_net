using System.Data;
using Database;
using Database.Broker;
using NUnit.Framework;
using ViewModel;
using ViewModel.Commands;
using ProductCategory = Domain.ProductCategory;

namespace Tests.ViewModel
{
    [TestFixture]
    class ReloadProductCategoriesFromDbTests
    {
        [Test]
        public void CanExecuteTest()
        {
            ReloadProductCategoriesFromDb cmd = new ReloadProductCategoriesFromDb(null);
            Assert.IsFalse(cmd.CanExecute(null));
            ReloadProductCategoriesFromDb cmd2 = new ReloadProductCategoriesFromDb(new ProductCategories());
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
            IBroker<ProductCategory> broker = new Broker<ProductCategory>();
            ProductCategory entity = new ProductCategory()
            {
                Name = "Notebooks"
            };
            broker.Save(iDbConnection, ref entity);

            // Do the actual test
            ProductCategories productCategories = new ProductCategories();
            Assert.IsEmpty(productCategories.ProductCategoriesList);
            ReloadProductCategoriesFromDb cmd = new ReloadProductCategoriesFromDb(productCategories);
            cmd.Execute(null);
            Assert.IsNotEmpty(productCategories.ProductCategoriesList);

            // Clean up the database
            broker.Delete(iDbConnection, entity);
            iDbConnection.Close();
        }
    }
}
