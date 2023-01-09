using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleBinder;

public partial class SimpleBinder
{
    /// <summary>
    ///     Парсит значения из .json в поля WinForm'ы
    /// </summary>
    /// <param name="path2Json">- путь до файла .json, из которого берутся значения</param>
    private async Task ParseFromJsonToWinForms(string path2Json)
    {
        if (!File.Exists(path2Json)) return;
        try
        {
            bindsArray = await Task.Run(() => JsonSerializer.Deserialize<Bind[]>(File.ReadAllText(path2Json)));
        }
        catch
        {
            MessageBox.Show(ParseFromJsonToWinForms_Error_Message, Caption_Error,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        keyValueArray = new int[bindsArray.Length];
        for (var i = 0; i < bindKeysArray.Length; i++)
        {
            keyValueArray[i] = bindsArray[i].KeyValue;
            bindKeysArray[i].Text = bindsArray[i].BindKeys ?? "";
            bindTextArray[i].Text = bindsArray[i].BindText ?? "";
            enabledArray[i].Checked = bindsArray[i].IsEnabled;
            modifierArray[i].SelectedIndex =
                bindsArray[i].IndexOfSelectedModifier != -1 ? bindsArray[i].IndexOfSelectedModifier : 0;
        }
    }


    /// <summary>
    ///     Парс значений из полей WinForm'ы в .json
    /// </summary>
    /// <param name="path2Json">- путь до файла .json, в котором сохраняются значения</param>
    private async Task ParseToJson(string path2Json)
    {
        Bind.bindNumber = 1;
        for (var i = 0; i < bindKeysArray.Length; i++)
        {
            bindsArray[i] = null;
            bindsArray[i] = new Bind(bindKeysArray[i].Text, bindTextArray[i].Text, enabledArray[i].Checked,
                modifierArray[i].SelectedIndex, (string)modifierArray[i].SelectedItem, keyValueArray[i]);
            enabledArray[i].Checked = bindsArray[i].IsEnabled;
        }

        await Task.Run(() => File.WriteAllText(path2Json, JsonSerializer.Serialize(bindsArray)));
    }
}