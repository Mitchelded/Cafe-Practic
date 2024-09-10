using Cafe.Models;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Cafe.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddShift.xaml
    /// </summary>
    public partial class AddShift : Window
    {
        public AddShift()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (CafeEntities db = new CafeEntities())
            {
                Employee emp = db.Employee.FirstOrDefault(x => x.Login == tbLogin.Text);
                if (emp!=null)
                {
                    if (dpDate.SelectedDate != null)
                    {
                        Shift shift = new Shift
                        {
                            Date = dpDate.SelectedDate.Value.Date
                        };
                        if (tbSTime.SelectedTime != null)
                        {
                            shift.StartTime = tbSTime.SelectedTime.Value.TimeOfDay;
                            if (tbETime.SelectedTime != null) shift.EndTime = tbETime.SelectedTime.Value.TimeOfDay;
                        }

                        shift.EmployeeID = emp.ID;

                        db.Shift.Add(shift);
                    }

                    db.SaveChanges();
                }
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
