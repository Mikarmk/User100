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
using System.Windows.Shapes;
using User100.Model;

namespace User100.View
{
    public partial class UserWindow : Window
    {
        private Polzovatel CurrentUser;
        public UserWindow(Polzovatel user)
        {
            InitializeComponent();
            CurrentUser = user;

            TextBlokUser.Text = CurrentUser.Fio;

            loadTovars();



        }

        private void loadTovars()
        {
            using (var context = new User100Entities())
            {
                DG1.ItemsSource = context.Tovar.ToList();

            }
        }
    }
}
