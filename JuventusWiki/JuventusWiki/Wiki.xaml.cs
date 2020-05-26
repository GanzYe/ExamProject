using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для Wiki.xaml
    /// </summary>
    public partial class Wiki : Window
    {
        WikiContext WikiContext ;
        string Login { get; set; }
        string Password { get; set; }
        public Wiki(string login,string password)
        {
            InitializeComponent();
            Login = login;
            Password = password;
            WikiContext =  new WikiContext();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WikiContext.Accounts.Load();
            players.ItemsSource = WikiContext.Accounts.Local;
        }

        private void RichTextBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
