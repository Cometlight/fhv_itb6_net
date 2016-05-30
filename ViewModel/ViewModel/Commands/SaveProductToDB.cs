using System;
using System.Windows.Input;
using Service;

namespace ViewModel.Commands
{
    public class SaveProductToDb : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Product product;

        /// <param name="product">May not be null</param>
        public SaveProductToDb(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            this.product = product;
            this.product.PropertyChanged += (sender, args) => RaiseCanExecuteChanged();
            this.product.UnsavedChangesChanged += (sender, value) => RaiseCanExecuteChanged();
        }

        protected void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return product.Model != null && product.Name != null && product.Number != null && product.UnsavedChanges;
        }

        /// <summary>
        /// Saves or updates the product to the database.
        /// </summary>
        /// <param name="parameter">unused</param>
        public void Execute(object parameter)
        {
            Domain.Product productToUpdate = product.Model;
            new CrudService<Domain.Product>().Save(ref productToUpdate);
            product.AllChangesSaved();
        }
    }
}
