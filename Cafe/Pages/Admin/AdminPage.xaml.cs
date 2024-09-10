using System.Windows;
using System.Windows.Controls;
using Cafe.DataGrids.Admin;
using Cafe.DataGrids;

namespace Cafe.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void ShowOrder_Click(object sender, RoutedEventArgs e)
        {
            frameDG.Navigate(new OrderDg());
        }

        private void ShowShift_Click(object sender, RoutedEventArgs e)
        {
            frameDG.Navigate(new ShiftDg());
        }

        private void ShowEmp_Click(object sender, RoutedEventArgs e)
        {
            frameDG.Navigate(new EmployeeDg());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
        }

        private void AddShift_Click(object sender, RoutedEventArgs e)
        {
            AddShift addShift = new AddShift();
            addShift.ShowDialog();
        }
    }
}
