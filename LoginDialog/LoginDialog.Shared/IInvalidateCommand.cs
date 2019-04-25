using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LoginDialog.Shared
{
    public interface IInvalidateCommand : ICommand
    {
        void InvalidateCanExecute();
    }
}
