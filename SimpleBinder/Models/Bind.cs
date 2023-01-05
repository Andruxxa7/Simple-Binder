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

        public bool IsEnabled { get; set; }
        
        public string BindKeys { get; set; }

        public string BindText { get; set; }


        public int IndexOfSelectedModifier { get; set; }

        public string SelectedModifier { get; set; }

        /// <summary>
        /// Конструктор класса Bind с параметрами
        /// </summary>
        /// <param name="keys">сочетание клавиш или клавиша бинда</param>
        /// <param name="text">текст, к-й будет набран данным биндом</param>
        /// <param name="enabled">включен ли данный бинд</param>
        /// <param name="indexOfModifier">Индекс модификатора</param>
        /// <param name="modifier">Модификатор бинда</param>
        public Bind(string keys, string text, bool enabled, int indexOfModifier, string modifier)
        {
            BindKeys = keys;
            BindText = text;
            IsEnabled = GenerateKeyString() != string.Empty && text != string.Empty && enabled; //если кл
            IndexOfSelectedModifier = indexOfModifier;
            SelectedModifier = (modifier == "Ctrl") ? "Control" : modifier;
        }

        public string GenerateKeyString()
        {
            string hotkey;
            if (IndexOfSelectedModifier == 0) //Без модификаторов
                hotkey = (BindKeys != string.Empty) ? BindKeys : string.Empty;
            else //C модификатором
            {
                hotkey = SelectedModifier;
                hotkey = (BindKeys != string.Empty) ? $"{hotkey} + {BindKeys}" : hotkey;
            }

            return hotkey;
        }
    }
}