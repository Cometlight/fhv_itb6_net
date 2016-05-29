using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Service;
using ViewModel;
using Product = Domain.Product;

namespace ManagerApplication
{
    /// <summary>
    /// Interaction logic for ProductSearch.xaml
    /// </summary>
    public partial class ProductSearch
    {
        private Products searchResultsTarget;
        private readonly ICollection<TextBox> textBoxes;


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
            };
        }
        
        public void Initialize(Products searchResultsTarget)
        {
            this.searchResultsTarget = searchResultsTarget;

            // Note that it would be a cleaner approach to set as much as possible in the XAML file, like it was done for
            // the ManageProductsUI and ProductUI
            List<ProductCategory> categories = new List<ProductCategory>();
            categories.AddRange(new CrudService<Domain.ProductCategory>().GetAll().Select(model => new ProductCategory(model)));
            ComboBoxCategory.ItemsSource = categories;
            ComboBoxCategory.DisplayMemberPath = "Name";

            // TODO Here, a view model should also be used, like it was did above
            List<Domain.Supplier> suppliers = new CrudService<Domain.Supplier>().GetAll().ToList();
            ComboBoxSupplier.ItemsSource = suppliers;
            ComboBoxSupplier.DisplayMemberPath = "Name";
        }

        private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
        {
            ResetWarningBackgroundColors();

            int? id = GetSearchId();
            string number = GetSearchNumber();
            string name = GetSearchName();
            decimal? minPrice = GetSearchMinPrice();
            decimal? maxPrice = GetSearchMaxPrice();
            int? productCategoryId = GetSearchProductCategoryId();
            int? supplierId = GetSearchSupplierId();

            // It would be better to use the database facade, which could construct
            // the needed SQL query, and query it directly from the database. This
            // way, not all products would have to be loaded.
            // However, the goal of the method ProductSearch.Search() is to demonstrate LINQ.
            IEnumerable<Product> candidates = new CrudService<Product>().GetAll();
            IEnumerable<Product> productsFound = new Service.ProductSearch().Search(candidates, id, number, name, minPrice, maxPrice, productCategoryId, supplierId);
            
            searchResultsTarget.ProductsList =
                new BindingList<ViewModel.Product>(
                    productsFound.Select(product => new ViewModel.Product(product)).ToList());
        }

        private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Text = "";
            }
            ResetWarningBackgroundColors();
            ComboBoxCategory.SelectedItem = null;
            ComboBoxSupplier.SelectedItem = null;
        }

        private void ResetWarningBackgroundColors()
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Background = Brushes.White;
            }
        }
        
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

        private int? GetSearchProductCategoryId()
        {
            ProductCategory productCategory = ComboBoxCategory.SelectionBoxItem as ProductCategory;
            return productCategory?.Id;
        }

        private int? GetSearchSupplierId()
        {
            Domain.Supplier supplier = ComboBoxCategory.SelectionBoxItem as Domain.Supplier;
            return supplier?.Id;
        }
    }
}
