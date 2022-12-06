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
        private string pathToJson = "settings.json";
        private List<TextBox> bindKeysArray;
        private List<TextBox> bindTextArray;
        private List<CheckBox> multiArray;
        private List<CheckBox> enabledArray;
        private List<Bind> Binds;
        public Form1()
        {
            InitializeComponent();

            multiArray = new List<CheckBox>();
            multiArray.Add(multi0);
            multiArray.Add(multi1);
            multiArray.Add(multi2);
            multiArray.Add(multi3);
            multiArray.Add(multi4);
            multiArray.Add(multi5);
            multiArray.Add(multi6);
            multiArray.Add(multi7);
            multiArray.Add(multi8);
            multiArray.Add(multi9);
            
            enabledArray = new List<CheckBox>();
            enabledArray.Add(enabled0);
            enabledArray.Add(enabled1);
            enabledArray.Add(enabled2);
            enabledArray.Add(enabled3);
            enabledArray.Add(enabled4);
            enabledArray.Add(enabled5);
            enabledArray.Add(enabled6);
            enabledArray.Add(enabled7);
            enabledArray.Add(enabled8);
            enabledArray.Add(enabled9);

            bindKeysArray = new List<TextBox>();
            bindKeysArray.Add(bindKeys0);
            bindKeysArray.Add(bindKeys1);
            bindKeysArray.Add(bindKeys2);
            bindKeysArray.Add(bindKeys3);
            bindKeysArray.Add(bindKeys4);
            bindKeysArray.Add(bindKeys5);
            bindKeysArray.Add(bindKeys6);
            bindKeysArray.Add(bindKeys7);
            bindKeysArray.Add(bindKeys8);
            bindKeysArray.Add(bindKeys9);

            bindTextArray = new List<TextBox>();
            bindTextArray.Add(bindText0);
            bindTextArray.Add(bindText1);
            bindTextArray.Add(bindText2);
            bindTextArray.Add(bindText3);
            bindTextArray.Add(bindText4);
            bindTextArray.Add(bindText5);
            bindTextArray.Add(bindText6);
            bindTextArray.Add(bindText7);
            bindTextArray.Add(bindText8);
            bindTextArray.Add(bindText9);
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            if (statusButton.Text == "Turn On")
            {
                statusButton.Text = "Turn Off";
                statusLabel.BackColor = Color.LawnGreen;
                saveButton.Enabled = false;
                cancelButton.Enabled = false;
                for (int i = 0; i < bindKeysArray.Count; i++)
                {
                    bindKeysArray[i].Enabled = false;
                    bindTextArray[i].Enabled = false;
                    multiArray[i].Enabled = false;
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
                for (int i = 0; i < bindKeysArray.Count; i++)
                {
                    bindKeysArray[i].Enabled = true;
                    bindTextArray[i].Enabled = true;
                    multiArray[i].Enabled = true;
                }
                /*
                тут выключение биндера
                */
            }
        }

        private void saveButton_Click(object sender, EventArgs e)//parse value from components
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
            File.WriteAllText(pathToJson,JsonSerializer.Serialize(Binds));
        }
    }
}