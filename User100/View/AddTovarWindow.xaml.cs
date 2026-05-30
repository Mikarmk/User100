using System;
using System.Windows;
using User100.Model;

namespace User100.View
{
    public partial class AddTovarWindow : Window
    {
        public AddTovarWindow()
        {
            InitializeComponent();
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new User100Entities())
                {
                    context.Database.ExecuteSqlCommand(
                        "INSERT INTO Tovar (Articul, TovarName, Cena, Skidka, Kolichestvo, Opisanye) VALUES ({0}, {1}, {2}, {3}, {4}, {5})",
                        TB_Articul.Text,
                        TB_TovarName.Text,
                        Convert.ToInt32(TB_Cena.Text),
                        string.IsNullOrWhiteSpace(TB_Skidka.Text) ? 0 : Convert.ToInt32(TB_Skidka.Text),
                        string.IsNullOrWhiteSpace(TB_Kolichestvo.Text) ? 0 : Convert.ToInt32(TB_Kolichestvo.Text),
                        TB_Opisanye.Text
                    );
                }

                MessageBox.Show("Товар добавлен");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
