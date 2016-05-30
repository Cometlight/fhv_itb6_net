using System.Windows;
using Database;

// TODO FIXME don't crash in case of missing DB
// TODO FIXME background thread/task so UI is not blocked
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
