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
        
        public Form1()
        {
            InitializeComponent();

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