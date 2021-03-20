using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WorkoutForces.Model;

namespace WorkoutForces.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        private string _userText = "";
        private string _passwordText = "";
        public RelayCommand<object> PasswordChangeCommand { get; set; }
        public RelayCommand<object> LoginCommand { get; set; }
        public RelayCommand<object> RegisterCommand { get; set; }
        public string UseNameText
        {

            get
            {
                if (string.IsNullOrEmpty(_userText))
                    return "";

                return _userText;
            }

            set
            {
                _userText = value;
                OnPropertyChanged("UserText");
            }
        }
        public string PasswordText
        {
            get
            {
                if (string.IsNullOrEmpty(_passwordText))
                    return "";

                return _passwordText;
            }

            set
            {
                _passwordText = value;
                OnPropertyChanged("PasswordText");
            }
        }

        public LoginViewModel()
        {
            PasswordChangeCommand = new RelayCommand<object>(canExecutePasswordChange, PasswordChangeExecute);
            LoginCommand = new RelayCommand<object>(canExecuteLogin, LoginExecute);
            RegisterCommand = new RelayCommand<object>(canExecuteRegister, RegisterExecute);
        }

        public bool canExecuteLogin(object x)
        {
            return true;
        }
        public void LoginExecute(object p)
        {

            if (_userText == "" || _passwordText == "")
            {
                return;
            }

            LoginWindow loginWindow = p as LoginWindow;
            try
            {
                var theUser = DataProvider.Ins.DB.Users.Where(x => x.UserName == _userText & x.Password == _passwordText).Single();
                MainWindow mainWindow = new MainWindow();
                loginWindow.Close();
                mainWindow.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Wrong username or password!");

            }

        }

        public bool canExecutePasswordChange(object p)
        {
            return true;
        }

        public void PasswordChangeExecute(object p)
        {
            PasswordBox pwb = p as PasswordBox;
            PasswordText = pwb.Password.ToString();

        }

        public bool canExecuteRegister(object x)
        {
            return true;
        }
        public void RegisterExecute(object parameter)
        {
            try
            {
                var theUser = DataProvider.Ins.DB.Users.Where(x => x.UserName == _userText).Single();
                MessageBox.Show("Username đã tồn tại");
            }
            catch
            {
                User newuser = new User();
                newuser.UserName = _userText;
                newuser.Password = _passwordText;
                DataProvider.Ins.DB.Users.Add(newuser);
                DataProvider.Ins.DB.Users.SaveChanges();

            }

        }


    }

}
