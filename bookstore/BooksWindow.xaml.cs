using bookstore.AddWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для BooksWindow.xaml
    /// </summary>
    public partial class BooksWindow : Window
    {
        private int i=0;
        public BooksWindow()
        {
            InitializeComponent();
            ffEntities DBEntities = new ffEntities();
            LvBooks.ItemsSource = DBEntities.Books.ToList();
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

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddToCartProduct_Click(object sender, RoutedEventArgs e)
        {

        }
        public string selectedItemTitle;
        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (LvBooks.SelectedItem != null)
            {  
                var selectedItem = (Books)LvBooks.SelectedItem;
                using (var dbContext = new ffEntities())
                { 
                    var itemToDelete = dbContext.Books.FirstOrDefault(b => b.BookID == selectedItem.BookID); 
                    if (itemToDelete != null)
                    {
                        dbContext.Books.Remove(itemToDelete);
                        dbContext.SaveChanges();
                        LvBooks.ItemsSource = dbContext.Books.ToList();
                    }
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow();
            addBookWindow.Show();
            this.Close();
        }
    }
}
