using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBinder
{
    public partial class Form1 : Form
    {
        
        private List<TextBox> bindKeysArray;
        private List<TextBox> bindTextArray;
        private List<CheckBox> multi;
        private List<CheckBox> enabled;
        public Form1()
        {
            InitializeComponent();

            multi = new List<CheckBox>();
            multi.Add(multi0);
            multi.Add(multi1);
            multi.Add(multi2);
            multi.Add(multi3);
            multi.Add(multi4);
            multi.Add(multi5);
            multi.Add(multi6);
            multi.Add(multi7);
            multi.Add(multi8);
            multi.Add(multi9);
            
            enabled = new List<CheckBox>();
            enabled.Add(enabled0);
            enabled.Add(enabled1);
            enabled.Add(enabled2);
            enabled.Add(enabled3);
            enabled.Add(enabled4);
            enabled.Add(enabled5);
            enabled.Add(enabled6);
            enabled.Add(enabled7);
            enabled.Add(enabled8);
            enabled.Add(enabled9);

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
                statusLabel.BackColor = Color.Green;
                saveButton.Enabled = false;
                cancelButton.Enabled = false;
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
                /*
                тут выключение биндера
                */
            }
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}