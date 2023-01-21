using System.Drawing;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private static Theme BlackHighContrastTheme = new()
    {
        ThemeName = "black high contrast",
        BackgroundColor = Color.Black,
        ElementBackColor = Color.Black,
        FontColor = Color.DodgerBlue
    };


    private static Theme BlackTheme = new()
    {
        ThemeName = "black", //or 56
        BackgroundColor = Color.FromArgb(40, 40, 40),
        ElementBackColor = Color.FromArgb(40, 40, 40),
        FontColor = Color.FromArgb(165, 165, 165)
    };


    private static Theme WhiteTheme = new()
    {
        ThemeName = "white",
        BackgroundColor = Color.White,
        ElementBackColor = Color.White,
        FontColor = Color.Black
    };
}