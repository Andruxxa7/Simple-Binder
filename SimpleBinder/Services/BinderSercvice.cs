using System.Threading.Tasks;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private Task TurnOnBinder()
    {
        Bind.bindNumber = 1;
        keyboardHookManager.Start();
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
        keyboardHookManager.UnregisterAll();
        keyboardHookManager.Stop();
        return Task.CompletedTask;
    }
}