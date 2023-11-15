using System.Windows;
using System.Windows.Controls;
using WallCh.Desktop.Services;

namespace WallCh.Desktop.Helpers;

public static class WindowHelper
{
    private static bool _isMax = false;
    private static Point _oldLocation;
    private static Point _defaultLocation;
    private static Size _oldSize;
    private static Size _defaultSize;

    public static Window Init(this Window window)
    {
        _oldLocation = new Point(window.Top, window.Left);
        _defaultLocation = new Point(window.Top, window.Left);

        _oldSize = new Size(window.Width, window.Height);
        _defaultSize = new Size(window.Width, window.Height);

        return window;
    }

    public static Window SetMaximize(this Window window, Button button)
    {
        if (!_isMax)
        {
            _oldLocation = new Point(window.Top, window.Left);
            _oldSize = new Size(window.Width, window.Height);

            Maximize(window);

            _isMax = true;
            button.Content = "🗗";
        }
        else
        {
            if (_oldSize.Width >= SystemParameters.WorkArea.Width 
                || _oldSize.Height >= SystemParameters.WorkArea.Height)
            {
                window.Top = _defaultLocation.Y;
                window.Left = _defaultLocation.X;
                window.Width = _defaultSize.Width;
                window.Height = _defaultSize.Height;
            }
            else
            {
                window.Top = _oldLocation.Y;
                window.Left = _oldLocation.X;
                window.Width = _oldSize.Width;
                window.Height = _oldSize.Height;
            }

            _isMax = false;
            button.Content = "▢";
        }

        return window;
    }

    private static Window Maximize(this Window window)
    {
        double x = SystemParameters.WorkArea.Width;
        double y = SystemParameters.WorkArea.Height;
        window.WindowState = WindowState.Normal;
        window.Top = 0;
        window.Left = 0;
        window.Width = x;
        window.Height = y;

        return window;
    }

    public static Window Minimize(this Window window)
    {
        window.WindowState = WindowState.Minimized;

        return window;
    }

    public static void Exit(this Window _)
    {
        Application.Current.Shutdown();
    }
}
