using System.Text.Json;
using System.Threading.Tasks;
using SimpleBinder.Models;
using static SimpleBinder.SimpleBinder;

namespace SimpleBinder.Services;

public static class Parser
{
    public static async Task ParseFromJsonToWinForms(string path2Json)
    {
        if (string.IsNullOrEmpty(path2Json))
        {
            throw new ArgumentNullException($"{path2Json} can't be null or empty.", nameof(path2Json));
        }

        if (!File.Exists(path2Json)) return;
        try
        {
            bindsArray = await Task.Run(() => JsonSerializer.Deserialize<Bind[]>(File.ReadAllText(path2Json)));
        }
        catch (JsonException e)
        {
            MessageBox.Show(ParseFromJsonToWinForms_Error_Message, Caption_Error, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            await ExceptionLogger.LogExceptionToFile(e.Message, e.StackTrace, e.Source);
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

    public static async Task ParseToJson(string path2Json)
    {
        if (string.IsNullOrEmpty(path2Json))
        {
            throw new ArgumentNullException($"{path2Json} can't be null or empty.", nameof(path2Json));
        }

        Bind.bindNumber = 1;
        for (var i = 0; i < bindKeysArray.Length; i++)
        {
            bindsArray[i] = null;
            bindsArray[i] = new(bindKeysArray[i].Text, bindTextArray[i].Text, enabledArray[i].Checked,
                modifierArray[i].SelectedIndex, (string)modifierArray[i].SelectedItem, keyValueArray[i]);
            enabledArray[i].Checked = bindsArray[i].IsEnabled;
        }

        await Task.Run(() => File.WriteAllText(path2Json, JsonSerializer.Serialize(bindsArray)));
    }
}