using WindowsInput;
using mrousavy;

namespace SimpleBinder
{
    public partial class ActiveBind //Part of class is in ConvertStringToKeys.cs
    {
        private string Text { get; set; }
        private string Keys { get; set; }
        private bool IsMulti { get; set; }
        private HotKey hotKey;
        private bool isAdded;

        public ActiveBind(string text, string keys, bool isMulti)
        {
            isAdded = false;
            Text = text;
            Keys = keys;
            IsMulti = isMulti;
        }

        public ActiveBind(Bind bind)
        {
            isAdded = false;
            Text = bind.BindText;
            Keys = bind.BindKeys;
            IsMulti = bind.IsMulti;
        }

        private Action<HotKey> SimulateTyping()
        {
            return (key) => SimpleBinder.inputSimulator.Keyboard.TextEntry(Text);
        }

        public void RegisterBind(int numberOfBind)//TODO тут какая-то хуйня в onKeyAction, отфиксить и всё збс будет
        {
            if (isAdded) return;
            var convertedKeys = ConvertFromStringToKeys();
            var currentForm = Application.OpenForms[0].Handle;
            switch (convertedKeys.Length)
            {
                case 1:
                {
                    hotKey = new HotKey(ModifierKeys.None, convertedKeys[0], currentForm, 
                        SimulateTyping());
                }
                    break;
                case 2:
                {
                    if (!IsMulti)
                    {
                        hotKey = new HotKey(ModifierKeys.None, (convertedKeys[0] | convertedKeys[1]), currentForm,
                            SimulateTyping());
                    }
                    else
                    {
                        hotKey = new HotKey(((ModifierKeys)convertedKeys[0]), convertedKeys[1], currentForm,
                            SimulateTyping());
                    }
                }
                    break;
                case 3:
                {
                    hotKey = new HotKey(((ModifierKeys)convertedKeys[0]), (convertedKeys[1] | convertedKeys[2]),
                        currentForm,
                        SimulateTyping());
                }
                    break;
                default:
                    MessageBox.Show("Something gone wrong, this bind wasn't registered");
                    break;
            }

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