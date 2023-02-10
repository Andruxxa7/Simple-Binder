using System.Threading.Tasks;
using WindowsInput.Native;
using static System.Threading.Thread;

#pragma warning disable CS8509

namespace SimpleBinder.Models;

public class ActiveBind
{
    public ActiveBind(Bind bind)
    {
        _text = bind.BindText;
        _key = bind.KeyValue;
        _modifier = bind.SelectedModifier;
    }

    private string _text { get; }
    private int _key { get; }
    private string _modifier { get; }


    private static Task SimulateTyping(string text)
    {
        Sleep(10);
        SimpleBinder.inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BACK);
        SimpleBinder.inputSimulator.Keyboard.TextEntry(text);
        return Task.CompletedTask;
    }

    public void RegisterBind()
    {
        async void Type() => await SimulateTyping(_text);
        if (_modifier == "None")
        {
            SimpleBinder.keyboardHookManager.RegisterHotkey(_key, Type);
        }
        else
            SimpleBinder.keyboardHookManager.RegisterHotkey(
                _modifier switch
                {
                    "Control" => ModifierKeys.Control,
                    "Alt" => ModifierKeys.Alt,
                    "Win" => ModifierKeys.WindowsKey,
                    "Shift" => ModifierKeys.Shift
                }, _key, Type);
    }
}