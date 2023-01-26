namespace SimpleBinder;

public partial class SimpleBinder
{
    private async void Binder_FormClosing(object sender, FormClosingEventArgs e)
    {
        await TurnOffBinder();
        settings.Save();
        keyboardHookManager.Stop();
        if (!saveButton.Enabled) return;
        var result = MessageBox.Show(exitToolStripMenuItem_Click_Text,
            exitToolStripMenuItem_Click_Warning,
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
            saveButton_Click(null, null);
        else if (result == DialogResult.Cancel) e.Cancel = true;
    }
}