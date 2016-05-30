using System.Linq;
using NUnit.Framework;
using ViewModel;

namespace Tests.ViewModel
{
    [TestFixture]
    class ProductCategoriesTests
    {
        [Test]
        public void UnsavedChangesTest()
        {
            ProductCategories categories = new ProductCategories();
            Assert.IsFalse(categories.UnsavedChanges);

            categories.ProductCategoriesList.Add(new ProductCategory(new global::Domain.ProductCategory()));
            Assert.IsTrue(categories.UnsavedChanges);
            // Assume the changes have been saved
            categories.AllChangesSaved();
            Assert.IsFalse(categories.UnsavedChanges);

            categories.ProductCategoriesList.First().Name = "Flux capacitor";
            Assert.IsTrue(categories.UnsavedChanges);
            // Assume the changes have been reverted
            categories.AllChangesReverted();
            Assert.IsFalse(categories.UnsavedChanges);
        }
    }
}
