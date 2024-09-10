using Cafe.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cafe.DataGrids.Admin
{
    /// <summary>
    /// Логика взаимодействия для EmployeeDG.xaml
    /// </summary>
    public partial class EmployeeDg : Page
    {
        public EmployeeDg()
        {
            InitializeComponent();
            using (CafeEntities db = new CafeEntities())
            {
                List<Employee> employees = db.Employee.ToList();
                Dg.ItemsSource = employees;
                //DgComboRole.ItemsSource = employees;
                //DgComboStatus.ItemsSource = employees;
            }
        }

        private void btnFired_Click(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toUpdateFromBindedList = (Employee)item.SelectedCells[0].Item;

            using(CafeEntities db = new CafeEntities())
            {
                Employee emp = db.Employee.FirstOrDefault(x=> x.ID == toUpdateFromBindedList.ID);
                if (emp != null)
                {
                    emp.Status = "Fired";
                    db.SaveChanges();
                }
            }
        }
    }
}
