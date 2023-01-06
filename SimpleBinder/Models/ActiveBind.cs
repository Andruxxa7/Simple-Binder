using WindowsInput.Native;
using ModifierKeys = NonInvasiveKeyboardHookLibrary.ModifierKeys;

namespace SimpleBinder;

public partial class ActiveBind //Part of class is in ConvertStringToKeys.cs
{
    private string Text { get; set; }
    private string keys { get; set; }
    private string Modifier { get; set; }
    private bool isAdded;

    public ActiveBind(Bind bind)
    {
        isAdded = false;
        Text = bind.BindText;
        keys = bind.GenerateKeyString();
        Modifier = bind.SelectedModifier;
    }


    private void SimulateTyping(string text)
    {
        Thread.Sleep(1); //да-да, я говноед
        SimpleBinder.inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BACK);
        SimpleBinder.inputSimulator.Keyboard.TextEntry(text);
    }

    public void RegisterBind()
    {
        if (isAdded) return;
        var convertedKeys = ConvertFromStringToKeys();
        if (Modifier == "None")
        {
            SimpleBinder.keyboardHookManager.RegisterHotkey(
                KeyInterop.VirtualKeyFromKey((Key)convertedKeys[0]),
                () => SimulateTyping(Text));
        }
        else
        {
            SimpleBinder.keyboardHookManager.RegisterHotkey((ModifierKeys)(convertedKeys[0]),
                KeyInterop.VirtualKeyFromKey((Key)convertedKeys[1]),
                () => SimulateTyping(Text));
        }

        isAdded = true;
    }
}