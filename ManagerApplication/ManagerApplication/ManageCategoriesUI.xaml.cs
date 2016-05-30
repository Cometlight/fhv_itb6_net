using System;
using System.Windows;
using System.Windows.Controls;
using ViewModel;

namespace ManagerApplication
{
    /// <summary>
    /// Interaction logic for ManageCategoriesUI.xaml
    /// </summary>
    public partial class ManageCategoriesUI : UserControl
    {
        private bool initialized;

        public ManageCategoriesUI()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (!initialized)
            {
                initialized = true;
                try
                {
                    ProductCategories productCategories = ListCategories.DataContext as ProductCategories;
                    if (productCategories != null && productCategories.ReloadProductCategoriesFromDb.CanExecute(null))
                    {
                        productCategories.ReloadProductCategoriesFromDb.Execute(null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ButtonAddRow_OnClick(object sender, RoutedEventArgs e)
        {
            (ListCategories.DataContext as ProductCategories)?.ProductCategoriesList.Add(new ProductCategory(new Domain.ProductCategory()));
        }

        private void ButtonRemoveRow_OnClick(object sender, RoutedEventArgs e)
        {
            ProductCategory productCategory = ((FrameworkElement)sender).DataContext as ProductCategory;
            (ListCategories.DataContext as ProductCategories)?.ProductCategoriesList.Remove(productCategory);
        }
    }
}
