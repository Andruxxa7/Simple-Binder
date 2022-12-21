using System;
using System.Windows.Forms;

namespace SimpleBinder
{
    public partial class SimpleBinder
    {
        private TextBox currentBindTextBox;

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
                else if (control is ListBox listBox)
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
                else if (control is ListBox listBox)
                {
                    listBox.SelectedIndexChanged -= ValueIsChanged;
                }
            }
        }

        private void ValueIsChanged(object sender, EventArgs e)
        {
            isValueChanged = true;
            SwitchSaveAndCancelButtons();
            DeleteValueChangedEvent();
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
    }
}