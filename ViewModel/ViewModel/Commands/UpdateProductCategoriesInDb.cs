using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service;

namespace ViewModel.Commands
{
    public class UpdateProductCategoriesInDb : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly ProductCategories productCategories;

        public UpdateProductCategoriesInDb(ProductCategories productCategories)
        {
            this.productCategories = productCategories;
            this.productCategories.ProductCategoriesList.ListChanged += (sender, args) => RaiseCanExecuteChanged();
        }

        protected void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (productCategories.ProductCategoriesList == null || productCategories.ProductCategoriesList.Count == 0)
                return false;

            return productCategories.ProductCategoriesList.All(productCategory => !string.IsNullOrEmpty(productCategory.Name));
        }

        /// <summary>
        /// Saves or updates the product categories to the database.
        /// </summary>
        /// <param name="parameter">unused</param>
        public void Execute(object parameter)
        {
            CrudService<Domain.ProductCategory> crudService = new CrudService<Domain.ProductCategory>();
            List<int?> existingCategories = crudService.GetAll().Select(productCategory => productCategory.Id).ToList();

            foreach (ProductCategory viewModel in productCategories.ProductCategoriesList)
            {
                existingCategories.Remove(viewModel.Id);
                Domain.ProductCategory domain = viewModel.Model;
                crudService.Save(ref domain);
            }

            foreach (int? categoryToRemove in existingCategories)
            {
                if (categoryToRemove.HasValue)
                    crudService.Delete(categoryToRemove);
            }
        }
    }
}
