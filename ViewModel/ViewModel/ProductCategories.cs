using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class ProductCategories : ViewModelBase
    {
        private BindingList<ProductCategory> productCategoriesList = new BindingList<ProductCategory>();

        public BindingList<ProductCategory> ProductCategoriesList
        {
            get { return productCategoriesList; }
            set
            {
                productCategoriesList = value;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public ICommand ReloadProductCategoriesFromDb { get; private set; }
        public ICommand UpdateProductCategoriesInDb { get; private set; }

        public ProductCategories()
        {
            ReloadProductCategoriesFromDb = new ReloadProductCategoriesFromDb(this);
            UpdateProductCategoriesInDb = new UpdateProductCategoriesInDb(this);
        }
    }
}
