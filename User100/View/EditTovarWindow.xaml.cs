using System;
using System.Linq;
using System.Windows;
using User100.Model;

namespace User100.View
{
    public partial class EditTovarWindow : Window
    {
        private readonly int _tovarId;

        public EditTovarWindow(int tovarId)
        {
            InitializeComponent();
            _tovarId = tovarId;
            LoadTovar();
        }

        private void LoadTovar()
        {
            using (var context = new User100Entities())
            {
                Tovar tovar = context.Tovar.FirstOrDefault(x => x.Id == _tovarId);
                if (tovar == null)
                {
                    MessageBox.Show("Товар не найден");
                    Close();
                    return;
                }

                TB_Articul.Text = tovar.Articul;
                TB_TovarName.Text = tovar.TovarName;
                TB_Cena.Text = tovar.Cena.ToString();
                TB_Skidka.Text = tovar.Skidka.ToString();
                TB_Kolichestvo.Text = tovar.Kolichestvo.ToString();
                TB_Opisanye.Text = tovar.Opisanye;
            }
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new User100Entities())
                {
                    Tovar tovar = context.Tovar.FirstOrDefault(x => x.Id == _tovarId);
                    if (tovar == null)
                    {
                        MessageBox.Show("Товар не найден");
                        return;
                    }

                    tovar.Articul = TB_Articul.Text;
                    tovar.TovarName = TB_TovarName.Text;
                    tovar.Cena = Convert.ToInt32(TB_Cena.Text);
                    tovar.Skidka = string.IsNullOrWhiteSpace(TB_Skidka.Text) ? 0 : Convert.ToInt32(TB_Skidka.Text);
                    tovar.Kolichestvo = string.IsNullOrWhiteSpace(TB_Kolichestvo.Text) ? 0 : Convert.ToInt32(TB_Kolichestvo.Text);
                    tovar.Opisanye = TB_Opisanye.Text;

                    context.SaveChanges();
                }

                MessageBox.Show("Товар изменён");
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
