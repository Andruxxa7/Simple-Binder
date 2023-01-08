using System.Drawing;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private static Theme BlackTheme() => new()
        {
            ThemeName = "black",
            BackgroundColor = Color.Black,
            ElementBackColor = Color.Black,
            FontColor = Color.White
        };

    private static Theme WhiteTheme()=> new()
        {
            ThemeName = "white",
            BackgroundColor = Color.White,
            ElementBackColor = Color.White,
            FontColor = Color.Black
        };
}