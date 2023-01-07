using System.Drawing;
using WindowsInput;


namespace SimpleBinder;

public partial class SimpleBinder : Form
{
    private Settings settings = new();
    private const string PathToJson = "settings.json";
    public static readonly InputSimulator inputSimulator = new();
    public static readonly KeyboardHookManager keyboardHookManager = new();
    private bool isValueChanged;
    private TextBox[] bindKeysArray;
    private TextBox[] bindTextArray;
    private CheckBox[] enabledArray;
    private ListBox[] modifierArray;
    private Bind[] bindsArray;

    public SimpleBinder()
    {
        ChangerCurrentCulture(settings.CurrentLanguage ??
                              (CultureInfo.InstalledUICulture.Name == "ru-RU" ? "ru-ru" : ""));

        InitializeComponent();

        #region Data and components arrays declaration

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

        #endregion

        ParseFromJsonToWinForms(PathToJson);
        SwitchSaveAndCancelButtons();
        foreach (var textBox in bindKeysArray)
        {
            textBox.GotFocus += bindKeysTextBox_GotFocus;
            textBox.LostFocus += bindKeysTextBox_LostFocus;
        }

        ChangeTheme(settings.CurrentTheme ?? "white");
        exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
        FormClosing += Binder_FormClosing;
    }


    #region Button_Click event realisations

    /// <summary>
    /// Логика переключателя состояния биндера
    /// </summary>
    private async void statusButton_Click(object sender, EventArgs e)
    {
        if (statusButton.Text == statusButton_Turn_On)
        {
            statusButton.Text = statusButton_Turn_Off;
            statusLabel.BackColor = Color.LawnGreen;
            defaultButton.Enabled = false;
            if (saveButton.Enabled) saveButton_Click(null, null);
            for (var i = 0; i < bindKeysArray.Length; i++)
            {
                bindKeysArray[i].Enabled = false;
                bindTextArray[i].Enabled = false;
                enabledArray[i].Enabled = false;
                modifierArray[i].Enabled = false;
            }

            exportToolStripMenuItem.Enabled = false;
            toolStripMenuItem2.Enabled = false;
            await TurnOnBinder();
        }
        else
        {
            statusButton.Text = statusButton_Turn_On;
            statusLabel.BackColor = Color.Red;
            defaultButton.Enabled = true;
            for (var i = 0; i < bindKeysArray.Length; i++)
            {
                bindKeysArray[i].Enabled = true;
                bindTextArray[i].Enabled = true;
                enabledArray[i].Enabled = true;
                modifierArray[i].Enabled = true;
            }

            exportToolStripMenuItem.Enabled = true;
            toolStripMenuItem2.Enabled = true;
            await TurnOffBinder();
        }
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        ParseToJson(PathToJson);
        File.SetAttributes(PathToJson, FileAttributes.ReparsePoint);
        isValueChanged = false;
        SwitchSaveAndCancelButtons();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        ParseFromJsonToWinForms(PathToJson);
        isValueChanged = false;
        SwitchSaveAndCancelButtons();
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
                        "https://github.com/Andruxxa7/Simple-Binder","Simple Binder");
    }

    private void russianToolStripMenuItem_Click(object sender, EventArgs e) => ChangeLanguage("ru-ru");

    private void englishToolStripMenuItem_Click(object sender, EventArgs e) => ChangeLanguage("");

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
        var importFileDialog = new OpenFileDialog();
        importFileDialog.Filter = importStripMenuItemClick_Json_config;
        importFileDialog.Title = importStripMenuItem_Text;
        importFileDialog.ShowDialog();
        if (importFileDialog.FileName != "" && importFileDialog.FilterIndex == 1)
        {
            ParseFromJsonToWinForms(importFileDialog.FileName);
        }
    }

    private void exportToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var exportFileDialog = new SaveFileDialog();
        exportFileDialog.Filter = importStripMenuItemClick_Json_config;
        exportFileDialog.Title = Resources.exportToolStripMenuItem_Click;
        exportFileDialog.ShowDialog();
        if (exportFileDialog.FileName != "" && exportFileDialog.FilterIndex == 1)
        {
            ParseToJson(exportFileDialog.FileName);
        }
    }

    #endregion

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

    private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        MessageBox.Show(
            helpToolStripMenuItem1_Click_Text,
            helpToolStripMenuItem1_Click_Capation);
    }
}