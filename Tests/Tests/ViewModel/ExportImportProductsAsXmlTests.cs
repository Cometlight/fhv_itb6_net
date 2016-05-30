using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using NUnit.Framework;
using ViewModel;
using ViewModel.Commands;

namespace Tests.ViewModel
{
    [TestFixture]
    class ExportImportProductsAsXmlTests
    {
        readonly string fileName = "ExportProductsAsXmlTests_NUnit.xml";
        
        [Test]
        public void ExportCanExecuteTest()
        {
            Assert.Throws<ArgumentNullException>(() => new ExportProductsAsXml(null));

            Products products = new Products();
            ExportProductsAsXml cmd = new ExportProductsAsXml(products);
            Assert.IsFalse(cmd.CanExecute(null));

            products.ProductsList.Add(new Product(new global::Domain.Product()));
            Assert.IsTrue(cmd.CanExecute(null));
        }
        
        [Test]
        public void ImportCanExecuteTest()
        {
            Assert.IsTrue(new ImportProductsAsXml(null).CanExecute(null));
        }
        
        [Test]
        public void ExportImportExecuteTest()
        {
            global::Domain.Product product1 = new global::Domain.Product
            {
                Name = "Flux capacitor",
                Number = "42"
            };
            global::Domain.Product product2 = new global::Domain.Product
            {
                Name = "Batmobile",
                Price = 13.37M
            };
            Products productsToExport = new Products();
            productsToExport.ProductsList = new BindingList<Product>();
            productsToExport.ProductsList.Add(new Product(product1));
            productsToExport.ProductsList.Add(new Product(product2));

            // Test Export
            ExportProductsAsXml cmdExport = new ExportProductsAsXml(productsToExport);
            Assert.Throws<ArgumentNullException>(() => cmdExport.Execute(null));
            
            cmdExport.Execute(fileName);
            Assert.IsTrue(File.Exists(fileName));

            // Test Import
            Products productsImported = new Products();
            ImportProductsAsXml cmdImport = new ImportProductsAsXml(productsImported);
            cmdImport.Execute(fileName);
            Assert.AreEqual(2, productsImported.ProductsList.Count);
            Assert.AreEqual(product1.Name, productsImported.ProductsList.First().Name);
            Assert.AreEqual(product1.Number, productsImported.ProductsList.First().Number);
            Assert.AreEqual(product1.Id, productsImported.ProductsList.First().Id);
            Assert.AreEqual(product1.Price, productsImported.ProductsList.First().Price);
            Assert.AreEqual(product2.Name, productsImported.ProductsList.Last().Name);
            Assert.AreEqual(product2.Number, productsImported.ProductsList.Last().Number);
            Assert.AreEqual(product2.Id, productsImported.ProductsList.Last().Id);
            Assert.AreEqual(product2.Price, productsImported.ProductsList.Last().Price);

            // Clean up
            File.Delete(fileName);
        }
    }
}
