using System;
using System.Collections.Generic;
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
using Domain;

namespace ManagerApp
{
    /// <summary>
    /// Interaction logic for ManageProductsUI.xaml
    /// </summary>
    public partial class ManageProductsUI : UserControl
    {
        public ManageProductsUI()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                Id = 1,
                Name = "Hammer"
            });
            products.Add(new Product()
            {
                Id = 2,
                Name = "Nails"
            });

            ListProducts.ItemsSource = products;
            // with DB:
            // listProducts.ItemsSource = productService.GetAll();
            // But not in the constructor! Maybe in the loaded event for example.
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

        private void ProductUi_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
