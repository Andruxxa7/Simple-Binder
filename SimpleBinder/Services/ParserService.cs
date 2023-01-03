using System.IO;
using System.Text.Json;

namespace SimpleBinder
{
    public partial class SimpleBinder
    {
        /// <summary>
        /// Парсит значения из .json в поля WinForm'ы
        /// </summary>
        /// <param name="path2Json">- путь до файла .json, из которого берутся значения</param>
        private void ParseFromJsonToWinForms(string path2Json)
        {
            if (!File.Exists(path2Json)) return;
            bindsArray = JsonSerializer.Deserialize<Bind[]>(File.ReadAllText(path2Json));
            for (var i = 0; i < bindKeysArray.Length; i++)
            {
                if (bindsArray == null) break;
                bindKeysArray[i].Text = bindsArray[i].BindKeys ?? "";
                bindTextArray[i].Text = bindsArray[i].BindText ?? "";
                enabledArray[i].Checked = bindsArray[i].IsEnabled;
                modifierArray[i].SelectedIndex = bindsArray[i].IndexOfSelectedModifier;
            }
        }


        /// <summary>
        /// Парс значений из полей WinForm'ы в .json
        /// </summary>
        /// <param name="path2Json">- путь до файла .json, в котором сохраняются значения</param>   
        private void ParseToJson(string path2Json)
        {
            for (var i = 0; i < bindKeysArray.Length; i++)
            {
                bindsArray[i] = new Bind(bindKeysArray[i].Text, bindTextArray[i].Text, enabledArray[i].Checked,
                    modifierArray[i].SelectedIndex, (string)modifierArray[i].SelectedItem);
                enabledArray[i].Checked = bindsArray[i].IsEnabled;
            }

            File.WriteAllText(path2Json, JsonSerializer.Serialize(bindsArray));
        }
    }
}