using System.Collections.ObjectModel;
using System.Windows;
using TomtensVerkstad.Database;
using TomtensVerkstad.Models;

namespace TomtensVerkstad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyDbContext _dbContext;
        private readonly MyUnitOfWork _unitOfWork;
        public ObservableCollection<Product> Products { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new MyDbContext();
            _unitOfWork = new MyUnitOfWork(_dbContext);
            Products = new ObservableCollection<Product>();
            DatagridProducts.ItemsSource = Products;

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadProductsAsync();
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                List<Product> products = await _unitOfWork.ProductRepository.GetAll();
                Products.Clear();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task RefreshProductsAsync()
        {
            try
            {
                // Hämta alla produkter från databasen 
                List<Product> latestProducts = await _unitOfWork.ProductRepository.GetAll();

                // Töm alla produkter i observableCollection
                Products.Clear();

                // Fyll observableCollection med den senaste listan
                foreach (var product in latestProducts)
                {
                    Products.Add(product);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            // Hämta valt namn och pris för den nya produkten. 
            string product_name = txtProductName.Text;
            string product_price = txtProductPrice.Text;
            decimal productPrice;

            if (decimal.TryParse(product_price, out productPrice) && product_name != null)
            {
                // Skapa en ny produkt 
                Product p = new()
                {
                    Name = product_name,
                    Price = productPrice
                };

                // Lägg till produkten i databasen 
                await _unitOfWork.ProductRepository.Add(p);
                await _unitOfWork.Complete();
                // Uppdatera produktlistan i UI 
                await RefreshProductsAsync();
            }
            else
            {

                MessageBox.Show("Please make sure to provide the input in correct format.");
            }
        }

        private async void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (DatagridProducts.SelectedItem is Product chosenProduct)
            {
                await _unitOfWork.ProductRepository.Delete(chosenProduct.ProductId);
                await _unitOfWork.Complete();
                // Uppdatera produktlistan i UI 
                await RefreshProductsAsync();

            }

            else if (DatagridProducts.SelectedItem == null)
            {
                MessageBox.Show("Please select a product in the list");
            }
        }
    }
}