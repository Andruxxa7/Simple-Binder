using System.Collections.Generic;
using System.Drawing;
using SimpleBinder.Properties;
using WindowsInput;

namespace SimpleBinder
{
    public partial class SimpleBinder : Form
    {
        private const string PathToJson = "settings.json";
        public static InputSimulator inputSimulator =new InputSimulator();
        public static  KeyboardHookManager keyboardHookManager = new KeyboardHookManager();
        private bool isValueChanged;
        private TextBox[] bindKeysArray;
        private TextBox[] bindTextArray;
        private CheckBox[] enabledArray;
        private ListBox[] modifierArray;
        private Bind[] bindsArray;
        private List<ActiveBind> activeBindsArray;
        public SimpleBinder()
        {
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
            
            bindTextLabel.Text = Resources.bindText;
            bindKeysLabel.Text = Resources.bindKeys;
            modifierLabel.Text = Resources.modifier;
            defaultButton.Text = Resources.Default;
            cancelButton.Text = Resources.cancel;
            saveButton.Text = Resources.save;
            statusButton.Text = Resources.statusButton_Turn_On;
        }

        /// <summary>
        /// Тут описывается логика переключателя состояния биндера
        /// </summary>
        private async void statusButton_Click(object sender, EventArgs e)
        {
            if (statusButton.Text == Resources.statusButton_Turn_On)
            {
                statusButton.Text = Resources.statusButton_Turn_Off;
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
                statusButton.Text = Resources.statusButton_Turn_On;
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
        
    }
}