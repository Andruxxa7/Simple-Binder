namespace SimpleBinder;

//In this file described minimize to tray
public partial class SimpleBinder
{
    private void SimpleBinder_Resize(object sender, EventArgs e)
    {
        if (!settings.CurrentIsMinimizeToTray || WindowState != FormWindowState.Minimized) return;
        binderNotifyIcon.Visible = true;
        ShowInTaskbar = false;
        Hide();
    }

    private void binderNotifyIcon_DoubleClick(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Normal;
        ShowInTaskbar = true;
        binderNotifyIcon.Visible = false;
        Show();
    }

    private void binderNotifyContextMenuExitItem_Click(object sender, EventArgs e) => Application.Exit();
}