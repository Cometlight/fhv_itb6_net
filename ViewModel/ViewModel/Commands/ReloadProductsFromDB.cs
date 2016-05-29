using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service;

namespace ViewModel.Commands
{
    public class ReloadProductsFromDb : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Products products;

        public ReloadProductsFromDb(Products products)
        {
            this.products = products;
        }

        protected void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return products != null;
        }

        /// <summary>
        /// Reloads all the products from the database.
        /// </summary>
        /// <param name="parameter">unused</param>
        public void Execute(object parameter)
        {
            products.ProductsList.Clear();
            IEnumerable<Domain.Product> domainProducts = new CrudService<Domain.Product>().GetAll();
            foreach (Domain.Product domainProduct in domainProducts)
            {
                products.ProductsList.Add(new Product(domainProduct));
            }
        }
    }
}
