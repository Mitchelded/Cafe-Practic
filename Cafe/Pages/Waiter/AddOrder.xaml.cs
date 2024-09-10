using System;
using System.Windows;
using System.Windows.Input;
using Cafe.Models;

namespace Cafe.Pages.Waiter
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (CafeEntities db = new CafeEntities())
            {

                Order order = new Order()
                {
                    StartTime = DateTime.Now.TimeOfDay,
                    Status = "Not Take",
                    Count = int.Parse(tbCount.Text),
                    NumberTable = int.Parse(tbNumberTable.Text),
                    EmployeeID = CurrentUser.currentUser.ID,
                    Dishes = tbDishes.Text
                };

                db.Order.Add(order);
                db.SaveChanges();

            }

        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseLeftButtonDown += delegate { DragMove(); };
        }
    }
}
