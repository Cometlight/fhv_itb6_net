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
    public class SaveProductToDb : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Product product;

        public SaveProductToDb(Product product)
        {
            this.product = product;
            this.product.PropertyChanged += ProductOnPropertyChanged;
        }

        private void ProductOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            RaiseCanExecuteChanged();
        }

        protected void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return product.Model != null && product.Name != null && product.Number != null;
        }

        /// <summary>
        /// Saves or updates the product to the database.
        /// </summary>
        /// <param name="parameter">unused</param>
        public void Execute(object parameter)
        {
            Domain.Product productToUpdate = product.Model;
            new CrudService<Domain.Product>().Save(ref productToUpdate);
        }
    }
}
