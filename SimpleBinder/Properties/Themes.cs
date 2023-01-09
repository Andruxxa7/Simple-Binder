using System.Drawing;

namespace SimpleBinder;

public partial class SimpleBinder
{
    //todo переделать кнопки и темы(сделать парс с .json
    private static Theme BlackContrastTheme()
    {
        return new()
        {
            ThemeName = "black contrast",
            BackgroundColor = Color.Black,
            ElementBackColor = Color.Black,
            FontColor = Color.White
        };
    }

    private static Theme BlackTheme()
    {
        return new()
        {
            ThemeName = "black", //было оба 56
            BackgroundColor = Color.FromArgb(24, 24, 24),
            ElementBackColor = Color.FromArgb(40, 40, 40),
            FontColor = Color.FromArgb(165, 165, 165)
        };
    }

    private static Theme WhiteTheme()
    {
        return new()
        {
            ThemeName = "white",
            BackgroundColor = Color.White,
            ElementBackColor = Color.White,
            FontColor = Color.Black
        };
    }
}