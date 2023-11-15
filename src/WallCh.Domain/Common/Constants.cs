using System.Drawing;

namespace WallCh.Domain.Common;

public partial class Constants
{
    public static bool IsStop = false;

    public const string TOKEN_DEFAULT_SCHEME = "Bearer";

    public static readonly Color SUCCESS_COLOR = Color.FromArgb(10, 179, 156);
    public static readonly Color WARNING_COLOR = Color.FromArgb(244, 206, 20);
    public static readonly Color ERROR_COLOR = Color.FromArgb(199, 0, 57);
}
