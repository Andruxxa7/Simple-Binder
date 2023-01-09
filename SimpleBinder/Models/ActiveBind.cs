using System.Threading.Tasks;
using WindowsInput.Native;
using static System.Threading.Thread;
using ModifierKeys = NonInvasiveKeyboardHookLibrary.ModifierKeys;

namespace SimpleBinder;

public class ActiveBind
{
    private string Text { get; set; }
    private int key { get; set; }
    private string Modifier { get; set; }
    private bool isAdded;

    public ActiveBind(Bind bind)
    {
        isAdded = false;
        Text = bind.BindText;
        key = bind.KeyValue;
        Modifier = bind.SelectedModifier;
    }


    private static Task SimulateTyping(string text)
    {
        Sleep(10); //да-да, я говноед
        SimpleBinder.inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BACK);
        SimpleBinder.inputSimulator.Keyboard.TextEntry(text);
        return Task.CompletedTask;
    }

    public void RegisterBind()
    {
        if (isAdded) return;
        if (Modifier == "None")
        {
            SimpleBinder.keyboardHookManager.RegisterHotkey(
                key,
                async () => await SimulateTyping(Text));
        }
        else
        {
            SimpleBinder.keyboardHookManager.RegisterHotkey(
                Modifier switch
                {
                    "Control" => ModifierKeys.Control,
                    "Alt" => ModifierKeys.Alt,
                    "Win" => ModifierKeys.WindowsKey,
                    "Shift" => ModifierKeys.Shift,
                },
                key,
                async () => await SimulateTyping(Text));
        }

        isAdded = true;
    }
}