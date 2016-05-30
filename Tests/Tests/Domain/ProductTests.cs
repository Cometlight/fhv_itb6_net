using Domain;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    class ProductTests
    {
        [Test]
        public void DefaultConstructorTest()
        {
            Product p = new Product();
            Assert.AreEqual(null, p.Id);
            Assert.AreEqual(null, p.Name);
            Assert.AreEqual(null, p.Description);
            Assert.AreEqual(null, p.Image);
            Assert.AreEqual(null, p.Number);
            Assert.AreEqual(null, p.CategoryId);
            Assert.AreEqual(null, p.SupplierId);
            Assert.AreEqual(null, p.Price);
        }

        [Test]
        public void PropertyIdTest()
        {
            Product p = new Product();
            int id = 999;
            p.Id = id;
            Assert.AreEqual(id, p.Id);
        }

        [Test]
        public void PropertyNameTest()
        {
            Product p = new Product();
            string name = "Flux capacitor";
            p.Name = name;
            Assert.AreEqual(name, p.Name);
        }

        [Test]
        public void PropertyDescriptionTest()
        {
            Product p = new Product();
            string description = "I have the heart of a lion and a lifetime ban from the Toronto zoo.";
            p.Description = description;
            Assert.AreEqual(description, p.Description);
        }

        [Test]
        public void PropertyImageTest()
        {
            Product p = new Product();
            string image = "banner.jpg";
            p.Image = image;
            Assert.AreEqual(image, p.Image);
        }

        [Test]
        public void PropertyNumberTest()
        {
            Product p = new Product();
            string number = "42";
            p.Number = number;
            Assert.AreEqual(number, p.Number);
        }

        [Test]
        public void PropertyCategoryIdTest()
        {
            Product p = new Product();
            int id = 999;
            p.CategoryId = id;
            Assert.AreEqual(id, p.CategoryId);
        }

        [Test]
        public void PropertySupplierIdTest()
        {
            Product p = new Product();
            int id = 999;
            p.SupplierId = id;
            Assert.AreEqual(id, p.SupplierId);
        }

        [Test]
        public void PropertyPriceTest()
        {
            Product p = new Product();
            decimal price = 13.37M;
            p.Price = price;
            Assert.AreEqual(price, p.Price);
        }
    }
}
