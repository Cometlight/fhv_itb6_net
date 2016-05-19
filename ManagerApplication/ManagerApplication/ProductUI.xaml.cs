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
using ViewModel;
using Service;

namespace ManagerApplication
{
    /// <summary>
    /// Interaction logic for ProductUI.xaml
    /// </summary>
    public partial class ProductUI : UserControl
    {
        public Product SelectedProduct
        {
            get { return DataContext as Product; }
            set { DataContext = value; }
        }

        public ProductUI()
        {
            InitializeComponent();
        }

        // TODO Add button in ManageProductsUI to reload whole list from DB
        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
//            Product productToUpdate = SelectedProduct;
//            new CrudService<Product>().Save(ref productToUpdate);
        }
    }
}
