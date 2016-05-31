using System;
using System.Windows;
using System.Windows.Controls;
using ViewModel;
using Microsoft.Win32;

namespace ManagerApplication
{
    /// <summary>
    /// Interaction logic for ManageProductsUI.xaml
    /// </summary>
    public partial class ManageProductsUI
    {
        private bool initialized;

        public ManageProductsUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads all the products from the database using a command.
        /// </summary>
        public void Initialize()
        {
            if (!initialized)
            {
                initialized = true;
                try
                {
                    Products products = ListProducts.DataContext as Products;
                    if (products != null && products.ReloadProductsFromDb.CanExecute(null))
                    {
                        products.ReloadProductsFromDb.Execute(null);
                    }
                    ProductSearch.Initialize(products);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ListProducts_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ProductUi.SelectedProduct = ListProducts.SelectedItem as Product;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Exports the products to an XML file.
        /// </summary>
        private void ButtonExport_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog {Filter = "XML files (*.xml)|*.xml"};
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;
                var viewModel = (Products) DataContext;
                if (viewModel.ExportProductsAsXml.CanExecute(null))
                {
                    viewModel.ExportProductsAsXml.Execute(fileName);
                }
            }
        }

        /// <summary>
        /// Imports products from an XML file.
        /// </summary>
        private void ButtonImport_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "XML files (*.xml)|*.xml" };
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                var viewModel = (Products)DataContext;
                if (viewModel.ImportProductsAsXml.CanExecute(null))
                {
                    viewModel.ImportProductsAsXml.Execute(fileName);
                }
            }
        }
    }
}
