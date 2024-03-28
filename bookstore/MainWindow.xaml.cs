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

namespace bookstore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_ClickFullClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_ClickClose(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginTextBox.Text;
            string password = PasswordBox.Password;
            Console.WriteLine();
            using (ffEntities bDEntities = new ffEntities())
            {
                var user = bDEntities.Users.FirstOrDefault(u => u.Email == username && u.PasswordHash == password);

                if (user != null)
                {
                    int a = user.UserID;
                    MessageBox.Show("Вход успешен!");
                    MenuWindow menu = new MenuWindow(a);
                    menu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка входа проверьте email или пароль. ");
                }
            }
        }
    }
}
