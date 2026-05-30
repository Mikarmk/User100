using System;
using System.Linq;
using System.Windows;
using User100.Model;

namespace User100.View
{
    public partial class AdminWindow : Window
    {

        

        public AdminWindow()
        {
            InitializeComponent();
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


        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Search_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
