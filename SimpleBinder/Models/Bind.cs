using System.Windows.Forms;

namespace SimpleBinder
{
    /// <summary>
    /// Класс с данными бинда
    /// </summary>
    public class Bind
    {
        public Bind()
        {
        }

        private string bindKeys; //временное, потом если чё переделать
        private string bindText; // текст, к-й будет будеть "набираться"

        public bool IsEnabled { get; set; }

        public bool IsMulti { get; set; }

        public string BindKeys
        {
            get => bindKeys;
            set => bindKeys = (value.Replace(" ", "") == string.Empty) ? "" : value;
        }

        public string BindText
        {
            get => bindText;
            set => bindText = (value.Replace(" ", "") == string.Empty) ? "" : value;
        }

        public int IndexOfSelectedModifier { get; set; }

        public string SelectedModifier { get; set; }

        /// <summary>
        /// Конструктор класса Bind с параметрами
        /// </summary>
        /// <param name="keys">сочетание клавиш или клавиша бинда</param>
        /// <param name="text">текст, к-й будет набран данным биндом</param>
        /// <param name="enabled">включен ли данный бинд</param>
        /// <param name="multi">является ли сочетанием клавиш или одиночная клавиша у бинда</param>
        /// <param name="indexOfModifier">Индекс модификатора</param>
        /// <param name="modifier">Модификатор бинда</param>
        public Bind(string keys, string text, bool enabled, bool multi, int indexOfModifier, string modifier)
        {
            var temp = (GenerateKeyString()??"") != string.Empty;
            IsEnabled = temp && enabled; //ес
            IsMulti = multi;
            BindKeys = keys;
            BindText = text;
            IndexOfSelectedModifier = indexOfModifier;
            SelectedModifier = (modifier == "Ctrl") ? "Control" : modifier;
        }

        public string GenerateKeyString()
        {
            var hotkey = string.Empty;
            if (IndexOfSelectedModifier == 0) //Без модификаторов
                hotkey =(BindKeys != string.Empty) ? BindKeys:string.Empty;
            else //C модификатором
            {
                hotkey = SelectedModifier;
                hotkey = (BindKeys != string.Empty) ? hotkey + " + " + BindKeys : hotkey;
            }

            return hotkey;
        }
    }
}