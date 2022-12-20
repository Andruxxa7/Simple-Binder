using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace SimpleBinder
{
    public partial class SimpleBinder : Form
    {
        /// <summary>
        /// Путь до файла .json, в который сохраняются значения, которые потом парсятся из этого же файла.
        /// </summary>
        private string pathToJson = "settings.json";

        private bool isValueChanged;
        private TextBox[] bindKeysArray;
        private TextBox[] bindTextArray;
        private CheckBox[] multiArray;
        private CheckBox[] enabledArray;
        private ListBox[] modifierArray;
        private Bind[] bindsArray;

        /// <summary>
        /// Парсит значения из .json в поля WinForm'ы
        /// </summary>
        /// <param name="path2Json">- путь до файла .json, из которого берутся значения</param>
        private void ParseFromJsonToWinForms(string path2Json)
        {
            if (!File.Exists(path2Json)) return;
            var tempArray = JsonSerializer.Deserialize<Bind[]>(File.ReadAllText(path2Json));
            Array.Resize(ref tempArray, 10);
            bindsArray = tempArray;
            for (var i = 0; i < bindKeysArray.Length; i++)
            {
                if (bindsArray == null) break;
                bindKeysArray[i].Text = bindsArray[i].BindKeys ?? "";
                bindTextArray[i].Text = bindsArray[i].BindText ?? "";
                multiArray[i].Checked = bindsArray[i].IsMulti;
                enabledArray[i].Checked = bindsArray[i].IsEnabled;
                modifierArray[i].SelectedIndex = bindsArray[i].IndexOfSelectedModifier;
            }
        }
        
        /// <summary>
        /// Добавляет ивент ValueChangedEvent на TextBox'ы и  CheckBox'ы
        /// </summary>
        private void AddValueChangedEvent()
        {
            foreach (Control control in Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.CheckedChanged += ValueIsChanged;
                }
                else if (control is TextBox textBox)
                {
                    textBox.TextChanged += ValueIsChanged;
                }
                else if(control is ListBox listBox)
                {
                    listBox.SelectedIndexChanged += ValueIsChanged;
                }
            }
        }

        /// <summary>
        /// Удаляет ивент ValueChangedEvent c TextBox'ы и CheckBox'ы
        /// </summary>
        private void DeleteValueChangedEvent()
        {
            foreach (Control control in Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.CheckedChanged -= ValueIsChanged;
                }
                else if (control is TextBox)
                {
                    control.TextChanged -= ValueIsChanged;
                }
                else if(control is ListBox listBox)
                {
                    listBox.SelectedIndexChanged -= ValueIsChanged;
                }
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
                var bind = new Bind(bindKeysArray[i].Text, bindTextArray[i].Text, enabledArray[i].Checked,
                    multiArray[i].Checked,modifierArray[i].SelectedIndex,(string)modifierArray[i].SelectedItem);
                bindsArray[i] = bind;
            }

            File.WriteAllText(path2Json, JsonSerializer.Serialize(bindsArray));
        }

        private void SwitchSaveAndCancelButtons()
        {
            if (!isValueChanged)
            {
                saveButton.Enabled = false;
                cancelButton.Enabled = false;

                AddValueChangedEvent();
            }
            else
            {
                saveButton.Enabled = true;
                cancelButton.Enabled = true;
            }
        }

        private void ValueIsChanged(object sender, EventArgs e)
        {
            isValueChanged = true;
            SwitchSaveAndCancelButtons();
            DeleteValueChangedEvent();
        }

        private void bindKeysTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char temp;
            if (e.KeyChar == (char)8)
            {
                Focus();
                temp = e.KeyChar;
            }

            temp = e.KeyChar;
            UpdateTextBox(currentBindTextBox, temp);
        }

        private TextBox currentBindTextBox;

        private void UpdateTextBox(TextBox textBox, char newKey)
        {
            if (newKey == ((char)8)) return;
            var indexOfBindKeysTextBox = Array.IndexOf(bindKeysArray, textBox);
            if (multiArray[indexOfBindKeysTextBox].Checked)
            {
                if (textBox.Text == string.Empty) textBox.Text = newKey.ToString();
                else
                {
                    //допилить логику
                    if ((textBox.Text).IndexOf('+') == -1) textBox.Text += $" + {newKey}";
                    else textBox.Text = string.Empty;
                }
            }
            else
            {
                textBox.Text = newKey.ToString();
            }

            textBox.Text = textBox.Text.ToUpper();
        }

        private void bindKeysTextBox_GotFocus(object obj, EventArgs args)
        {
            var textBox = (TextBox)obj;
            textBox.Text = string.Empty;
            currentBindTextBox = textBox;
            textBox.KeyPress += bindKeysTextBox_KeyPress;
        }

        private void bindKeysTextBox_LostFocus(object obj, EventArgs args)
        {
            var textBox = (TextBox)obj;
            textBox.KeyPress -= bindKeysTextBox_KeyPress;
        }

        public SimpleBinder()
        {
            InitializeComponent();
            multiArray = new[]
            {
                multi0, multi1, multi2, multi3, multi4, 
                multi5, multi6, multi7, multi8, multi9
            };

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
            ParseFromJsonToWinForms(pathToJson);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusButton_Click(object sender, EventArgs e)
        {
            if (statusButton.Text == "Turn On")
            {
                statusButton.Text = "Turn Off";
                statusLabel.BackColor = Color.LawnGreen;
                defaultButton.Enabled = false;
                cancelButton_Click(null, null);
                for (int i = 0; i < bindKeysArray.Length; i++)
                {
                    bindKeysArray[i].Enabled = false;
                    bindTextArray[i].Enabled = false;
                    multiArray[i].Enabled = false;
                    enabledArray[i].Enabled = false;
                    modifierArray[i].Enabled = false;
                }
                /*
                 тут логика включения биндера
                 */
            }
            else
            {
                statusButton.Text = "Turn On";
                statusLabel.BackColor = Color.Red;
                defaultButton.Enabled = true;
                for (int i = 0; i < bindKeysArray.Length; i++)
                {
                    bindKeysArray[i].Enabled = true;
                    bindTextArray[i].Enabled = true;
                    multiArray[i].Enabled = true;
                    enabledArray[i].Enabled = true;
                    modifierArray[i].Enabled = true;
                }
                /*
                тут выключение биндера
                */
            }
        }

        /// <summary>
        /// Parse value from components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            ParseToJson(pathToJson);
            isValueChanged = false;
            SwitchSaveAndCancelButtons();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ParseFromJsonToWinForms(pathToJson);
            isValueChanged = false;
            SwitchSaveAndCancelButtons();
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < bindKeysArray.Length; i++)
            {
                bindKeysArray[i].Text = "";
                bindTextArray[i].Text = "";
                multiArray[i].Checked = false;
                enabledArray[i].Checked = false;
                modifierArray[i].SelectedIndex = 0;
            }
        }
    }
}