using System;
using System.Windows;
using System.Windows.Input;
using WallCh.Desktop.Components.Header;
using WallCh.Desktop.Helpers;

namespace WallCh.Desktop;

public partial class Main : Window
{
    private readonly DropdownMenuControl _dropdownMenu;
    private bool _isDropDownMenuOpened = false;

    public Main(DropdownMenuControl dropdownMenu)
    {
        InitializeComponent();

        _dropdownMenu = dropdownMenu;

        this.Init();
    }

    private void OnLogoText_Click(object sender, MouseButtonEventArgs e)
    {

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
            Main_G.Children.Add(_dropdownMenu);
            _dropdownMenu.PointFromScreen(new Point(1500, 550));
            _isDropDownMenuOpened = true;
        }
        else
        {
            Main_G.Children.Remove(_dropdownMenu);
            _isDropDownMenuOpened = false;
        }
    }

    private void OnHeaderBorder(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed) DragMove();
    }
}
