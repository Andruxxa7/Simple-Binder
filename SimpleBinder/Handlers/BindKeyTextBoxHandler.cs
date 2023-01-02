namespace SimpleBinder
{
    public partial class SimpleBinder
    {
        private void bindKeysTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char temp;
            if (e.KeyChar == (char)8)
            {
                Focus();
                temp = e.KeyChar;
            }

            temp = e.KeyChar;
            UpdateTextBox(currentBindTextBox, temp);
            
        }

        private void UpdateTextBox(TextBox textBox, char newKey)
        {
            if (newKey == (char)8) return;
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
}