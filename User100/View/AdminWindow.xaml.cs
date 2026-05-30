using System;
using System.Linq;
using System.Windows;
using User100.Model;

namespace User100.View
{
    public partial class AdminWindow : Window
    {
        private readonly Polzovatel _currentUser;

        public AdminWindow()
        {
            InitializeComponent();
            LoadTovars();
        }

        public AdminWindow(Polzovatel user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadTovars();
        }

        private void LoadTovars()
        {
            using (var context = new User100Entities())
            {
                DG_Tovar.ItemsSource = context.Tovar.ToList();
            }
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddTovarWindow window = new AddTovarWindow();
            window.ShowDialog();
            LoadTovars();
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            Tovar selectedTovar = DG_Tovar.SelectedItem as Tovar;
            if (selectedTovar == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            EditTovarWindow window = new EditTovarWindow(selectedTovar.Id);
            window.ShowDialog();
            LoadTovars();
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Tovar selectedTovar = DG_Tovar.SelectedItem as Tovar;
            if (selectedTovar == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            if (MessageBox.Show("Удалить товар?", "Подтверждение", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                return;
            }

            using (var context = new User100Entities())
            {
                Tovar tovarForDelete = context.Tovar.FirstOrDefault(x => x.Id == selectedTovar.Id);
                if (tovarForDelete != null)
                {
                    context.Tovar.Remove(tovarForDelete);
                    context.SaveChanges();
                }
            }

            LoadTovars();
        }

        private void Search_btn_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchBox.Text.Trim();

            using (var context = new User100Entities())
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    DG_Tovar.ItemsSource = context.Tovar.ToList();
                    return;
                }

                DG_Tovar.ItemsSource = context.Tovar
                    .Where(x => x.Articul.Contains(searchText) || x.TovarName.Contains(searchText))
                    .ToList();
            }
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser == null)
            {
                Close();
                return;
            }

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
    }
}
