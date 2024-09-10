using Cafe.Models;
using Cafe.Pages.Admin;
using Cafe.Pages.Cook;
using Cafe.Pages.Waiter;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cafe
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();

        }

        bool LoginEmployee(string login, string pass)
        {
            using (CafeEntities db = new CafeEntities())
            {
                Employee emp = db.Employee.FirstOrDefault(x => x.Login == login && x.Password == pass);
                if (emp != null && emp.Status != "Fired")
                {
                    switch(emp.Role.Trim())
                    {
                        case "Admin": CurrentUser.currentUser = emp; this.NavigationService?.Navigate(new AdminPage()); break;
                        case "Cook": CurrentUser.currentUser = emp; this.NavigationService?.Navigate(new CookPage()); break;
                        case "Waiter": CurrentUser.currentUser = emp; this.NavigationService?.Navigate(new WaiterPage()); break;
                        default: return false;
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(LoginEmployee(login: TbLogin.Text, pass: PbPass.Password) ? "Успех!" : "Ошибка!");
        }
    }
}
