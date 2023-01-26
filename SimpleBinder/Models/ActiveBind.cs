using System.Threading.Tasks;
using WindowsInput.Native;
using static System.Threading.Thread;

namespace SimpleBinder.Models;

public class ActiveBind
{
    public ActiveBind(Bind bind)
    {
        Text = bind.BindText;
        _key = bind.KeyValue;
        Modifier = bind.SelectedModifier;
    }

    private string Text { get; }
    private int _key { get; }
    private string Modifier { get; }


    private static Task SimulateTyping(string text)
    {
        Sleep(10);
        SimpleBinder.inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BACK);
        SimpleBinder.inputSimulator.Keyboard.TextEntry(text);
        return Task.CompletedTask;
    }

    public void RegisterBind()
    {
        async void Type() => await SimulateTyping(Text);
        if (Modifier == "None")
        {
            SimpleBinder.keyboardHookManager.RegisterHotkey(_key, Type);
        }
        else
            SimpleBinder.keyboardHookManager.RegisterHotkey(
                Modifier switch
                {
                    "Control" => ModifierKeys.Control,
                    "Alt" => ModifierKeys.Alt,
                    "Win" => ModifierKeys.WindowsKey,
                    "Shift" => ModifierKeys.Shift
                }, _key, Type);
    }
}