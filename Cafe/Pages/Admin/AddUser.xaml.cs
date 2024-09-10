using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Cafe.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
            // Создаем список для хранения значений course_name
            try
            {
                // Получаем данные из базы данных
                using (CafeEntities db = new CafeEntities())
                {
                    List<string> dataTable = db.Role.Select(x => x.Name).ToList();
                    for (int i = 0; i < dataTable.Count; i++)
                    {
                        dataTable[i] = dataTable[i].Trim();
                    }
                    cbRole.ItemsSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения
                MessageBox.Show(ex.Message, "Error");
                // Можно выбросить исключение или сделать что-то другое в зависимости от требований
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseLeftButtonDown += delegate { DragMove(); };
        }

        private static bool RegistartionEmployee(string login, string pass, string repPass, string fio, string role)
        {

            if (pass == repPass)
            {
                using (CafeEntities db = new CafeEntities())
                {
                    if (db.Employee.FirstOrDefault(x => x.Login == login) == null)
                    {
                        Employee employee = new Employee()
                        {
                            Login = login,
                            Password = pass,
                            FIO = fio,
                            Role = role.Trim(),
                            Status = "Work"

                        };
                        db.Employee.Add(employee);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("User already exist");
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords don't match");
                return false;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                RegistartionEmployee(tbLogin.Text, pbPass.Password, pbRepPass.Password, tbFIO.Text,
                    cbRole.SelectedValue.ToString())
                    ? $"{cbRole.SelectedValue} {tbLogin.Text} successfully add"
                    : $"{cbRole.SelectedValue} {tbLogin.Text} unsuccessfully add");
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
