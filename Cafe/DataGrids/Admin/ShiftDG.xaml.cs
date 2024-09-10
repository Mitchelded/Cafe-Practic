using System;
using System.Linq;
using System.Windows.Controls;
using Cafe.Models;

namespace Cafe.DataGrids.Admin
{
    /// <summary>
    /// Логика взаимодействия для ShiftDG.xaml
    /// </summary>
    public partial class ShiftDg : Page
    {
        public ShiftDg()
        {
            InitializeComponent();
            using (CafeEntities db = new CafeEntities())
            {
                DateTime dateTime = DateTime.Now.Date;
                Dg.ItemsSource = db.Shift.Where(x => x.Date == dateTime).ToList();

            }
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            using (CafeEntities db = new CafeEntities())
            {
                if (dpDate.SelectedDate != null)
                {
                    DateTime dateTime = dpDate.SelectedDate.Value.Date;
                    Dg.ItemsSource = db.Shift.Where(x => x.Date == dateTime).ToList();
                }
            }
        }
    }
}
