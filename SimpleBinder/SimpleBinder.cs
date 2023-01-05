using System.Collections.Generic;
using System.Drawing;
using WindowsInput;
using static SimpleBinder.Properties.Resources;

namespace SimpleBinder
{
    public partial class SimpleBinder : Form
    {
        private const string PathToJson = "settings.json";
        public static InputSimulator inputSimulator = new InputSimulator();
        public static KeyboardHookManager keyboardHookManager = new KeyboardHookManager();
        private bool isValueChanged;
        private TextBox[] bindKeysArray;
        private TextBox[] bindTextArray;
        private CheckBox[] enabledArray;
        private ListBox[] modifierArray;
        private Bind[] bindsArray;
        private List<ActiveBind> activeBindsArray;
        private string currentLanguage;
        public SimpleBinder()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("");
            InitializeComponent();
            activeBindsArray = new List<ActiveBind>();

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
            ParseFromJsonToWinForms(PathToJson);
            SwitchSaveAndCancelButtons();
            bindsArray = new Bind[10];
            foreach (var textBox in bindKeysArray)
            {
                textBox.GotFocus += bindKeysTextBox_GotFocus;
                textBox.LostFocus += bindKeysTextBox_LostFocus;
            }
        }

        /// <summary>
        /// Тут описывается логика переключателя состояния биндера
        /// </summary>
        private async void statusButton_Click(object sender, EventArgs e)
        {
            if (statusButton.Text == statusButton_Turn_On)
            {
                statusButton.Text = statusButton_Turn_Off;
                statusLabel.BackColor = Color.LawnGreen;
                defaultButton.Enabled = false;
                saveButton_Click(null, null);
                for (var i = 0; i < bindKeysArray.Length; i++)
                {
                    bindKeysArray[i].Enabled = false;
                    bindTextArray[i].Enabled = false;
                    enabledArray[i].Enabled = false;
                    modifierArray[i].Enabled = false;
                }

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
        
                await TurnOffBinder();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ParseToJson(PathToJson);
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
                bindKeysArray[i].Text = "";
                bindTextArray[i].Text = "";
                enabledArray[i].Checked = false;
                modifierArray[i].SelectedIndex = 0;
            }
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // throw new System.NotImplementedException();
        }

        

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e) => ChangeLanguage("ru-ru");

        private void englishToolStripMenuItem_Click(object sender, EventArgs e) => ChangeLanguage("");


        private async void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await TurnOffBinder();
            if(!saveButton.Enabled)Application.Exit();
            var result = MessageBox.Show(exitToolStripMenuItem_Click_Text, SimpleBinder_exitToolStripMenuItem_Click_Warning, 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    saveButton_Click(null,null);
                    Application.Exit();
                    break;
                case DialogResult.No:
                    Application.Exit();
                    break;
                case DialogResult.Cancel:
                    break;
            }

            
        }
    }
}