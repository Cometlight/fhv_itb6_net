using System.Windows;
using Database;

namespace ManagerApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DapperConfiguration.Initialize();
        }

        private void ManageProductsUI_OnLoaded(object sender, RoutedEventArgs e)
        {
            ManageProductsUI.Initialize();
        }

        private void ManageCategoriesUI_OnLoaded(object sender, RoutedEventArgs e)
        {
            ManageCategoriesUI.Initialize();
        }
    }
}
