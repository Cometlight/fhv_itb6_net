using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        public void ReloadAllProducts()
        {
            productsList.Clear();
            IEnumerable<Domain.Product> products = new CrudService<Domain.Product>().GetAll();
            foreach (Domain.Product product in products)
            {
                productsList.Add(new Product(product));
            }
        }
    }
}
