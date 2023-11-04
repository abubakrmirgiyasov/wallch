using System.Windows;
using System.Windows.Controls;

namespace WallCh.Desktop.Components.Header;

/// <summary>
/// Логика взаимодействия для DropdownMenuControl.xaml
/// </summary>
public partial class DropdownMenuControl : Window
{
    public DropdownMenuControl()
    {
        InitializeComponent();
    }

    private void OnSelectionThemeChanged(object sender, SelectionChangedEventArgs e)
    {
        var s = e;
    }
}
