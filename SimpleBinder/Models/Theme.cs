using System.Drawing;

namespace SimpleBinder.Models;

public struct Theme
{
    public string ThemeName { get; set; }
    public Color BackgroundColor { get; set; }
    public Color FontColor { get; set; }
    public Color ElementBackColor { get; set; }
}