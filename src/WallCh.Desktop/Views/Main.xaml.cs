using System;
using System.Buffers;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WallCh.Desktop.Components.Header;
using WallCh.Desktop.Components.Notifications;
using WallCh.Desktop.Helpers;
using WallCh.Domain.Common;
using WallCh.Middleware.Managers.Interfaces;

namespace WallCh.Desktop;

public partial class Main : Window
{
    private readonly DropdownMenuControl _dropdownMenu;
    private readonly IUserManager _userManager;
    private readonly Notification _notification;
    private bool _isDropDownMenuOpened = false;

    public Main(DropdownMenuControl dropdownMenu, IUserManager userManager, Notification notification)
    {
        InitializeComponent();

        _dropdownMenu = dropdownMenu;
        _userManager = userManager;
        _notification = notification;

        this.Init();
    }

    private void OnLogoText_Click(object sender, MouseButtonEventArgs e)
    {
        _notification.Message = "Test show title";
        _notification.NotificationType = "#0AB39C";
        _notification.ImageType = "error.png";
        _notification.Show();
        //var test = await _userManager.Get();
    }

    private void OnExitButton_Click(object sender, RoutedEventArgs e)
    {
        this.Exit();
    }

    private void OnWindowState_Click(object sender, RoutedEventArgs e)
    {
        this.SetMaximize(WindowState_B);
    }

    private void OnMinimizeWindow_Click(object sender, RoutedEventArgs e)
    {
        this.Minimize();
    }

    private void OnDropdownMenu_Click(object sender, RoutedEventArgs e)
    {
        if (!_isDropDownMenuOpened)
        {
            var pos = Mouse.GetPosition(Main_W);

            _dropdownMenu.Owner = this;
            _dropdownMenu.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _dropdownMenu.Top = pos.Y;
            _dropdownMenu.Left = pos.X;
            _dropdownMenu.Show();
            _isDropDownMenuOpened = true;
        }
        else
        {
            _dropdownMenu.Hide();
            _isDropDownMenuOpened = false;
        }
    }

    private void OnHeaderBorder(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed) DragMove();
    }

    private void OnWindowMouseLeftDown(object sender, MouseButtonEventArgs e)
    {
        if (_isDropDownMenuOpened)
        {
            _dropdownMenu.Hide();
            _isDropDownMenuOpened = false;
        }
    }

    private void OnSearchBox_GotFocus(object sender, RoutedEventArgs e)
    {
        ((TextBox)sender).Text = string.Empty;
    }

    private void OnSearchBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(((TextBox)sender).Text))
            ((TextBox)sender).Text = "Введите запрос";
    }

    public void SetOperationStatusTextMethod(string text)
    {
        //FooterText_TB.Text = Constants.IsStop == true ? text : FooterText_TB.Text = $"{text} ({Math.Round(_percent)}%)";
        FooterText_TB.Text = text;
    }

    public void IsLoaderIndeterminate()
    {
        Loading_PB.Value = 45;
        Loading_PB.IsIndeterminate = true;
    }

    public void SetProgressMaximum(int maximum)
    {
        //_percent = 0.0;
        Loading_PB.Maximum = maximum;
        //_next = 100.0 / maximum;
    }

    public void SetProgress(int value)
    {
        //_percent += _next;
        Loading_PB.Value = value;
    }
}
