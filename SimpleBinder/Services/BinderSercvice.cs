using System.Threading.Tasks;
namespace SimpleBinder;

public partial class SimpleBinder
{
    private Task TurnOnBinder()
    {
        Bind.bindNumber = 1;
        keyboardHookManager.Start();
        foreach (var bind in bindsArray)
        {
            if (!bind.IsEnabled) continue;
            try
            {
                new ActiveBind(bind).RegisterBind();
            }
            catch
            {
                MessageBox.Show(Resources.TurnOnBinder_Error_Message +
                                bind.BindNumber, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        return Task.CompletedTask;
    }

    private Task TurnOffBinder()
    {
        keyboardHookManager.UnregisterAll();
        keyboardHookManager.Stop();
        return Task.CompletedTask;
    }
}