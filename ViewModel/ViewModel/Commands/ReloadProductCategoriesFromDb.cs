using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service;

namespace ViewModel.Commands
{
    public class ReloadProductCategoriesFromDb : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly ProductCategories productCategories;

        public ReloadProductCategoriesFromDb(ProductCategories productCategories)
        {
            this.productCategories = productCategories;
        }

        protected void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return productCategories != null;
        }

        /// <summary>
        /// Reloads all the product categories from the database.
        /// </summary>
        /// <param name="parameter">unused</param>
        public void Execute(object parameter)
        {
            productCategories.ProductCategoriesList.Clear();
            IEnumerable<Domain.ProductCategory> domainProductCategories = new CrudService<Domain.ProductCategory>().GetAll();
            foreach (Domain.ProductCategory domainProductCategory in domainProductCategories)
            {
                productCategories.ProductCategoriesList.Add(new ProductCategory(domainProductCategory));
            }
        }
    }
}
