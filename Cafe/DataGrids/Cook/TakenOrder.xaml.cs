using Cafe.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cafe.DataGrids.Cook
{
    /// <summary>
    /// Логика взаимодействия для TakenOrder.xaml
    /// </summary>
    public partial class TakenOrder : Page
    {
        public TakenOrder()
        {
            InitializeComponent();
            using (CafeEntities db =  new CafeEntities())
            {
                Dg.ItemsSource = db.Order.Where(x => x.EmployeeID == CurrentUser.currentUser.ID).ToList();
            }
        }

        private void btnPreparing_Click(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem1 = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var menuItem2 = (MenuItem)menuItem1.Parent;

            var contextMenu = (ContextMenu)menuItem2.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toUpdateFromBindedList = (Order)item.SelectedCells[0].Item;

            using (CafeEntities db = new CafeEntities())
            {
                Order order = db.Order.FirstOrDefault(x => x.ID == toUpdateFromBindedList.ID);
                if (order != null)
                {
                    order.EmployeeID = CurrentUser.currentUser.ID;
                    order.Status = "Preparing";
                    db.SaveChanges();
                    Dg.ItemsSource = db.Order.Where(x => x.EmployeeID == CurrentUser.currentUser.ID).ToList();
                }
            }
        }

        private void btnReady_Click(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem1 = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var menuItem2 = (MenuItem)menuItem1.Parent;

            var contextMenu = (ContextMenu)menuItem2.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toUpdateFromBindedList = (Order)item.SelectedCells[0].Item;

            using (CafeEntities db = new CafeEntities())
            {
                Order order = db.Order.FirstOrDefault(x => x.ID == toUpdateFromBindedList.ID);
                if (order != null)
                {
                    order.EmployeeID = CurrentUser.currentUser.ID;
                    order.Status = "Ready";
                    db.SaveChanges();
                    Dg.ItemsSource = db.Order.Where(x => x.EmployeeID == CurrentUser.currentUser.ID).ToList();
                }
            }
        }
    }
}
