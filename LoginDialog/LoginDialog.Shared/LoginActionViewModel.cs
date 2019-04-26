using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace LoginDialog.Shared
{
    public class LoginActionViewModel : ViewModelBase
    {
        public LoginActionViewModel()
        {
            LoginAction = "Login";
        }

        void ChangeLogState()
        {
            if (LoginAction == "Login")
                LoginAction = "Logout";
            else
                LoginAction = "Login";
        }

        string loginAction;
        public string LoginAction
        {
            get => loginAction;
            set => SetAndRaiseChanged(ref loginAction, value);
        }

        public void Login(MainPage mainPage)
        {
            if (LoginAction == "Login")
            {
                var loginViewModel = new LoginViewModel(this);
                var window = new OkCancelDialog(new LoginControl(), loginViewModel);
                DialogService.Instance.Show(window);
                var res = window.Focus(FocusState.Programmatic);
            }
            ChangeLogState();
        }
    }
}
