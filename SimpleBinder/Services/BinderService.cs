using System.Drawing;
using System.Threading.Tasks;
using SimpleBinder.Models;
using static SimpleBinder.SimpleBinder;

namespace SimpleBinder;

public static class BinderService
{
    public static async Task TurnOnBinder(SimpleBinder binder)
    {
        {
            var activeBinds = false;
            foreach (var checkbox in enabledArray)
            {
                if (checkbox.Checked) activeBinds = true;
            }

            if (!activeBinds)
            {
                MessageBox.Show(NoBinds_Message, Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        keyboardHookManager.UnregisterAll();
        binder.statusButton.Text = statusButton_Turn_Off;
        binder.statusButton.Invoke(() => RegisterBinderStopHotkey(binder.BinderKeyValue, binder));
        CheckStatusButtonText(binder);
        binder.binderIsEnabled = true;
        binder.statusLabel.BackColor = Color.LawnGreen;
        binder.defaultButton.Enabled = false;
        if (binder.saveButton.Enabled) binder.saveButton.PerformClick();
        for (var i = 0; i < bindKeysArray.Length; i++)
        {
            bindKeysArray[i].Enabled = false;
            bindTextArray[i].Enabled = false;
            enabledArray[i].Enabled = false;
            modifierArray[i].Enabled = false;
        }

        binder.exportToolStripMenuItem.Enabled = false;
        binder.toolStripMenuItem2.Enabled = false;
        binder.openTestWindowToolStripMenuItem.Enabled = true;
        Bind.bindNumber = 1;
        var error = false;
        foreach (var bind in bindsArray)
        {
            if (!bind.IsEnabled) continue;
            try
            {
                new ActiveBind(bind).RegisterBind();
            }
            catch (HotkeyAlreadyRegisteredException e)
            {
                enabledArray[bind.BindNumber - 1].Checked = false;
                MessageBox.Show(TurnOnBinder_Error_Message +
                                bind.BindNumber, Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                await ExceptionLogger.LogExceptionToFile(e.Message, e.StackTrace, e.Source);
                error = true;
            }
        }

        if (error) binder.saveButton.PerformClick();
    }

    public static Task TurnOffBinder(SimpleBinder binder)
    {
        binder.binderIsEnabled = false;
        binder.statusButton.Text = statusButton_Turn_On;
        binder.statusLabel.BackColor = Color.Red;
        binder.defaultButton.Enabled = true;
        for (var i = 0; i < bindKeysArray.Length; i++)
        {
            bindKeysArray[i].Enabled = true;
            bindTextArray[i].Enabled = true;
            enabledArray[i].Enabled = true;
            modifierArray[i].Enabled = true;
        }

        binder.exportToolStripMenuItem.Enabled = true;
        binder.toolStripMenuItem2.Enabled = true;
        binder.openTestWindowToolStripMenuItem.Enabled = false;
        keyboardHookManager.UnregisterAll();
        binder.statusButton.Invoke(() => RegisterBinderStartHotkey(binder.BinderKeyValue, binder));
        CheckStatusButtonText(binder);
        return Task.CompletedTask;
    }

    public static void CheckStatusButtonText(SimpleBinder binder)
    {
        if (binder.settings.CurrentHotkeyState)
            binder.statusButton.Invoke(() =>
                binder.statusButton.Text += binder.BinderKeyName != null ? $"({binder.BinderKeyName})" : "");
    }

    public static void RegisterBinderStartHotkey(int key, SimpleBinder binder)
    {
        if (!binder.settings.CurrentHotkeyState) return;
        if (key is not (>= 0x01 and <= 0xFE)) return; //0x01 - min virtual key code, 0xFE - max virtual key code
        keyboardHookManager.RegisterHotkey(key,
            () => binder.statusButton.Invoke(async () => await TurnOnBinder(binder)));
    }

    private static void RegisterBinderStopHotkey(int key, SimpleBinder binder)
    {
        if (!binder.settings.CurrentHotkeyState) return;
        if (key is not (>= 0x01 and <= 0xFE)) return;
        keyboardHookManager.UnregisterAll();
        keyboardHookManager.RegisterHotkey(key,
            () => binder.statusButton.Invoke(async () => await TurnOffBinder(binder))
        );
    }

    public static Task ChangeBinderHotkey(int value, string name, SimpleBinder binder)
    {
        if (name.Length > 6) return Task.CompletedTask;
        if (value is not (>= 0x01 and <= 0xFE)) return Task.CompletedTask;
        binder.settings.CurrentKeyName = name;
        binder.settings.CurrentKeyValue = value;
        binder.turnOffHotkeyToolStripMenuItem_Click(null, null);
        binder.turnOnHotkeyToolStripMenuItem_Click(null, null);
        return Task.CompletedTask;
    }
}