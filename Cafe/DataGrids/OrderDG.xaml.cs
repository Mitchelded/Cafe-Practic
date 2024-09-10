using Cafe.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Cafe.DataGrids
{
    /// <summary>
    /// Логика взаимодействия для OrderDG.xaml
    /// </summary>
    public partial class OrderDg : Page
    {
        public OrderDg()
        {
            InitializeComponent();
            using (CafeEntities db = new CafeEntities())
            {
                var emp = CurrentUser.currentUser;
                switch (emp.Role.Trim())
                {
                    case "Admin":
                        List<Order> orderA = db.Order.ToList();
                        Dg.ItemsSource = orderA;
                        //DgComboStatus.ItemsSource = orderA;
                        break;
                    case "Waiter":
                        List<Order> orderW = db.Order.Where(x => x.EmployeeID == emp.ID).ToList();
                        Dg.ItemsSource = orderW;
                        //DgComboStatus.ItemsSource = orderW; 
                        break;
                } 
            }
        }
    }
}
