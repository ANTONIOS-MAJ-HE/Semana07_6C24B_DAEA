using Business;
using Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semana07_6C24B_DAEA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PersonBusiness productBussiness = new PersonBusiness();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            PersonBusiness business = new PersonBusiness();
            dataProducto.ItemsSource = business.Get();
        }

        private void BuscarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NombreTextBox.Text;

                List<Product> products = productBussiness.Get18(name);

                dataProducto.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }

        private void ActualizarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            PersonBusiness business = new PersonBusiness();
            dataProducto.ItemsSource = business.Get();
        }

        private void EliminarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonBusiness business = new PersonBusiness();
                int productId = Convert.ToInt32(IdProductTextBox.Text);
                business.Delete(productId);
                ListarProductoButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }

        private void InsertarProductoButton_Click(object sender, RoutedEventArgs e)
        {
        
            try
            {
                PersonBusiness business = new PersonBusiness();
                Product newProduct = new Product
                {
                    product_id = Convert.ToInt32(IdProductTextBox.Text),
                    name = NombreTextBox.Text,
                    price = Convert.ToDecimal(PriceTextBox.Text),
                    stock = Convert.ToInt32(StockTextBox.Text)
                };

                business.Insert(newProduct);
                ListarProductoButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }

        private void dataProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataProducto.SelectedItem is Product guia)
            {
                IdProductTextBox.Text = guia.product_id.ToString(); //es entero convertir
                NombreTextBox.Text = guia.name;
                PriceTextBox.Text = guia.price.ToString();
                StockTextBox.Text = guia.stock.ToString();
                //es date time convertir
            }
        }

    }
}