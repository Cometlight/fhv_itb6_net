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
    }
}
