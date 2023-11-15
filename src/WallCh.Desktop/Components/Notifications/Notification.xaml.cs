using System.Drawing;
using System.Windows;
using WallCh.Domain.ViewModels;

namespace WallCh.Desktop.Components.Notifications;

/// <summary>
/// Логика взаимодействия для Notification.xaml
/// </summary>
public partial class Notification : Window
{
    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
        nameof(Message), typeof(string), typeof(Notification));

    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
        nameof(Description), typeof(string), typeof(Notification));

    public static readonly DependencyProperty NotificationTypeProperty = DependencyProperty.Register(
        nameof(NotificationType), typeof(string), typeof(Notification));

    public static readonly DependencyProperty ImageTypeProperty = DependencyProperty.Register(
        nameof(ImageType), typeof(string), typeof(Notification));

    public Notification()
    {
        InitializeComponent();

        DataContext = this;
    }

    public string Message
    {
        get { return (string)GetValue(MessageProperty); }
        set { SetValue(MessageProperty, value); }
    }

    public string Description 
    {
        get { return (string)GetValue(DescriptionProperty); }
        set { SetValue(DescriptionProperty, value); } 
    }

    public string NotificationType
    {
        get { return (string)GetValue(NotificationTypeProperty); }
        set { SetValue(NotificationTypeProperty, value); }
    }

    public string ImageType
    {
        get { return (string)GetValue(ImageTypeProperty); }
        set { SetValue(ImageTypeProperty, value); }
    }
}
