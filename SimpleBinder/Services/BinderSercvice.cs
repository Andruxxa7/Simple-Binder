using System.Drawing;
using System.Threading.Tasks;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private Task TurnOnBinder()
    {
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
            async () => await TurnOnBinder());
        statusButton.Text += $"({keyName})";
    }

    private void RegisterBinderStopHotkey(int key, string keyName)
    {
        //допилить
        keyboardHookManager.RegisterHotkey(
            key,
            async () => await TurnOffBinder()
        );
        statusButton.Text += $"({keyName})";
    }
}