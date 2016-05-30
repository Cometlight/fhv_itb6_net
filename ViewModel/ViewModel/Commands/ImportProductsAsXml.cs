using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Service;
using XML;

namespace ViewModel.Commands
{
    public class ImportProductsAsXml : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Products products;

        public ImportProductsAsXml(Products products)
        {
            this.products = products;
        }

        protected void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Imports products from xml file, which is located as specified in the parameter.
        /// </summary>
        /// <param name="parameter">A string which represents the location of the file to load.</param>
        public void Execute(object parameter)
        {
            string fileLocation = (string) parameter;
            List<Domain.Product> productsLoaded = new XmlExportImport().Import<Domain.Product, ProductXml>(fileLocation);
            List<Product> viewModelProducts = productsLoaded.Select(product => new Product(product)).ToList();
            products.ProductsList = new BindingList<Product>(viewModelProducts);
        }
    }
}
