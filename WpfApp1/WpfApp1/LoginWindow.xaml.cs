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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        AuthService authService;
        public LoginWindow()
        {
            InitializeComponent();
            authService = new AuthService();
        }

        // вход с ролью
        private void Loginbtm_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            string login = logintxt.Text;
            string password = passwordtxt.Password;
            User user = authService.TryAuth(login, password);
            if (user != null)
                new MainWindow(user.Role.RoleName, user.FirstName, user.SecondName, user.LastName).Show();
            {
              
                this.Close();
            }
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль");
            }



            
        }

        private void Goustbtm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
