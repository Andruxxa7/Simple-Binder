namespace SimpleBinder;

public partial class SimpleBinder
{
    private TextBox currentBindTextBox;

    /// <summary>
    /// Добавляет ивент ValueChangedEvent на TextBox'ы и  CheckBox'ы
    /// </summary>
    private void AddValueChangedEvent()
    {
        for (var controlIndex = 0; controlIndex < Controls.Count; controlIndex++)
        {
            var control = Controls[controlIndex];
            switch (control)
            {
                case CheckBox checkBox:
                    checkBox.CheckedChanged += ValueIsChanged;
                    break;
                case TextBox textBox:
                    textBox.TextChanged += ValueIsChanged;
                    break;
                case ListBox listBox:
                    listBox.SelectedIndexChanged += ValueIsChanged;
                    break;
            }
        }
    }

    /// <summary>
    /// Удаляет ивент ValueChangedEvent c TextBox'ы и CheckBox'ы
    /// </summary>
    private void DeleteValueChangedEvent()
    {
        for (var controlIndex = 0; controlIndex < Controls.Count; controlIndex++)
        {
            var control = Controls[controlIndex];
            switch (control)
            {
                case CheckBox checkBox:
                    checkBox.CheckedChanged -= ValueIsChanged;
                    break;
                case TextBox:
                    control.TextChanged -= ValueIsChanged;
                    break;
                case ListBox listBox:
                    listBox.SelectedIndexChanged -= ValueIsChanged;
                    break;
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