using System;
using System.Windows.Forms;
using WindowsInput.Native;
using System.Windows.Input;
using mrousavy;
using WindowsInput;

namespace SimpleBinder
{
    public partial class ActiveBind //Part of class is in ConvertStringToKeys.cs
    {
        public string Text { get; set; }
        public string keys { get; set; }
        public bool IsMulti { get; set; }
        private HotKey hotKey;
        private bool isAdded = false;

        public ActiveBind(bool isAdded, string text, string keys, bool isMulti)
        {
            this.isAdded = isAdded;
            Text = text;
            this.keys = keys;
            IsMulti = isMulti;
        }

        private void SimulateTyping() => SimpleBinder.inputSimulator.Keyboard.TextEntry(Text);

        public void RegisterBind()
        {
            if (isAdded) return;
            var keys = ConvertFromStringToKeys();
            //TODO сделать регистрацию бинда(пример ниже)
            /*{
                var key = new HotKey(
                    (ModifierKeys.Control | ModifierKeys.Alt), 
                    Key.S, 
                    this, 
                    (hotkey) => {
                        MessageBox.Show("Ctrl + Alt + S was pressed!");
                    }
                );    
            }*/
            isAdded = true;
        }

        public void UnregisterBind()
        {
            if (!isAdded) return;
            isAdded = false;
            hotKey.Dispose();
        }
    }
}