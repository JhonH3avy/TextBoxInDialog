using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LoginDialog.Shared
{
    public class MainPageModelView : ViewModelBase
    {
        private string userId;
        public string UserId
        {
            get => userId;
            set => SetAndRaiseChanged(ref userId, value);
        }

        private string password;
        public string Password {
            get => password;
            set => SetAndRaiseChanged(ref password, value);
        }        
    }
}
