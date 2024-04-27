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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonBusiness business = new PersonBusiness();
            dgPeople.ItemsSource = business.Get();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtProductName.Text;

                List<Product> products = productBussiness.Get18(name);

                dgPeople.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }
    }
}