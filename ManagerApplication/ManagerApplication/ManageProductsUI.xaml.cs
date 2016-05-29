using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Database;
using Database.Broker;
using ViewModel;
using Microsoft.Win32;
using Service;
using XML;
using System.Linq;
using ViewModel.Commands;

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
