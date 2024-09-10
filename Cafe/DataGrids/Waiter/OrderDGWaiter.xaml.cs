using Cafe.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Cafe.DataGrids.Waiter
{
    /// <summary>
    /// Логика взаимодействия для OrderDGWaiter.xaml
    /// </summary>
    public partial class OrderDgWaiter : Page
    {
        public OrderDgWaiter()
        {
            InitializeComponent();
            using (CafeEntities db = new CafeEntities())
            {
                List<Order> order = db.Order.Where(x => x.EmployeeID == CurrentUser.currentUser.ID).ToList();
                Dg.ItemsSource = order;
                DgComboStatus.ItemsSource = order;
            }
        }
    }
}
