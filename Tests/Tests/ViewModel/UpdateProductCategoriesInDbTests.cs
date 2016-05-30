using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Database;
using Database.Broker;
using NUnit.Framework;
using ViewModel;
using ViewModel.Commands;
using ProductCategory = Domain.ProductCategory;

namespace Tests.ViewModel
{
    [TestFixture]
    class UpdateProductCategoriesInDbTests
    {
        [Test]
        public void CanExecuteTest()
        {
            Assert.Throws<ArgumentNullException>(() => new UpdateProductCategoriesInDb(null));

            ProductCategories categories = new ProductCategories();
            UpdateProductCategoriesInDb cmd = new UpdateProductCategoriesInDb(categories);
            Assert.IsFalse(cmd.CanExecute(null));

            var category = new global::ViewModel.ProductCategory(new ProductCategory());
            categories.ProductCategoriesList.Add(category);
            Assert.IsFalse(cmd.CanExecute(null));

            categories.ProductCategoriesList.First().Name = "Notebooks";
            Assert.IsTrue(cmd.CanExecute(null));
        }

        [Test]
        public void ExecuteTest()
        {
            // Note: Of course it would be nicer, if this Unit test would be independent,
            // like how it should be. For this to work, the layers underneath should be mocked.

            // Store something to the database which should be updated thereafter
            DapperConfiguration.Initialize();
            IDbConnection iDbConnection = new ConnectionManager(0).GetDbConnection();
            iDbConnection.Open();
            IBroker<ProductCategory> broker = new Broker<ProductCategory>();
            ProductCategory entity = new ProductCategory()
            {
                Name = "USB sticks"
            };
            broker.Save(iDbConnection, ref entity);
            ProductCategory entity2 = new ProductCategory()
            {
                Name = "Wastebins"
            };
            broker.Save(iDbConnection, ref entity2);

            // Do the actual test
            var category = new global::ViewModel.ProductCategory(new ProductCategory())
            {
                Id = entity.Id,
                Name = "Keyboards"
            };
            ProductCategories categories = new ProductCategories();
            categories.ProductCategoriesList = new BindingList<global::ViewModel.ProductCategory>();
            categories.ProductCategoriesList.Add(category);

            UpdateProductCategoriesInDb cmd = new UpdateProductCategoriesInDb(categories);
            cmd.Execute(null);

            // entity2 deleted through command
            Assert.AreEqual(1, categories.ProductCategoriesList.Count);
            Assert.AreEqual(entity.Id, categories.ProductCategoriesList.First().Id);

            // Clean up the database
            broker.Delete(iDbConnection, entity.Id);
            iDbConnection.Close();
        }
    }
}
