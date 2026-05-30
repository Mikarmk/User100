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
            
            
            using (var context = new User100Entities())
            {
                Tovar t = new Tovar();
                t.Articul = TB_Articul.Text;
                t.TovarName = TB_TovarName.Text;
                t.Cena = Convert.ToInt32(TB_Cena.Text);

                context.Tovar.Add(t);
                MessageBox.Show(t.Id.ToString());
                context.SaveChanges();

            }

            MessageBox.Show("Товар добавлен");
            this.Close();
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
