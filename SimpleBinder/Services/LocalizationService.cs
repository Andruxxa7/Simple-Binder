using System.ComponentModel;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private void ChangerCurrentCulture(string lang)
    {
        settings.CurrentLanguage = lang;
        var newLangCultureInfo = new CultureInfo(lang);
        Thread.CurrentThread.CurrentCulture = newLangCultureInfo;
        Thread.CurrentThread.CurrentUICulture = newLangCultureInfo;
    }

    private void ChangeLanguage(string lang)
    {
        if (lang == settings.CurrentLanguage) return;
        ChangerCurrentCulture(lang);
        var newLangCultureInfo = new CultureInfo(lang);

        #region ApplyingResources

        var resources = new ComponentResourceManager(typeof(SimpleBinder));
        foreach (Control control in Controls) resources.ApplyResources(control, control.Name, newLangCultureInfo);
        if (binderIsEnabled)
            statusButton.Text =
                statusButton_Turn_Off; //фикс того, что при смене языка, если включен, отображался текст после смены языка как-будто выключен
        if (BinderKeyValue is >= 0x01 and <= 0xFE)
            statusButton.Text += BinderKeyName != null ? $"({BinderKeyName})" : "";
        foreach (ToolStripMenuItem item in menuStrip1.Items)
        {
            resources.ApplyResources(item, item.Name, newLangCultureInfo);
            foreach (var dropItem in item.DropDownItems)
                if (dropItem is ToolStripMenuItem Item)
                    resources.ApplyResources(Item, Item.Name, newLangCultureInfo);
        }

        SwitchMinimizeToTrayToolStripMenuItem.Text = (settings.CurrentIsMinimizeToTray)
            ? MinimizeToTrayOffToolStripMenuItem
            : MinimizeToTrayOnToolStripMenuItem;
        foreach (var item in binderNotifyContextMenu.MenuItems)
        {
            if (item is MenuItem menuItem)
                resources.ApplyResources(menuItem, menuItem.Name, newLangCultureInfo);
        }

        resources.ApplyResources(this, "$this", newLangCultureInfo);

        #endregion
    }
}