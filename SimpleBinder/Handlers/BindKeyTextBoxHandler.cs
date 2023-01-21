using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private void bindKeysTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        var newKey = e.KeyCode switch
        {
            Keys.Escape => "Esc",
            Keys.Space => "Space",
            _ => KeyCodeToUnicode(e.KeyCode)
        };
        if (newKey == "") return;
        keyValueArray[int.Parse(currentBindTextBox.Name[currentBindTextBox.Name.Length - 1].ToString())] =
            e.KeyValue;
        UpdateTextBox(currentBindTextBox, newKey);
    }

    private void UpdateTextBox(TextBox textBox, string newKey)
        => textBox.Text = newKey.ToUpper();


    private void bindKeysTextBox_GotFocus(object obj, EventArgs args)
    {
        var textBox = (TextBox)obj;
        textBox.Text = string.Empty;
        currentBindTextBox = textBox;
        textBox.KeyDown += bindKeysTextBox_KeyDown;
    }

    private void bindKeysTextBox_LostFocus(object obj, EventArgs args)
    {
        var textBox = (TextBox)obj;
        textBox.KeyDown -= bindKeysTextBox_KeyDown;
        if (textBox.Text == "") //по названию textBox'а,если пусто, сетам 0 у бинда
            keyValueArray[int.Parse(Regex.Replace(textBox.Name, @"\D", ""))] = 0;
    }


    #region Translare from Keys to string

    private string KeyCodeToUnicode(Keys key)
    {
        //https://stackoverflow.com/questions/23170259/convert-keycode-to-char-string
        var keyboardState = new byte[255];
        var keyboardStateStatus = GetKeyboardState(keyboardState);

        if (!keyboardStateStatus) return "";

        var virtualKeyCode = (uint)key;
        var scanCode = MapVirtualKey(virtualKeyCode, 0);
        var inputLocaleIdentifier = GetKeyboardLayout(0);

        var result = new StringBuilder();
        ToUnicodeEx(virtualKeyCode, scanCode, keyboardState, result, 5, 0, inputLocaleIdentifier);
        return result.ToString();
    }

    [DllImport("user32.dll")]
    private static extern bool GetKeyboardState(byte[] lpKeyState);

    [DllImport("user32.dll")]
    private static extern uint MapVirtualKey(uint uCode, uint uMapType);

    [DllImport("user32.dll")]
    private static extern IntPtr GetKeyboardLayout(uint idThread);

    [DllImport("user32.dll")]
    private static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState,
        [Out] [MarshalAs(UnmanagedType.LPWStr)]
        StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);

    #endregion
}