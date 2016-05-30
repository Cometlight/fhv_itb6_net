using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class ProductCategories : ViewModelBase
    {
        private bool unsavedChanges;
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

        public bool UnsavedChanges
        {
            get
            {
                return unsavedChanges;
            }
            set
            {
                unsavedChanges = value;
                UnsavedChangesChanged?.Invoke(this, value);
            }
        }

        public event Delegates.UnsavedChangesChangedEventHandler UnsavedChangesChanged;

        public ICommand ReloadProductCategoriesFromDb { get; private set; }
        public ICommand UpdateProductCategoriesInDb { get; private set; }

        public ProductCategories()
        {
            ReloadProductCategoriesFromDb = new ReloadProductCategoriesFromDb(this);
            UpdateProductCategoriesInDb = new UpdateProductCategoriesInDb(this);
            productCategoriesList.ListChanged += (sender, args) => UnsavedChanges = true;
        }

        public void AllChangesSaved()
        {
            UnsavedChanges = false;
        }

        public void AllChangesReverted()
        {
            UnsavedChanges = false;
        }
    }
}
