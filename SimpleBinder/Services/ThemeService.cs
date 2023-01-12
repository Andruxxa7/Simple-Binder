using System.Drawing;
using System.Linq;

namespace SimpleBinder;

public partial class SimpleBinder
{
    //todo переделать кнопки и темы(сделать парс с .json
    private void ChangeTheme(string themeName)
    {
        var theme = themeName switch
        {
            "black" => BlackTheme,
            "white" => WhiteTheme,
            "black high contrast" => BlackHighContrastTheme
        };
        ForeColor = theme.FontColor;
        BackColor = theme.BackgroundColor;
        foreach (Control control in Controls)
        {
            if (control is Button)
            {
                control.ForeColor = Color.DarkSlateGray;
                continue;
            }

            control.BackColor = theme.ElementBackColor;
            control.ForeColor = theme.FontColor;
        }

        statusLabel.BackColor = binderIsEnabled ? Color.LawnGreen : Color.Red;
        settings.CurrentTheme = theme.ThemeName;
        Invalidate();
    }
}