using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginDialog.Shared
{
    public class LoginContext
    {
        static LoginContext()
        {
            LoginStatus = "Logged In";
            Status = "Logged Out";
            LoggedInFlag = true;
        }

        public static string LoginStatus;
        public static bool LoggedInFlag;

        public static Task<bool> Login(string userId, string password) => new Task<bool>(() => true);

        public static Task Logout() => new Task(new Action(() => { }));
        
        public static string Status { get; set; }
        public static bool LoggedIn { get; set; }

        public static Task<bool> CheckStatus()
        {
            Status = "Checking status";
            var waitForStatus = new Task<bool>(() =>
            {
                Task.Delay(1000);
                Status = "Logged In";
                return true;
            });
            return waitForStatus;
        }
    }
}
