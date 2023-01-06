namespace SimpleBinder;

public partial class SimpleBinder
{
    private void bindKeysTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        UpdateTextBox(currentBindTextBox, e.KeyChar);
    }

    private void UpdateTextBox(TextBox textBox, char newKey)
    {
        textBox.Text = newKey.ToString().ToUpper();
    }


    private void bindKeysTextBox_GotFocus(object obj, EventArgs args)
    {
        var textBox = (TextBox)obj;
        textBox.Text = string.Empty;
        currentBindTextBox = textBox;
        textBox.KeyPress += bindKeysTextBox_KeyPress;
    }

    private void bindKeysTextBox_LostFocus(object obj, EventArgs args)
    {
        var textBox = (TextBox)obj;
        textBox.KeyPress -= bindKeysTextBox_KeyPress;
    }
}