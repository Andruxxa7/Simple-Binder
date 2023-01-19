using System.Drawing;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private void ChangeTheme(string themeName)
    {
        var theme = themeName switch
        {
            "black" => BlackTheme,
            "white" => WhiteTheme,
            "black high contrast" => BlackHighContrastTheme,
            _ => WhiteTheme
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

        #region Menu

        foreach (ToolStripMenuItem item in binderNotifyContextMenu.Items)
        {
            item.BackColor = theme.ElementBackColor;
            item.ForeColor = theme.FontColor;
        }

        foreach (ToolStripMenuItem item in menuStrip1.Items)
        {
            foreach (var Item in item.DropDownItems)
            {
                if (Item is not ToolStripMenuItem dropDownItem) continue;
                dropDownItem.BackColor = theme.ElementBackColor;
                dropDownItem.ForeColor = theme.FontColor;
            }
        }

        #endregion

        statusLabel.BackColor = binderIsEnabled ? Color.LawnGreen : Color.Red;
        settings.CurrentTheme = theme.ThemeName;
        Invalidate();
    }
}