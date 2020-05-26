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

namespace JuventusWiki
{
    /// <summary>
    /// Логика взаимодействия для Forgot.xaml
    /// </summary>
    public partial class Forgot : Window
    {
        public Forgot()
        {
            InitializeComponent();
        }

        private void ForgotBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new WikiContext())
            {

                if (db.Accounts.Any(x => x.Mail == mail.Text && x.HelpWord == helpWord.Text && x.OptionHelp == helpOption.Text))
                {
                    var account = db.Accounts.Where(x => x.Mail == mail.Text && x.HelpWord == helpWord.Text && x.OptionHelp == helpOption.Text);
                    string password="";
                    foreach (var item in account)
                    {
                        password = item.Password;
                    }
                    MessageBox.Show($"Ваш пароль: {password}");
                    return;
                }
                MessageBox.Show($"Данные неверны!");

            }
        }
    }
}
