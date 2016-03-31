using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Assert.AreEqual(0, p.Price);
        }
    }
}
