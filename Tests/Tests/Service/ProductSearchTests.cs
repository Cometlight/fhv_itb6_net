using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using NUnit.Framework;
using Service;

namespace Tests.Service
{
    [TestFixture]
    class ProductSearchTests
    {
        private IList<Product> products;
        private Product productN, product0, product1, product2;

        [SetUp]
        public void SetUp()
        {
            productN = new Product();
            product0 = new Product()
            {
                Id = 0,
                CategoryId = 0,
                Description = "description01",
                Image = "image01",
                Name = "name01",
                Number = "01",
                Price = 1,
                SupplierId = 1
            };
            product1 = new Product()
            {
                Id = 1,
                CategoryId = 1,
                Description = "description02",
                Image = "image02",
                Name = "name02",
                Number = "02",
                Price = 2,
                SupplierId = 2
            };
            product2 = new Product()
            {
                Id = 2,
                CategoryId = 1,
                Description = "description02",
                Image = "image02",
                Name = "name02",
                Number = "02",
                Price = 2,
                SupplierId = 2
            };
            products = new List<Product>() {productN, product0, product1, product2};
        }

        [Test]
        public void SearchDefault()
        {
            ICollection<Product> results = new ProductSearch().Search(products);
            Assert.AreEqual(products.Count, results.Count);
        }

        [Test]
        public void SearchNull()
        {
            ICollection<Product> results = new ProductSearch().Search(products, null, null, null, null, null, null, null);
            Assert.AreEqual(products.Count, results.Count);
        }

        [Test]
        public void SearchCombinedAll()
        {
            ICollection<Product> results = new ProductSearch().Search(products, id: 0, number: "01", name: "name01", minPrice: 1, maxPrice: 1, productCategoryId: 0, supplierId: 1);
            Assert.AreEqual(1, results.Count);
            Assert.IsTrue(results.Contains(product0));
        }

        [Test]
        public void SearchId1Result()
        {
            ICollection<Product> results = new ProductSearch().Search(products, 0);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(product0.Id, results.First().Id);
        }

        [Test]
        public void SearchId0Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, -1);
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void SearchNumber0Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, number: "00");
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void SearchNumber2Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, number:"02");
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Contains(product1));
            Assert.IsTrue(results.Contains(product2));
        }

        [Test]
        public void SearchName0Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, name: "noname");
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void SearchName1Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, name: "name01");
            Assert.AreEqual(1, results.Count);
            Assert.IsTrue(results.Contains(product0));
        }

        [Test]
        public void SearchMinPrice0Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, minPrice: 999);
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void SearchMinPrice2Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, minPrice: 2);
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Contains(product1));
            Assert.IsTrue(results.Contains(product2));
        }

        [Test]
        public void SearchMaxPrice0Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, maxPrice: 0);
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void SearchMaxPrice1Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, maxPrice: 1);
            Assert.AreEqual(1, results.Count);
            Assert.IsTrue(results.Contains(product0));
        }

        [Test]
        public void SearchProductCategory0Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, productCategoryId: 999);
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void SearchProductCategory2Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, productCategoryId: 1);
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Contains(product1));
            Assert.IsTrue(results.Contains(product2));
        }

        [Test]
        public void SearchSupplier0Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, supplierId: 999);
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void SearchSupplier2Results()
        {
            ICollection<Product> results = new ProductSearch().Search(products, supplierId: 2);
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Contains(product1));
            Assert.IsTrue(results.Contains(product2));
        }
    }
}
