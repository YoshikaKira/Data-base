using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp4
{
    class RegViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _login, _pass, _name, _date;
        void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private User _user ;
        UsersModel useModel;
        public RegViewModel()
        {
            _user = new User();
            useModel = new UsersModel();
        }
        public ICommand ConfRegClick
        {
            get
            {
                return new ButtonCommand(
                    new Action(() =>
                    {
                        _user.Login = _login;
                        _user.Pass = _pass;
                        _user.Name = _name;
                        _user.Date = _date;
                        UsersModel model = new UsersModel();
                        model.InsertUser(_user);
                        
                    }));
            }//qdasd asdfasd
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                Notify("Login");
            }
        }
        public string Pass
        {
            get { return _pass; }
            set
            {
                _pass = value;
                Notify("Pass");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Notify("Name");
            }
        }
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                Notify("Date");
            }
        }
    }
}
