using System.ComponentModel;

namespace SimpleBinder.Services;

public static class LocalizationService
{
    public static void ChangerCurrentCulture(string lang, SimpleBinder binder)
    {
        binder.settings.CurrentLanguage = lang;
        var newLangCultureInfo = new CultureInfo(lang);
        Thread.CurrentThread.CurrentCulture = newLangCultureInfo;
        Thread.CurrentThread.CurrentUICulture = newLangCultureInfo;
    }

    public static void СheckOutTextOfMinimizeToTrayToolStripMenuItem(SimpleBinder binder) =>
        binder.SwitchMinimizeToTrayToolStripMenuItem.Text =
            binder.settings.CurrentIsMinimizeToTray
                ? MinimizeToTrayOffToolStripMenuItem
                : MinimizeToTrayOnToolStripMenuItem;

    public static void ChangeLanguage(string lang, SimpleBinder binder)
    {
        if (lang == binder.settings.CurrentLanguage) return;
        ChangerCurrentCulture(lang, binder);
        var newLangCultureInfo = new CultureInfo(lang);

        #region ApplyingResources

        var resources = new ComponentResourceManager(typeof(SimpleBinder));
        foreach (Control control in binder.Controls)
            resources.ApplyResources(control, control.Name, newLangCultureInfo);
        binder.statusButton.Text = binder.binderIsEnabled ? statusButton_Turn_Off : binder.statusButton.Text;
        binder.statusButton.Text += binder.BinderKeyValue is >= 0x01 and <= 0xFE && binder.BinderKeyName != null
            ? $"({binder.BinderKeyName})"
            : "";
        foreach (ToolStripMenuItem item in binder.menuStrip1.Items)
        {
            resources.ApplyResources(item, item.Name, newLangCultureInfo);
            foreach (var dropItem in item.DropDownItems)
                if (dropItem is ToolStripMenuItem Item)
                    resources.ApplyResources(Item, Item.Name, newLangCultureInfo);
        }

        СheckOutTextOfMinimizeToTrayToolStripMenuItem(binder);
        foreach (var item in binder.binderNotifyContextMenu.Items)
        {
            if (item is ToolStripMenuItem menuItem)
                resources.ApplyResources(menuItem, menuItem.Name, newLangCultureInfo);
        }

        resources.ApplyResources(binder, "$this", newLangCultureInfo);

        #endregion
    }
}