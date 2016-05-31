using ViewModel;

namespace ManagerApplication
{
    /// <summary>
    /// Interaction logic for ProductUI.xaml
    /// </summary>
    public partial class ProductUI
    {
        public Product SelectedProduct
        {
            get { return DataContext as Product; }
            set
            {
                if (value == null)
                {
                    DataContext = new Product(new Domain.Product());
                }
                else
                {
                    DataContext = value;
                }
                
            }
        }

        public ProductUI()
        {
            InitializeComponent();
            SelectedProduct = null; // by default; can later be changed through the property setter
        }
    }
}
