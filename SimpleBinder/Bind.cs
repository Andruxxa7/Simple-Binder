namespace SimpleBinder
{
    /// <summary>
    /// Класс с данными бинда
    /// </summary>
    public class Bind
    {
        private string bindKeys; //временное, потом если чё переделать
        private string bindText; // текст, к-й будет будеть "набираться"
        private bool isEnabled; //вкл или выкл бинд на данный момент
        private bool isMulti; //мульти бинд или единичный
        private int indexOfSelectedModifier;
        private string selectedModifier;

        public int IndexOfSelectedModifier
        {
            get => indexOfSelectedModifier;
            set => indexOfSelectedModifier = value;
        }

        public string SelectedModifier
        {
            get => selectedModifier;
            set => selectedModifier = value;
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set => isEnabled = value;
        }

        public bool IsMulti
        {
            get => isMulti;
            set => isMulti = value;
        }

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

        /// <summary>
        /// Конструктор класса Bind по умолчанию(без параметров)
        /// </summary>
        public Bind()
        {
        }

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
            isEnabled = enabled;
            isMulti = multi;
            BindKeys = keys;
            BindText = text;
            indexOfSelectedModifier = indexOfModifier;
            selectedModifier = modifier;
        }
    }
}