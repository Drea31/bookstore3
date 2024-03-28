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
using System.Windows.Shapes;

namespace bookstore
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {

        public MenuWindow(int id)
        {
            InitializeComponent();
            ffEntities bDEntities = new ffEntities();
            Users user = bDEntities.Users.FirstOrDefault(u => u.UserID == id);
            User.Text = $"Пользователь: \n{user.FirstName} {user.LastName}";     
        }

        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void Button_ClickOrders(object sender, RoutedEventArgs e)
        {
            OrdersWindow orders = new OrdersWindow();
            orders.Show();
            this.Close();
        }

        private void Button_Click_Users(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Authors(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Books(object sender, RoutedEventArgs e)
        {
            BooksWindow books = new BooksWindow();
            books.Show();
            this.Close();
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

    }
}