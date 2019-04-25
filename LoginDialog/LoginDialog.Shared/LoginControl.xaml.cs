﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoginDialog.Shared
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginControl : IHasInitialFocus
    {
        public LoginControl()
        {
            this.InitializeComponent();
        }

        public void SetInitialFocus()
        {
            txtUserId.Focus(FocusState.Programmatic);
        }

        void txtPassword_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                var vm = DataContext as LoginViewModel;
                vm?.OK(this);
                e.Handled = true;
            }
        }

        void txtUserId_Changed(object sender, TextChangedEventArgs e)
        {
            //var vm = DataContext as LoginViewModel;
            //vm.UserId = txtUserId.Text;
        }
    }
}
