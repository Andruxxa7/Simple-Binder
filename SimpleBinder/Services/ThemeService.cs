using System.Drawing;

namespace SimpleBinder;

public partial class SimpleBinder
{
    //todo переделать кнопки и темы(сделать парс с .json
    private void ChangeTheme(string themeName)
    {
        var theme = themeName == "white" ? WhiteTheme() : BlackTheme();
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

        statusLabel.BackColor = statusButton.Text != statusButton_Turn_On ? Color.LawnGreen : Color.Red;
        settings.CurrentTheme = theme.ThemeName;
        Invalidate();
    }
}