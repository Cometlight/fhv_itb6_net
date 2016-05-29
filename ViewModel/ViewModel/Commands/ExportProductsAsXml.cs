using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Service;
using XML;

namespace ViewModel.Commands
{
    public class ExportProductsAsXml : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Products products;

        public ExportProductsAsXml(Products products)
        {
            this.products = products;
            this.products.PropertyChanged += (sender, args) => RaiseCanExecuteChanged();
            this.products.ProductsList.ListChanged += (sender, args) => RaiseCanExecuteChanged();
        }

        protected void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return products.ProductsList != null && products.ProductsList.Count > 0;
        }

        /// <summary>
        /// Saves products as xml to location specified by parameter.
        /// </summary>
        /// <param name="parameter">A string which represents the location to save the file.</param>
        public void Execute(object parameter)
        {
            string fileLocation = (string) parameter;
            List<Domain.Product> domainProducts = products.ProductsList.Select(product => product.Model).ToList();
            new XmlExportImport().Export<Domain.Product, ProductXml>(fileLocation, domainProducts);
        }
    }
}
