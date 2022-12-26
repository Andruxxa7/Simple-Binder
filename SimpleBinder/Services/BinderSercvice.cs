namespace SimpleBinder
{
    public partial class SimpleBinder
    {
        private void TurnOnBinder()
        {
            var i = 0;
            foreach (var bind in bindsArray)
            {
             if(!bind.IsEnabled) continue;
             activeBindsArray.Add(new ActiveBind(bind));
             activeBindsArray[i].RegisterBind(i);
             i++;
            }
        }

        private void TurnOffBinder()
        {
            foreach (var bind in activeBindsArray)
                bind.UnregisterBind();
            activeBindsArray.Clear();
        }
    }
}