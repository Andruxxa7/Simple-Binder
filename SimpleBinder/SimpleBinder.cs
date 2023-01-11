using WindowsInput;

namespace SimpleBinder;

public partial class SimpleBinder : Form
{
    #region Data and arrays of components declaration

    private const string PathToJson = "settings.json";
    public static readonly InputSimulator inputSimulator = new();
    public static readonly KeyboardHookManager keyboardHookManager = new();
    private TextBox[] bindKeysArray;
    private Bind[] bindsArray;
    private TextBox[] bindTextArray;
    private CheckBox[] enabledArray;
    private bool isValueChanged;
    private int[] keyValueArray;
    private ListBox[] modifierArray;
    private Settings settings = new();
    private int BinderKeyValue;
    private string BinderKeyName;
    public SimpleBinder()
    {
        binderIsEnabled = false;
        ChangerCurrentCulture(settings.CurrentLanguage ??
                              (CultureInfo.InstalledUICulture.Name == "ru-RU" ? "ru-ru" : ""));
        InitializeComponent();


        enabledArray = new[]
        {
            enabled0, enabled1, enabled2, enabled3, enabled4,
            enabled5, enabled6, enabled7, enabled8, enabled9
        };

        bindKeysArray = new[]
        {
            bindKeys0, bindKeys1, bindKeys2, bindKeys3, bindKeys4,
            bindKeys5, bindKeys6, bindKeys7, bindKeys8, bindKeys9
        };

        bindTextArray = new[]
        {
            bindText0, bindText1, bindText2, bindText3, bindText4,
            bindText5, bindText6, bindText7, bindText8, bindText9
        };
        modifierArray = new[]
        {
            modifierListBox0, modifierListBox1, modifierListBox2, modifierListBox3, modifierListBox4,
            modifierListBox5, modifierListBox6, modifierListBox7, modifierListBox8, modifierListBox9
        };
    }

    #endregion

    private async void SimpleBinder_Load(object sender, EventArgs e)
    {
        await ParseFromJsonToWinForms(PathToJson);
        if (bindsArray == null)
        {
            foreach (var listBox in modifierArray) listBox.SelectedIndex = 0;

            bindsArray = new Bind[bindKeysArray.Length];
        }

        keyValueArray ??= new int[bindKeysArray.Length];
        SwitchSaveAndCancelButtons();
        foreach (var textBox in bindKeysArray)
        {
            textBox.GotFocus += bindKeysTextBox_GotFocus;
            textBox.LostFocus += bindKeysTextBox_LostFocus;
        }

        ChangeTheme(settings.CurrentTheme ?? "white");
        exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
        FormClosing += Binder_FormClosing;
        keyboardHookManager.Start();
        //todo сделать выбор бинда, что ниже захардкожен
        BinderKeyValue = 0x74;
        BinderKeyName = "F5";
        RegisterBinderStartHotkey(BinderKeyValue, BinderKeyName);
    }


   
    #region Button_Click event realisations

    private bool binderIsEnabled;

    private async void statusButton_Click(object sender, EventArgs e)
    {
        if (!binderIsEnabled)
        {
            keyboardHookManager.UnregisterAll();
            await TurnOnBinder();
            RegisterBinderStopHotkey(BinderKeyValue, BinderKeyName);
        }
        else
        {
            await TurnOffBinder();
            keyboardHookManager.UnregisterAll();
            RegisterBinderStartHotkey(BinderKeyValue, BinderKeyName);
        }
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        await ParseToJson(PathToJson);
        File.SetAttributes(PathToJson, FileAttributes.ReparsePoint);
        isValueChanged = false;
        SwitchSaveAndCancelButtons();
    }

    private async void cancelButton_Click(object sender, EventArgs e)
    {
        await ParseFromJsonToWinForms(PathToJson);
        isValueChanged = false;
        SwitchSaveAndCancelButtons();
    }

    private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        MessageBox.Show(
            helpToolStripMenuItem1_Click_Text,
            helpToolStripMenuItem1_Click_Capation);
    }

    private void defaultButton_Click(object sender, EventArgs e)
    {
        for (var i = 0; i < bindKeysArray.Length; i++)
        {
            bindKeysArray[i].Clear();
            bindTextArray[i].Clear();
            enabledArray[i].Checked = false;
            modifierArray[i].SelectedIndex = 0;
        }
    }

    #endregion


    #region ToolStripItems Realisation

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var resultClosing = MessageBox.Show(SimpleBinder_Binder_FormClosing_Text,
            exitToolStripMenuItem_Click_Warning,
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (resultClosing == DialogResult.Yes) Application.Exit();
    }


    private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show(Resources.aboutProgramToolStripMenuItem_Click +
                        @"https://github.com/Andruxxa7/Simple-Binder", @"Simple Binder");
    }

    private void russianToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ChangeLanguage("ru-ru");
    }

    private void englishToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ChangeLanguage("");
    }

    private async void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
        var importFileDialog = new OpenFileDialog();
        importFileDialog.Filter = importStripMenuItemClick_Json_config;
        importFileDialog.Title = importStripMenuItem_Text;
        importFileDialog.ShowDialog();
        if (importFileDialog.FileName != "" && importFileDialog.FilterIndex == 1)
            await ParseFromJsonToWinForms(importFileDialog.FileName);
    }

    private async void exportToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var exportFileDialog = new SaveFileDialog();
        exportFileDialog.Filter = importStripMenuItemClick_Json_config;
        exportFileDialog.Title = Resources.exportToolStripMenuItem_Click;
        exportFileDialog.ShowDialog();
        if (exportFileDialog.FileName != "" && exportFileDialog.FilterIndex == 1)
            await ParseToJson(exportFileDialog.FileName);
    }

    private void blackToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ChangeTheme("black");
        blackToolStripMenuItem.Enabled = false;
        whiteToolStripMenuItem.Enabled = true;
    }

    private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ChangeTheme("white");
        whiteToolStripMenuItem.Enabled = false;
        blackToolStripMenuItem.Enabled = true;
    }

    #endregion
}