using Authorization_1.ADOApp;
using Authorization_1.ClassApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Authorization_1.PagesApp
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void EventRegistration(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtLogin.Text != "" && txtName.Text != "" && txtPassword.Password != "")
                {
                    if (DBConnection.Connection.Login.Where(x => x.Login1 == txtLogin.Text).FirstOrDefault() == null)
                    {
                        User newUser = new User()
                        {
                            Name = txtLogin.Text,
                            Role = int.Parse(txtRole.Text)
                        };

                        Login newLogin = new Login()
                        {
                            Login1 = txtLogin.Text,
                            Password = txtPassword.Password,
                            User = newUser
                        };

                        DBConnection.Connection.User.Add(newUser);
                        DBConnection.Connection.Login.Add(newLogin);
                        DBConnection.Connection.SaveChanges();
                        MessageBox.Show("Успешно!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
