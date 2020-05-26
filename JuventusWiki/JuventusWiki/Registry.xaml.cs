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
    /// Логика взаимодействия для Registry.xaml
    /// </summary>
    public partial class Registry : Window
    {
        public Registry()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            if (!ChekForReg() || !IsValid())
            {
                return;
            }
            using (var db = new WikiContext())
            {
                if (db.Accounts.Any(x => x.Login == login.Text))
                {
                    MessageBox.Show("Введите логин, такой логин уже занят");
                    return;
                }
                if (db.Accounts.Any(x => x.Mail == mail.Text))
                {
                    MessageBox.Show("Введите другую почту, такая почта уже занята");
                    return;
                }

                var account = new Account() { Password = password.Text, Mail = mail.Text, Login = login.Text, OptionHelp = helpOption.Text, HelpWord = helpWord.Text };
                db.Accounts.Add(account);
                db.SaveChanges();
                MessageBox.Show("Вы успешно прошли регистрацию");
                this.Close();
            }
        }
        private bool ChekForReg()
        {
            var isReguired = true;
            foreach (var item in RegCanvas.Children)
            {
                if (item is TextBox)
                {
                    var sel = (TextBox)item;
                    sel.BorderBrush = new SolidColorBrush(Colors.Gray);
                    if (string.IsNullOrEmpty(sel.Text))
                    {
                        sel.BorderBrush = new SolidColorBrush(Colors.Red);
                        isReguired = false;
                    }
                }
            }
            if (!isReguired)
            {
                MessageBox.Show($"Заполните все поля которые выделеные красным цветом");
            }
            return isReguired;
        }
        private bool IsValid()
        {
            var isValid = true;

            if (login.Text.Length <= 1)
            {
                login.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Заполните логин");
                isValid = false;
            }
            else
            {
                login.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
            if (mail.Text.Length<=7)
            {
                mail.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Неверная почта");
                isValid = false;
            }
            else
            {
                mail.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
            if (helpOption.SelectedItem==null)
            {
                helpOption.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Выберите секретный вопрос");
                isValid = false;
            }
            else
            {
                helpOption.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
            if (helpWord.Text.Length<=2)
            {
                helpWord.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Заполните секретное слово");
                isValid = false;
            }
            else
            {
                helpWord.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
            if (password.Text.Length<=6)
            {
                password.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Заполните пароль");
                isValid = false;
            }
            else if (!(password.Text.Contains('@')||password.Text.Contains('!')||password.Text.Contains('#')||password.Text.Contains('$')||password.Text.Contains('.')))
            {
                password.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Пароле должен присутствовать один из символов: @ ! # $ .");
                isValid = false;
            }
            else
            {
                password.BorderBrush = new SolidColorBrush(Colors.Gray);
               
            }
            return isValid;
        }
    }
}
