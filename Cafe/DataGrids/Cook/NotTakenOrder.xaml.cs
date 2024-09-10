using Cafe.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cafe.DataGrids.Cook
{
    /// <summary>
    /// Логика взаимодействия для NotTakenOrder.xaml
    /// </summary>
    public partial class NotTakenOrder : Page
    {
        public NotTakenOrder()
        {
            InitializeComponent();
            using (CafeEntities db = new CafeEntities())
            {
                Dg.ItemsSource = db.Order.Where(x=> x.Status == "Not Take").ToList();
            }
        }

        private void btnTake_Click(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

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
                    Dg.ItemsSource = db.Order.Where(x => x.Status == "Not Take").ToList();
                }
            }
        }
    }
}
