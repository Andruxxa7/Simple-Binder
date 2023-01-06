using System.Threading.Tasks;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private Task TurnOnBinder()
    {    
        keyboardHookManager.Start();
        var i = 0;
        foreach (var bind in bindsArray)
        {
            if(!bind.IsEnabled) continue;
            activeBindsArray.Add(new ActiveBind(bind));
            activeBindsArray[i].RegisterBind();
            i++;
        }
        return Task.CompletedTask;
    }

    private Task TurnOffBinder()
    {
        keyboardHookManager.UnregisterAll();
        activeBindsArray.Clear();
        keyboardHookManager.Stop();
        return Task.CompletedTask;
    }
}