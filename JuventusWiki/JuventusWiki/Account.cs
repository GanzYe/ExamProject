using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JuventusWiki
{
    public class Account : INotifyPropertyChanged
    {
        private int _id;
        private string _login;
        private string _password;
        private string _mail;
        private string _helpWord;
        private string _optionHelp;
        private List<Player> _favoritePlayers;

        [Key]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
                OnPropertyChanged("Mail");
            }
        }
        public string HelpWord
        {
            get
            {
                return _helpWord;
            }
            set
            {
                _helpWord = value;
                OnPropertyChanged("TripWord");
            }
        }
        public string OptionHelp
        {
            get
            {
                return _optionHelp;
            }
            set
            {
                _optionHelp = value;
                OnPropertyChanged("OptionHelp");
            }
        }
        public List<Player> FavoritePlayers
        {
            get
            {
                return _favoritePlayers;
            }
            set
            {
                _favoritePlayers = value;
                OnPropertyChanged("FavoritePlayers");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

