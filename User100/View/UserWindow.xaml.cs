using System.Linq;
using System.Windows;
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
            TextBlokUser.Text = CurrentUser == null ? "Анонимный пользователь" : CurrentUser.Fio;
            LoadTovars();
        }

        private void LoadTovars()
        {
            using (var context = new User100Entities())
            {
                ItemsTovar.ItemsSource = context.Tovar.ToList();
            }
        }
    }
}
