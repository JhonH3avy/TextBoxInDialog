using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDialog.Shared
{
    // extends IDisposable so some okCancelVIewModel can unhook from global event handlers
    public interface IOKCancelViewModel : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="window"></param>
        /// <returns>true to indicate the window should be closed</returns>
        bool OK(object window);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>true to indicate the window should be closed</returns>
        bool Cancel();

        bool OkCanExecute(object obj);
        bool CancelCanExecute(object obj);
        IInvalidateCommand OkCommand { get; set; }
        IInvalidateCommand CancelCommand { get; set; }
        string OkText { get; }
        string CancelText { get; }
        object View { get; set; }
        string Title { get; }
    }
}
