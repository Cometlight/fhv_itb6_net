using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class Products : ViewModelBase
    {
        private BindingList<Product> productsList = new BindingList<Product>();

        public BindingList<Product> ProductsList
        {
            get { return productsList; }
            set
            {
                productsList = value;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public ICommand ExportProductsAsXml { get; private set; }
        public ICommand ImportProductsAsXml { get; private set; }
        public ICommand ReloadProductsFromDb { get; private set; }

        public Products()
        {
            ExportProductsAsXml = new ExportProductsAsXml(this);
            ImportProductsAsXml = new ImportProductsAsXml(this);
            ReloadProductsFromDb = new ReloadProductsFromDb(this);
        }
    }
}
