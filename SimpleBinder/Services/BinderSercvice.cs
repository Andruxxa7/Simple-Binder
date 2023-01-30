using System.Drawing;
using System.Threading.Tasks;
using SimpleBinder.Models;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private Task TurnOnBinder()
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
                return Task.CompletedTask;
            }
        }
        keyboardHookManager.UnregisterAll();
        statusButton.Text = statusButton_Turn_Off;
        statusButton.Invoke(() => RegisterBinderStopHotkey(BinderKeyValue));
        CheckStatusButtonText();
        binderIsEnabled = true;
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
        openTestWindowToolStripMenuItem.Enabled = true;
        Bind.bindNumber = 1;
        var error = false;
        foreach (var bind in bindsArray)
        {
            if (!bind.IsEnabled) continue;
            try
            {
                new ActiveBind(bind).RegisterBind();
            }
            catch (NonInvasiveKeyboardHookException)
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
        openTestWindowToolStripMenuItem.Enabled = false;
        keyboardHookManager.UnregisterAll();
        statusButton.Invoke(() => RegisterBinderStartHotkey(BinderKeyValue));
        CheckStatusButtonText();
        return Task.CompletedTask;
    }

    private void CheckStatusButtonText()
    {
        if (settings.CurrentHotkeyState)
            statusButton.Invoke(() => statusButton.Text += BinderKeyName != null ? $"({BinderKeyName})" : "");
    }

    private void RegisterBinderStartHotkey(int key)
    {
        if (!settings.CurrentHotkeyState) return;
        if (key is not (>= 0x01 and <= 0xFE)) return; //0x01 - min virtual key code, 0xFE - max virtual key code
        keyboardHookManager.RegisterHotkey(key, () => statusButton.Invoke(async () => await TurnOnBinder()));
    }

    private void RegisterBinderStopHotkey(int key)
    {
        if (!settings.CurrentHotkeyState) return;
        if (key is not (>= 0x01 and <= 0xFE)) return;
        keyboardHookManager.UnregisterAll();
        keyboardHookManager.RegisterHotkey(key, () => statusButton.Invoke(async () => await TurnOffBinder())
        );
    }

    private Task ChangeBinderHotkey(int value, string name)
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