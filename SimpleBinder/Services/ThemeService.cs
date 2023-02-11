using System.Drawing;
using static SimpleBinder.Properties.BinderThemes;

namespace SimpleBinder.Services;

public static class ThemeService
{
    public static void ChangeTheme(string themeName, SimpleBinder binder)
    {
        var theme = themeName switch
        {
            "black" => BlackTheme,
            "white" => WhiteTheme,
            "black high contrast" => BlackHighContrastTheme,
            _ => WhiteTheme
        };
        binder.ForeColor = theme.FontColor;
        binder.BackColor = theme.BackgroundColor;
        foreach (Control control in binder.Controls)
        {
            if (control is Button)
            {
                control.ForeColor = Color.DarkSlateGray;
                continue;
            }

            control.BackColor = theme.ElementBackColor;
            control.ForeColor = theme.FontColor;
        }

        #region Menu

        foreach (ToolStripMenuItem item in binder.binderNotifyContextMenu.Items)
        {
            item.BackColor = theme.ElementBackColor;
            item.ForeColor = theme.FontColor;
        }

        foreach (ToolStripMenuItem item in binder.menuStrip1.Items)
        {
            foreach (var Item in item.DropDownItems)
            {
                if (Item is not ToolStripMenuItem dropDownItem) continue;
                dropDownItem.BackColor = theme.ElementBackColor;
                dropDownItem.ForeColor = theme.FontColor;
            }
        }

        #endregion

        binder.statusLabel.BackColor = binder.binderIsEnabled ? Color.LawnGreen : Color.Red;
        binder.settings.CurrentTheme = theme.ThemeName;
        binder.Invalidate();
    }
}