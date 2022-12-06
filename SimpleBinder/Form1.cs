using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;

namespace SimpleBinder
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Путь до файла .json, в который сохраняются значения, которые потом парсятся из этого же файла.
        /// </summary>
        private string pathToJson = "settings.json";
        
        private List<TextBox> bindKeysArray;
        private List<TextBox> bindTextArray;
        private List<CheckBox> multiArray;
        private List<CheckBox> enabledArray;
        private List<Bind> Binds;

        /// <summary>
        /// Парсит значения из .json в поля WinForm'ы
        /// </summary>
        /// <param name="path2Json">- путь до файла .json, из которого берутся значения</param>
        private void ParseFromJsonToWinForms(string path2Json)
        {
            if (!File.Exists(path2Json)) return;
            Binds = JsonSerializer.Deserialize<List<Bind>>(File.ReadAllText(path2Json));
            for (var i = 0; i < bindKeysArray.Count; i++)
            {
                if (Binds != null)
                {
                    bindKeysArray[i].Text = Binds[i].BindKeys ?? "";
                    bindTextArray[i].Text = Binds[i].BindText ?? "";
                    multiArray[i].Checked = Binds[i].IsMulti;
                    enabledArray[i].Checked = Binds[i].IsEnabled;
                }
            }
        }

        /// <summary>
        /// Метод для обнуления значений в полях формы
        /// </summary>
        private void SetBackToDefault()
        {
            for (int i = 0; i < bindKeysArray.Count; i++)
            {
                bindKeysArray[i].Text = "";
                bindTextArray[i].Text = "";
                multiArray[i].Checked = false;
                enabledArray[i].Checked = false;
            }
        }

        /// <summary>
        /// Парс значений из полей WinForm'ы в .json
        /// </summary>
        /// <param name="path2Json">- путь до файла .json, в котором сохраняются значения</param>
        private void ParseToJson(string path2Json)
        {
            Binds = new List<Bind>();
            for (var i = 0; i < bindKeysArray.Count; i++)
            {
                var tempKeys = bindKeysArray[i].Text;
                var tempText = bindTextArray[i].Text;
                var isenabled = enabledArray[i].Checked;
                var ismulti = multiArray[i].Checked;
                var bind = new Bind(tempKeys, tempText, isenabled, ismulti);
                Binds.Add(bind);
            }

            File.WriteAllText(path2Json, JsonSerializer.Serialize(Binds));
        }

        public Form1()
        {
            InitializeComponent();

            multiArray = new List<CheckBox>
            {
                multi0,
                multi1,
                multi2,
                multi3,
                multi4,
                multi5,
                multi6,
                multi7,
                multi8,
                multi9
            };

            enabledArray = new List<CheckBox>
            {
                enabled0,
                enabled1,
                enabled2,
                enabled3,
                enabled4,
                enabled5,
                enabled6,
                enabled7,
                enabled8,
                enabled9
            };

            bindKeysArray = new List<TextBox>
            {
                bindKeys0,
                bindKeys1,
                bindKeys2,
                bindKeys3,
                bindKeys4,
                bindKeys5,
                bindKeys6,
                bindKeys7,
                bindKeys8,
                bindKeys9
            };

            bindTextArray = new List<TextBox>
            {
                bindText0,
                bindText1,
                bindText2,
                bindText3,
                bindText4,
                bindText5,
                bindText6,
                bindText7,
                bindText8,
                bindText9
            };
            ParseFromJsonToWinForms(pathToJson);
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
                saveButton.Enabled = false;
                cancelButton.Enabled = false;
                defaultButton.Enabled = false;
                for (int i = 0; i < bindKeysArray.Count; i++)
                {
                    bindKeysArray[i].Enabled = false;
                    bindTextArray[i].Enabled = false;
                    multiArray[i].Enabled = false;
                    enabledArray[i].Enabled = false;
                }
                /*
                 тут логика включения биндера
                 */
            }
            else
            {
                statusButton.Text = "Turn On";
                statusLabel.BackColor = Color.Red;
                saveButton.Enabled = true;
                cancelButton.Enabled = true;
                defaultButton.Enabled = true;
                for (int i = 0; i < bindKeysArray.Count; i++)
                {
                    bindKeysArray[i].Enabled = true;
                    bindTextArray[i].Enabled = true;
                    multiArray[i].Enabled = true;
                    enabledArray[i].Enabled = true;
                }
                /*
                тут выключение биндера
                */
            }
        }

        private void saveButton_Click(object sender, EventArgs e) //parse value from components
        {
            ParseToJson(pathToJson);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ParseFromJsonToWinForms(pathToJson);
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            SetBackToDefault();
        }
    }
}