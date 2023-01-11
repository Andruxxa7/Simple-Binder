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
        //допилить
        keyboardHookManager.RegisterHotkey(
            key,
            () =>
            {
                keyboardHookManager.UnregisterAll();
                statusButton.Invoke(async () => await TurnOnBinder());
                RegisterBinderStopHotkey(0x74, "F5");
            });
        statusButton.Invoke(() => statusButton.Text += $"({keyName})");
    }

    private void RegisterBinderStopHotkey(int key, string keyName)
    {
        //допилить
        keyboardHookManager.RegisterHotkey(
            key,
            () =>
            {
                statusButton.Invoke(async () => await TurnOffBinder());
                keyboardHookManager.UnregisterAll();
                RegisterBinderStartHotkey(0x74, "F5");
            });
        statusButton.Invoke(() => statusButton.Text += $"({keyName})");
    }
}