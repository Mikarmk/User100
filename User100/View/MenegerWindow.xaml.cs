using System.Linq;
using System.Windows;
using System.Windows.Controls;
using User100.Model;

namespace User100.View
{
    public partial class MenegerWindow : Window
    {
        private readonly Polzovatel _currentUser;

        public MenegerWindow()
        {
            InitializeComponent();
            LoadTovars();
        }

        public MenegerWindow(Polzovatel user)
        {
            InitializeComponent();
            _currentUser = user;
            TextBlockUser.Text = user == null ? "Менеджер" : user.Fio;
            LoadTovars();
        }

        private void LoadTovars()
        {
            using (var context = new User100Entities())
            {
                DG_Tovar.ItemsSource = context.Tovar.ToList();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var context = new User100Entities())
            {
                DG_Tovar.ItemsSource = context.Tovar
                    .Where(x => x.TovarName.Contains(SearchBox.Text) || x.Articul.Contains(SearchBox.Text))
                    .ToList();
            }
        }
    }
}
