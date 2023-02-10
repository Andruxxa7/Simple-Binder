namespace SimpleBinder.Models;

public class Bind
{
    public Bind()
    {
        BindNumber = bindNumber++;
    }

    public Bind(string keys, string text, bool enabled, int indexOfModifier, string modifier, int keyValue)
    {
        BindNumber = bindNumber++;
        BindKeys = keys;
        BindText = text;
        IsEnabled = string.Concat(modifier, keys).Replace(" ", "") != string.Empty && text != string.Empty && enabled;
        IndexOfSelectedModifier = indexOfModifier;
        SelectedModifier = modifier == "Ctrl" ? "Control" : modifier;
        KeyValue = keyValue;
    }


    public static int bindNumber { get; set; } = 1;
    public int BindNumber { get; set; }
    public bool IsEnabled { get; set; }
    public string BindKeys { get; set; }

    public string BindText { get; set; }

    public int IndexOfSelectedModifier { get; set; }
    public string SelectedModifier { get; set; }
    public int KeyValue { get; set; }
}