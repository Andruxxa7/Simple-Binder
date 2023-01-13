using System.Drawing;
using System.Threading.Tasks;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private Task TurnOnBinder()
    {
        binderIsEnabled = true;
        statusButton.Text = statusButton_Turn_Off;
        statusLabel.BackColor = Color.LawnGreen;
        defaultButton.Enabled = false;
        if (saveButton.Enabled) saveButton_Click(null, null);
        for (var i = 0; i < bindKeysArray.Length; i++)
        {
            bindKeysArray[i].Enabled = false;
            bindTextArray[i].Enabled = false;
            enabledArray[i].Enabled = false;
            modifierArray[i].Enabled = false;
        }

        exportToolStripMenuItem.Enabled = false;
        toolStripMenuItem2.Enabled = false;
        Bind.bindNumber = 1;
        var error = false;
        foreach (var bind in bindsArray)
        {
            if (!bind.IsEnabled) continue;
            try
            {
                new ActiveBind(bind).RegisterBind();
            }
            catch (NonInvasiveKeyboardHookException) //если будут одинаковые бинды
            {
                enabledArray[bind.BindNumber - 1].Checked = false;
                MessageBox.Show(TurnOnBinder_Error_Message +
                                bind.BindNumber, Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
        }

        if (error) saveButton_Click(null, null);
        return Task.CompletedTask;
    }

    private Task TurnOffBinder()
    {
        binderIsEnabled = false;
        statusButton.Text = statusButton_Turn_On;
        statusLabel.BackColor = Color.Red;
        defaultButton.Enabled = true;
        for (var i = 0; i < bindKeysArray.Length; i++)
        {
            bindKeysArray[i].Enabled = true;
            bindTextArray[i].Enabled = true;
            enabledArray[i].Enabled = true;
            modifierArray[i].Enabled = true;
        }

        exportToolStripMenuItem.Enabled = true;
        toolStripMenuItem2.Enabled = true;
        return Task.CompletedTask;
    }

    private void RegisterBinderStartHotkey(int key, string keyName)
    {
        if (!settings.CurrentHotkeyState) return;
        if (key is not (>= 0x01 and <= 0xFE)) return; //0x01 - min virtual key code, 0xFE - max virtual key code
        keyboardHookManager.RegisterHotkey(
            key,
            () =>
            {
                keyboardHookManager.UnregisterAll();
                statusButton.Invoke(async () => await TurnOnBinder());
                RegisterBinderStopHotkey(key, keyName);
            });
        statusButton.Invoke(() => statusButton.Text += BinderKeyName != null ? $"({BinderKeyName})" : "");
    }

    private void RegisterBinderStopHotkey(int key, string keyName)
    {
        if (!settings.CurrentHotkeyState) return;
        if (key is not (>= 0x01 and <= 0xFE)) return;
        keyboardHookManager.RegisterHotkey(
            key,
            () =>
            {
                statusButton.Invoke(async () => await TurnOffBinder());
                keyboardHookManager.UnregisterAll();
                RegisterBinderStartHotkey(key, keyName);
            });
        statusButton.Invoke(() => statusButton.Text += BinderKeyName != null ? $"({BinderKeyName})" : "");
    }

    private Task changeBinderHotkey(int value, string name)
    {
        if (name.Length > 6) return Task.CompletedTask;
        if (value is not (>= 0x01 and <= 0xFE)) return Task.CompletedTask;
        settings.CurrentKeyName = name;
        settings.CurrentKeyValue = value;
        turnOffHotkeyToolStripMenuItem_Click(null, null);
        turnOnHotkeyToolStripMenuItem_Click(null, null);
        return Task.CompletedTask;
    }
}