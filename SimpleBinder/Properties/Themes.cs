using System.Drawing;
using SimpleBinder.Models;

namespace SimpleBinder.Properties;

public static class BinderThemes
{
    public static Theme BlackHighContrastTheme = new()
    {
        ThemeName = "black high contrast",
        BackgroundColor = Color.Black,
        ElementBackColor = Color.Black,
        FontColor = Color.DodgerBlue
    };


    public static Theme BlackTheme = new()
    {
        ThemeName = "black", //or 56
        BackgroundColor = Color.FromArgb(40, 40, 40),
        ElementBackColor = Color.FromArgb(40, 40, 40),
        FontColor = Color.FromArgb(165, 165, 165)
    };


    public static Theme WhiteTheme = new()
    {
        ThemeName = "white",
        BackgroundColor = Color.White,
        ElementBackColor = Color.White,
        FontColor = Color.Black
    };
}