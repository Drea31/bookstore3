using Microsoft.Win32;
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

namespace bookstore.AddWindows
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        private string pathphoto = null;

        public AddBookWindow()
        {
            InitializeComponent();
            
        }
        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            BooksWindow booksWindow = new BooksWindow();
            booksWindow.Show();
            this.Close();
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                 pathphoto = openFileDialog.FileName;
            }
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_ClickFullClose(object sender, RoutedEventArgs e)
        {
            BooksWindow booksWindow = new BooksWindow();
            booksWindow.Show();
            this.Close();
        }
        private void Button_ClickClose(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
