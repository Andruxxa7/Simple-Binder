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
            private set => bindKeys = (value == string.Empty) ? "" : value; //if(bindKeys==" ") - игнорирование //потом допилить
        }

        public string BindText
        {
            get => bindText;
            private set => bindText = (value == string.Empty) ? "" : value; //if(bindText==" ") - игнорирование //потом допилить
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
        public Bind(string keys, string text, bool enabled, bool multi)
        {
            IsEnabled = enabled;
            IsMulti = multi;
            BindKeys = keys;
            BindText = text;
        }
    }
}