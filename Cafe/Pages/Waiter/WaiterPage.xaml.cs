using Cafe.DataGrids;
using System.Windows;
using System.Windows.Controls;

namespace Cafe.Pages.Waiter
{
    /// <summary>
    /// Логика взаимодействия для WaiterPage.xaml
    /// </summary>
    public partial class WaiterPage : Page
    {
        public WaiterPage()
        {
            InitializeComponent();
            FrameDg.Navigate(new OrderDg());
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            addOrder.ShowDialog();
        }
    }
}
