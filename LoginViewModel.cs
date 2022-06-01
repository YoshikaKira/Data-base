using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp4
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        string _login, _pass;
        UsersModel _usersModel;
        public LoginViewModel()
        {
            _usersModel = new UsersModel();
        }
        public ICommand EnterClick
        {
            get
            {
                return new ButtonCommand(
                    new Action(() =>
                    {
                        User user = _usersModel.GetUser(Login, Pass);
                        if (user == null)
                            MessageBox.Show("Enter encorrect password");
                        else
                            MessageBox.Show($"Welcom {user.Name}");
                    }));
            }
        }
        public ICommand RegClick
        {
            get
            {
                return new ButtonCommand(
                    new Action(() =>
                    {
                        Window1 registration = new Window1();
                        registration.ShowDialog();

                    }));
            }
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
    }
}
