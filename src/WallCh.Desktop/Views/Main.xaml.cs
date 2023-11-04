using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WallCh.Desktop.Components.Header;
using WallCh.Desktop.Helpers;
using WallCh.Middleware.Managers.Interfaces;

namespace WallCh.Desktop;

public partial class Main : Window
{
    private readonly DropdownMenuControl _dropdownMenu;
    private readonly IUserManager _userManager;
    private bool _isDropDownMenuOpened = false;

    public Main(DropdownMenuControl dropdownMenu, IUserManager userManager)
    {
        InitializeComponent();

        _dropdownMenu = dropdownMenu;
        _userManager = userManager;

        this.Init();
    }

    private void OnLogoText_Click(object sender, MouseButtonEventArgs e)
    {
        var test = _userManager.Get();
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
}
