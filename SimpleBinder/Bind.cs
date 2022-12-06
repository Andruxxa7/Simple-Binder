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

        public bool IsMulti => isMulti;

        public bool IsEnabled=> isEnabled;
        

        public string BindKeys
        {
            get => bindKeys;
            set //потом допилить
            {
                if (value == string.Empty) bindKeys = " "; //if(bindKeys==" ") - игнорирование 
                else bindKeys = value;
            }
        }

        public string BindText
        {
            get => bindText;
            set //потом допилить
            {
                bindText = (value == string.Empty) ? " " : value; //if(bindText==" ") - игнорирование 
            }
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
            isEnabled = enabled;
            isMulti = multi;
            BindKeys = keys;
            BindText = text;
        }

        /// <returns>Возвращает массив объектов полей класса(полученных через открытые свойства)</returns>
        public object[] ToArray()
        {
            return new object[] { IsEnabled, IsMulti, BindKeys, BindText };
        }
    }
}