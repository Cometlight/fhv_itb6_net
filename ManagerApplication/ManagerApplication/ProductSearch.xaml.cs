using System;
using System.Collections;
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
using Service;

namespace ManagerApplication
{
    /// <summary>
    /// Interaction logic for ProductSearch.xaml
    /// </summary>
    public partial class ProductSearch : UserControl
    {
        private DataGrid searchResultsTarget;
        private ICollection<TextBox> textBoxes;


        public ProductSearch()
        {
            InitializeComponent();
            textBoxes = new List<TextBox>()
            {
                TextBoxId,
                TextBoxName,
                TextBoxNumber,
                TextBoxMinPrice,
                TextBoxMaxPrice
            };// TODO add comboboxes
        }

        // TODO: This does not look very elegent @ System.Windows.Controls.DataGrid
        public void Initialize(DataGrid searchResultsTarget)
        {
            this.searchResultsTarget = searchResultsTarget;
            var categories = new List<string>() {"Category 1", "Category 2"};   // TODO Load from DB
            ComboBoxCategory.ItemsSource = categories;
            var supplier = new List<string>() { "Supplier 1", "Supplier 2" };   // TODO Load from DB
            ComboBoxSupplier.ItemsSource = supplier;
        }

        private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
        {
            ResetWarningBackgroundColors();

            int? id = GetSearchId();
            string number = GetSearchNumber();
            string name = GetSearchName();
            decimal? minPrice = GetSearchMinPrice();
            decimal? maxPrice = GetSearchMaxPrice();

            // It would be better to use the database facade, which could construct
            // the needed SQL query, and query it directly from the database. This
            // way, not all products would have to be loaded.
            // However, the goal of the method ProductSearch.Search() is to demonstrate LINQ.
            IEnumerable<Product> candidates = new CrudService<Product>().GetAll();
            IEnumerable<Product> productsFound = new Service.ProductSearch().Search(candidates, id, number, name, minPrice, maxPrice);
            // TODO maybe check if initialized already or sth.
            searchResultsTarget.ItemsSource = productsFound;
        }

        private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Text = "";
            }
            ResetWarningBackgroundColors();
        }

        private void ResetWarningBackgroundColors()
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Background = Brushes.White;
            }
        }

        // TODO Refactor the GetSearch* methods (problem: code duplication)
        private int? GetSearchId()
        {
            int? id = null;
            try
            {
                id = int.Parse(TextBoxId.Text);
            }
            catch (FormatException e)
            {
                // Only warn the user if text box is not empty
                if (TextBoxId.Text.Length > 0)
                    TextBoxId.Background = Brushes.Red;
            }
            return id;
        }

        private string GetSearchNumber()
        {
            if (TextBoxNumber.Text.Length > 0)
                return TextBoxNumber.Text;
            return null;
        }

        private string GetSearchName()
        {
            if (TextBoxName.Text.Length > 0)
                return TextBoxName.Text;
            return null;
        }

        private decimal? GetSearchMinPrice()
        {
            decimal? minPrice = null;
            try
            {
                minPrice = decimal.Parse(TextBoxMinPrice.Text);
            }
            catch (FormatException e)
            {
                // Only warn the user if text box is not empty
                if (TextBoxMinPrice.Text.Length > 0)
                    TextBoxMinPrice.Background = Brushes.Red;
            }
            return minPrice;
        }

        private decimal? GetSearchMaxPrice()
        {
            decimal? maxPrice = null;
            try
            {
                maxPrice = decimal.Parse(TextBoxMaxPrice.Text);
            }
            catch (FormatException e)
            {
                // Only warn the user if text box is not empty
                if (TextBoxMaxPrice.Text.Length > 0)
                    TextBoxMaxPrice.Background = Brushes.Red;
            }
            return maxPrice;
        }
    }
}
