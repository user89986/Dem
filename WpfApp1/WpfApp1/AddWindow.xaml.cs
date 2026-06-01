using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Data;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        
        public AddWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new Product
                {
                    ProductsId = ProductIdtxt.Text,
                    ProductNameId = Convert.ToInt32(ProductNametxt.Text),
                    UnitId = Convert.ToInt32(Unittxt.Text),
                    Price = Convert.ToInt32(Pricetxt.Text),
                    ImporterId = Convert.ToInt32(Importertxt.Text),
                    CreaterId = Convert.ToInt32(Creatertxt.Text),
                    CategoryId = Convert.ToInt32(Categorytxt.Text),
                    Sale = Convert.ToInt32(Saletxt.Text),
                    Quantity = Convert.ToInt32(Quantitytxt.Text),
                    Info = Infotxt.Text,
                    Image = Imagetxt.Text,

                };
                using (var context = new TestDem1Context())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                    MessageBox.Show("Сохранено!");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Неверное введены данные");
            }



                
        }
    }
}
