using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginDialog.Shared
{
    public class LoginViewModel : BusyOkCancelViewModelBase
    {
        readonly LoginActionViewModel loginActionViewModel;

        public LoginViewModel(LoginActionViewModel loginActionViewModel)
        {
            this.loginActionViewModel = loginActionViewModel;
            Title = "Login:";
        }

        public override bool OK(object window)
        {
            var loginTask = LoginContext.Login(UserId, Password);
            if (!loginTask.IsFaulted && loginTask.Result)
            {
                if (View is OkCancelDialog okCancelWindow)
                {
                    okCancelWindow.Close();
                }
                loginActionViewModel.LoggedIn();
            }            
            return false;
        }

        private string userId;
        public string UserId
        {
            get => userId;
            set
            {
                Console.WriteLine($"Actual userId value: {userId}");
                SetAndRaiseChanged(ref userId, value);
                Console.WriteLine($"Changing userId value to: {value}");
                Console.WriteLine($"New userId value: {userId}");
            }
        }


        private string password;
        public string Password
        {
            get => password;
            set
            {
                Console.WriteLine($"Actual password value: {password}");
                SetAndRaiseChanged(ref password, value);
                Console.WriteLine($"Changing password value to: {value}");
                Console.WriteLine($"New password value: {password}");
            }
        }
    }
}
