using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();
            LoadOrders();
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
        private void LoadOrders()
        {
            using (ffEntities dbEntities = new ffEntities())
            {
                dbEntities.Orders.ToList();
                var orders = (from o in dbEntities.Orders
                              join od in dbEntities.OrderDetails on o.OrderID equals od.OrderID
                              select new
                              {
                                  OrderID = o.OrderID,
                                  ProductName = od.BookID,
                                  Quantity = od.Quantity,
                                  TotalAmount = o.TotalAmount,
                                  OrderDate = o.OrderDate
                              }).ToList();
                
                ListOrders.Items.Clear();
                foreach (var order in orders)
                {
                    string[] row = { order.OrderID.ToString(), order.Quantity.ToString(), order.TotalAmount.ToString(), order.OrderDate.ToString() };
                    ListOrders.Items.Add(row);
                }
            }
            
            
        }

    }
}
