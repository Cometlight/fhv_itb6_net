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
using Domain;
using Service;

namespace ManagerApplication
{
    /// <summary>
    /// Interaction logic for ManageProductsUI.xaml
    /// </summary>
    public partial class ManageProductsUI : UserControl
    {
        private bool initialized = false;

        public ManageProductsUI()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (!initialized)
            {
                initialized = true;

                IEnumerable<Product> products = new CrudService<Product>().GetAll();
                ListProducts.ItemsSource = products;

                ProductSearch.Initialize(ListProducts);
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
            
        }

        private void ButtonImport_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
