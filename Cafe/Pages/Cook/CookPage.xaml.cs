using Cafe.DataGrids.Cook;
using System.Windows;
using System.Windows.Controls;

namespace Cafe.Pages.Cook
{
    /// <summary>
    /// Логика взаимодействия для CookPage.xaml
    /// </summary>
    public partial class CookPage : Page
    {
        public CookPage()
        {
            InitializeComponent();
        }

        private void ShowAllOrder_Click(object sender, RoutedEventArgs e)
        {
            frameDG.Navigate(new NotTakenOrder());
        }

        private void ShowOrder_Click(object sender, RoutedEventArgs e)
        {
            frameDG.Navigate(new TakenOrder());
        }
    }
}
