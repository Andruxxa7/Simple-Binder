namespace SimpleBinder
{
    public partial class SimpleBinder
    {
        private void TurnOnBinder()
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
        }

        private void TurnOffBinder()
        {
            keyboardHookManager.UnregisterAll();
            activeBindsArray.Clear();
            keyboardHookManager.Stop();
        }
    }
}