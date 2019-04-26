using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoginDialog.Shared
{
    public sealed partial class OkCancelDialog
    {
        ScrollViewer windowMessage;
        bool firstTime = true;

        public OkCancelDialog() : this(null, null) { }


        public OkCancelDialog(object content, IOKCancelViewModel viewModel)
        {
            InitializeComponent();
            CancelCommand = new RelayCommand(() => Close());
            GotFocus += OkCancelWindowGotFocus;


            DataContext = viewModel;
            WindowMessage = content;
        }

        public void Close()
        {
            DialogService.Instance.CloseDialog();
        }

        public object WindowMessage
        {
            get { return GetValue(WindowMessageProperty); }
            set { SetValue(WindowMessageProperty, value); }
        }

        public static readonly DependencyProperty WindowMessageProperty =
            DependencyProperty.Register(
                "WindowMessage", typeof(object), typeof(OkCancelDialog),
                new PropertyMetadata(null, WindowMessageChanged));

        static void WindowMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as OkCancelDialog;
            if (window == null) return;
            if (e.OldValue != null)
            {
                if (e.OldValue is UIElement) window.grdContainer.Children.Remove(e.OldValue as UIElement);
                if (window.windowMessage != null) window.grdContainer.Children.Remove(window.windowMessage);
            }

            if (e.NewValue is string)
            {
                window.windowMessage = new ScrollViewer
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    Content = new TextBlock
                    {
                        Text = e.NewValue.ToString(),
                        TextWrapping = TextWrapping.Wrap
                    }
                };
                window.windowMessage.SetValue(Grid.RowProperty, 1);
                window.grdContainer.Children.Add(window.windowMessage);
                return;
            }
            var uiElement = e.NewValue as UIElement;
            if (uiElement != null)
            {
                uiElement.SetValue(Grid.RowProperty, 1);
                window.grdContainer.Children.Add(uiElement);
                return;
            }
            throw new Exception("Window message must either be of type UIElemnet or string");
        }

        public Grid GrdContainer { get { return grdContainer; } }
        public Button OkButton { get { return null /*okButton*/; } }

        public string OkText
        {
            get { return (string)GetValue(OkTextProperty); }
            set { SetValue(OkTextProperty, value); }
        }

        public static readonly DependencyProperty OkTextProperty =
            DependencyProperty.Register(
                "OkText", typeof(string), typeof(OkCancelDialog),
                new PropertyMetadata("Ok"));


        public string CancelText
        {
            get { return (string)GetValue(CancelTextProperty); }
            set { SetValue(CancelTextProperty, value); }
        }

        public static readonly DependencyProperty CancelTextProperty =
            DependencyProperty.Register(
                "CancelText", typeof(string), typeof(OkCancelDialog),
                new PropertyMetadata("Cancel"));

        public IInvalidateCommand OkCommand
        {
            get { return (IInvalidateCommand)GetValue(OkCommandProperty); }
            set { SetValue(OkCommandProperty, value); }
        }

        public static readonly DependencyProperty OkCommandProperty =
            DependencyProperty.Register(
                "OkCommand", typeof(IInvalidateCommand), typeof(OkCancelDialog),
                null);

        public Visibility OkVisibility
        {
            get { return (Visibility)GetValue(OkVisibilityProperty); }
            set { SetValue(OkVisibilityProperty, value); }
        }

        public static readonly DependencyProperty OkVisibilityProperty =
            DependencyProperty.Register("OkVisibility", typeof(Visibility), typeof(OkCancelDialog), new PropertyMetadata(Visibility.Visible));


        public IInvalidateCommand CancelCommand
        {
            get { return (IInvalidateCommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        public Visibility CancelVisibility
        {
            get { return (Visibility)GetValue(CancelVisibilityProperty); }
            set { SetValue(CancelVisibilityProperty, value); }
        }

        public static readonly DependencyProperty CancelVisibilityProperty =
            DependencyProperty.Register("CancelVisibility", typeof(Visibility), typeof(OkCancelDialog), new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(IInvalidateCommand), typeof(OkCancelDialog), null);

        void OkCancelWindowGotFocus(object sender, RoutedEventArgs e)
        {
            if (firstTime)
            {
                try
                {
                    var hasInitialFocus = WindowMessage as IHasInitialFocus;
                    if (hasInitialFocus != null)
                    {
                        hasInitialFocus.SetInitialFocus();
                    }
                }
                catch
                {
                }
                finally
                {
                    firstTime = false;
                }
            }
        }
    }
}
