using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
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
using WpfApp1.Data;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        private List<Product> allProducts;

        public MainWindow(string role = "", string firstname = "", string secondname = "", string lastname= "")
        {
           Products = new ObservableCollection<Product>();
            InitializeComponent();
            DataContext = this;
            LoadProduct();
            fiotxt.Text = firstname +" " + lastname + " " + secondname;
            Roletxt.Text = role;
            if (role=="Администратор")
            {
                Admingrd.Visibility = Visibility.Visible;
            }
            if (role == "Менеджер")
            {
                Admingrd.Visibility = Visibility.Hidden;
            }
            if (role == "Авторизированный клиент")
            {
                Admingrd.Visibility = Visibility.Hidden;
            }


        }
      
        public void LoadProduct()
        {
            Products.Clear();
            using (var context = new TestDem1Context())
            {
                var products = context.Products.Include(p => p.Category).Include(p => p.Creater).Include(p => p.DetailOrders).Include(p => p.Unit).Include(p => p.Importer).Include(p => p.ProductName).ToList();
                allProducts = products.ToList();
                foreach (var p in products)
                {
                    Products.Add(p);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TextBox1.Text.Trim();
            Products.Clear(); // Очищаем существующую коллекцию

            var filtered = search == "" ? allProducts : allProducts.Where(p => p.ProductName.ProductType.Contains(search));

            foreach (var product in filtered)
            {
                Products.Add(product); // Добавляем по одному
            }
        }
    }
}