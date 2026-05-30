using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
using System.Windows.Shapes;
using User100.Model;

namespace User100.View
{

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
                
        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var password = PasswordBox.Password;

            using (var context = new User100Entities())
            {
                var user = context.Polzovatel.FirstOrDefault(
                    u => u.Login == login && u.Password == password
                    );

                if (user == null)
                {
                    MessageBox.Show("Введите логин и пароль");
                    return;
                } else if (user.RolID == 1)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                } else if (user.RolID == 2)
                {
                    MenegerWindow menegerWindow = new MenegerWindow();
                    menegerWindow.Show();
                    this.Close();
                } else if (user.RolID == 3)
                {
                    UserWindow userWindow = new UserWindow(user);
                    userWindow.Show();
                    this.Close();
                } else
                {
                    MessageBox.Show("Проверьте правильность данных");
                    return;
                }
                 
            }
        }

        private void Btn_go_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWindow = new GuestWindow();
            guestWindow.Show();
            this.Close();
        }
    }
}
