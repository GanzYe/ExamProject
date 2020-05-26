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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuventusWiki
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void registry_Click(object sender, RoutedEventArgs e)
        {
            var win = new Registry();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Wiki_button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new WikiContext())
            {
                if (db.Accounts.Any(x => x.Login == login.Text && x.Password == password.Password))
                {
                    var win = new Wiki(login.Text, password.Password);
                    this.Close();
                    win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    win.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    return;

                }
            }
        }

        private void Forgot_Click(object sender, RoutedEventArgs e)
        {
            var win = new Forgot();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }
    }
}
