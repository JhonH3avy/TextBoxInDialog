using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace LoginDialog.Shared
{
    public class LoginActionViewModel : ViewModelBase
    {
        public LoginActionViewModel()
        {
            LoginAction = "Checking status";
            LoginContext.CheckStatus().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    SetLoggedOut();
                }
                else
                {
                    if (t.Result) SetLoggedIn();
                    else SetLoggedOut();
                }
            });
        }

        void SetLoggedOut()
        {
            LoginAction = "Login";
        }

        void SetLoggedIn()
        {
            LoginAction = "Logout";
        }

        string loginAction;
        public string LoginAction
        {
            get => loginAction;
            set => SetAndRaiseChanged(ref loginAction, value);
        }

        public void Login(MainPage mainPage)
        {
            if (!LoginContext.LoggedIn)
            {
                var loginViewModel = new LoginViewModel(this);
                var window = new OkCancelDialog(new LoginControl(), loginViewModel);
                //                mainPage.Panel.Children.Add(window);
                DialogService.Instance.Show(window);
                var res = window.Focus(FocusState.Programmatic);
                Console.WriteLine(res);
            }
            else
            {
                Logout();
            }
        }

        public void LoggedIn()
        {
            SetLoggedIn();
        }

        void Logout()
        {
            LoginContext.Logout();
            SetLoggedOut();
        }
    }
}
