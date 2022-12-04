using Microsoft.CSharp.RuntimeBinder;

namespace SimpleBinder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Multi0 = new System.Windows.Forms.CheckBox();
            this.multiLabel = new System.Windows.Forms.Label();
            this.enabledLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.bindNumberLabel = new System.Windows.Forms.Label();
            this.bindNumber0 = new System.Windows.Forms.Label();
            this.bindKeysLabel = new System.Windows.Forms.Label();
            this.bindKeys0 = new System.Windows.Forms.TextBox();
            this.bindTextLabel = new System.Windows.Forms.Label();
            this.bindText0 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bindKeys1 = new System.Windows.Forms.TextBox();
            this.bindNumber1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.bindKeys2 = new System.Windows.Forms.TextBox();
            this.bindNumber2 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.bindKeys3 = new System.Windows.Forms.TextBox();
            this.bindNumber3 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.bindKeys4 = new System.Windows.Forms.TextBox();
            this.bindNumber4 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.bindKeys5 = new System.Windows.Forms.TextBox();
            this.bindNumber5 = new System.Windows.Forms.Label();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.bindKeys6 = new System.Windows.Forms.TextBox();
            this.bindNumber6 = new System.Windows.Forms.Label();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.bindKeys7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.bindKeys8 = new System.Windows.Forms.TextBox();
            this.bindNumber8 = new System.Windows.Forms.Label();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.bindKeys9 = new System.Windows.Forms.TextBox();
            this.bindNumber9 = new System.Windows.Forms.Label();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Multi0
            // 
            this.Multi0.Location = new System.Drawing.Point(182, 34);
            this.Multi0.Name = "Multi0";
            this.Multi0.Size = new System.Drawing.Size(18, 22);
            this.Multi0.TabIndex = 1;
            this.Multi0.UseVisualStyleBackColor = true;
            // 
            // multiLabel
            // 
            this.multiLabel.Location = new System.Drawing.Point(173, 15);
            this.multiLabel.Name = "multiLabel";
            this.multiLabel.Size = new System.Drawing.Size(40, 16);
            this.multiLabel.TabIndex = 2;
            this.multiLabel.Text = "Multi";
            // 
            // enabledLabel
            // 
            this.enabledLabel.Location = new System.Drawing.Point(206, 15);
            this.enabledLabel.Name = "enabledLabel";
            this.enabledLabel.Size = new System.Drawing.Size(48, 16);
            this.enabledLabel.TabIndex = 4;
            this.enabledLabel.Text = "Enabled";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(215, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 22);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // bindNumberLabel
            // 
            this.bindNumberLabel.Location = new System.Drawing.Point(12, 17);
            this.bindNumberLabel.Name = "bindNumberLabel";
            this.bindNumberLabel.Size = new System.Drawing.Size(21, 16);
            this.bindNumberLabel.TabIndex = 5;
            this.bindNumberLabel.Text = "№";
            // 
            // bindNumber0
            // 
            this.bindNumber0.Location = new System.Drawing.Point(12, 40);
            this.bindNumber0.Name = "bindNumber0";
            this.bindNumber0.Size = new System.Drawing.Size(21, 16);
            this.bindNumber0.TabIndex = 6;
            this.bindNumber0.Text = "1";
            // 
            // bindKeysLabel
            // 
            this.bindKeysLabel.Location = new System.Drawing.Point(49, 17);
            this.bindKeysLabel.Name = "bindKeysLabel";
            this.bindKeysLabel.Size = new System.Drawing.Size(118, 14);
            this.bindKeysLabel.TabIndex = 7;
            this.bindKeysLabel.Text = "Bind";
            // 
            // bindKeys0
            // 
            this.bindKeys0.Location = new System.Drawing.Point(24, 34);
            this.bindKeys0.Name = "bindKeys0";
            this.bindKeys0.Size = new System.Drawing.Size(152, 20);
            this.bindKeys0.TabIndex = 8;
            // 
            // bindTextLabel
            // 
            this.bindTextLabel.Location = new System.Drawing.Point(260, 15);
            this.bindTextLabel.Name = "bindTextLabel";
            this.bindTextLabel.Size = new System.Drawing.Size(502, 16);
            this.bindTextLabel.TabIndex = 9;
            this.bindTextLabel.Text = "Bind";
            // 
            // bindText0
            // 
            this.bindText0.Location = new System.Drawing.Point(260, 34);
            this.bindText0.Name = "bindText0";
            this.bindText0.Size = new System.Drawing.Size(502, 20);
            this.bindText0.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(260, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(502, 20);
            this.textBox1.TabIndex = 15;
            // 
            // bindKeys1
            // 
            this.bindKeys1.Location = new System.Drawing.Point(24, 60);
            this.bindKeys1.Name = "bindKeys1";
            this.bindKeys1.Size = new System.Drawing.Size(152, 20);
            this.bindKeys1.TabIndex = 14;
            // 
            // bindNumber1
            // 
            this.bindNumber1.Location = new System.Drawing.Point(12, 66);
            this.bindNumber1.Name = "bindNumber1";
            this.bindNumber1.Size = new System.Drawing.Size(21, 16);
            this.bindNumber1.TabIndex = 13;
            this.bindNumber1.Text = "2";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(215, 60);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 22);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(182, 60);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(18, 22);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(260, 95);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(502, 20);
            this.textBox3.TabIndex = 20;
            // 
            // bindKeys2
            // 
            this.bindKeys2.Location = new System.Drawing.Point(24, 95);
            this.bindKeys2.Name = "bindKeys2";
            this.bindKeys2.Size = new System.Drawing.Size(152, 20);
            this.bindKeys2.TabIndex = 19;
            // 
            // bindNumber2
            // 
            this.bindNumber2.Location = new System.Drawing.Point(12, 101);
            this.bindNumber2.Name = "bindNumber2";
            this.bindNumber2.Size = new System.Drawing.Size(21, 16);
            this.bindNumber2.TabIndex = 18;
            this.bindNumber2.Text = "3";
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(215, 95);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(18, 22);
            this.checkBox4.TabIndex = 17;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(182, 95);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(18, 22);
            this.checkBox5.TabIndex = 16;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(260, 130);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(502, 20);
            this.textBox5.TabIndex = 25;
            // 
            // bindKeys3
            // 
            this.bindKeys3.Location = new System.Drawing.Point(24, 130);
            this.bindKeys3.Name = "bindKeys3";
            this.bindKeys3.Size = new System.Drawing.Size(152, 20);
            this.bindKeys3.TabIndex = 24;
            // 
            // bindNumber3
            // 
            this.bindNumber3.Location = new System.Drawing.Point(12, 136);
            this.bindNumber3.Name = "bindNumber3";
            this.bindNumber3.Size = new System.Drawing.Size(21, 16);
            this.bindNumber3.TabIndex = 23;
            this.bindNumber3.Text = "4";
            // 
            // checkBox6
            // 
            this.checkBox6.Location = new System.Drawing.Point(215, 130);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(18, 22);
            this.checkBox6.TabIndex = 22;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.Location = new System.Drawing.Point(182, 130);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(18, 22);
            this.checkBox7.TabIndex = 21;
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(260, 165);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(502, 20);
            this.textBox7.TabIndex = 30;
            // 
            // bindKeys4
            // 
            this.bindKeys4.Location = new System.Drawing.Point(24, 165);
            this.bindKeys4.Name = "bindKeys4";
            this.bindKeys4.Size = new System.Drawing.Size(152, 20);
            this.bindKeys4.TabIndex = 29;
            // 
            // bindNumber4
            // 
            this.bindNumber4.Location = new System.Drawing.Point(12, 171);
            this.bindNumber4.Name = "bindNumber4";
            this.bindNumber4.Size = new System.Drawing.Size(21, 16);
            this.bindNumber4.TabIndex = 28;
            this.bindNumber4.Text = "5";
            // 
            // checkBox8
            // 
            this.checkBox8.Location = new System.Drawing.Point(215, 165);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(18, 22);
            this.checkBox8.TabIndex = 27;
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.Location = new System.Drawing.Point(182, 165);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(18, 22);
            this.checkBox9.TabIndex = 26;
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(260, 203);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(502, 20);
            this.textBox9.TabIndex = 35;
            // 
            // bindKeys5
            // 
            this.bindKeys5.Location = new System.Drawing.Point(24, 203);
            this.bindKeys5.Name = "bindKeys5";
            this.bindKeys5.Size = new System.Drawing.Size(152, 20);
            this.bindKeys5.TabIndex = 34;
            // 
            // bindNumber5
            // 
            this.bindNumber5.Location = new System.Drawing.Point(12, 209);
            this.bindNumber5.Name = "bindNumber5";
            this.bindNumber5.Size = new System.Drawing.Size(21, 16);
            this.bindNumber5.TabIndex = 33;
            this.bindNumber5.Text = "6";
            // 
            // checkBox10
            // 
            this.checkBox10.Location = new System.Drawing.Point(215, 203);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(18, 22);
            this.checkBox10.TabIndex = 32;
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.Location = new System.Drawing.Point(182, 203);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(18, 22);
            this.checkBox11.TabIndex = 31;
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(260, 241);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(502, 20);
            this.textBox11.TabIndex = 40;
            // 
            // bindKeys6
            // 
            this.bindKeys6.Location = new System.Drawing.Point(24, 241);
            this.bindKeys6.Name = "bindKeys6";
            this.bindKeys6.Size = new System.Drawing.Size(152, 20);
            this.bindKeys6.TabIndex = 39;
            // 
            // bindNumber6
            // 
            this.bindNumber6.Location = new System.Drawing.Point(12, 247);
            this.bindNumber6.Name = "bindNumber6";
            this.bindNumber6.Size = new System.Drawing.Size(21, 16);
            this.bindNumber6.TabIndex = 38;
            this.bindNumber6.Text = "7";
            // 
            // checkBox12
            // 
            this.checkBox12.Location = new System.Drawing.Point(215, 241);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(18, 22);
            this.checkBox12.TabIndex = 37;
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.Location = new System.Drawing.Point(182, 241);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(18, 22);
            this.checkBox13.TabIndex = 36;
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(260, 277);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(502, 20);
            this.textBox13.TabIndex = 45;
            // 
            // bindKeys7
            // 
            this.bindKeys7.Location = new System.Drawing.Point(24, 277);
            this.bindKeys7.Name = "bindKeys7";
            this.bindKeys7.Size = new System.Drawing.Size(152, 20);
            this.bindKeys7.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 16);
            this.label8.TabIndex = 43;
            this.label8.Text = "8";
            // 
            // checkBox14
            // 
            this.checkBox14.Location = new System.Drawing.Point(215, 277);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(18, 22);
            this.checkBox14.TabIndex = 42;
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.Location = new System.Drawing.Point(182, 277);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(18, 22);
            this.checkBox15.TabIndex = 41;
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(260, 313);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(502, 20);
            this.textBox15.TabIndex = 50;
            // 
            // bindKeys8
            // 
            this.bindKeys8.Location = new System.Drawing.Point(24, 313);
            this.bindKeys8.Name = "bindKeys8";
            this.bindKeys8.Size = new System.Drawing.Size(152, 20);
            this.bindKeys8.TabIndex = 49;
            // 
            // bindNumber8
            // 
            this.bindNumber8.Location = new System.Drawing.Point(12, 319);
            this.bindNumber8.Name = "bindNumber8";
            this.bindNumber8.Size = new System.Drawing.Size(21, 16);
            this.bindNumber8.TabIndex = 48;
            this.bindNumber8.Text = "9";
            // 
            // checkBox16
            // 
            this.checkBox16.Location = new System.Drawing.Point(215, 313);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(18, 22);
            this.checkBox16.TabIndex = 47;
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            this.checkBox17.Location = new System.Drawing.Point(182, 313);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(18, 22);
            this.checkBox17.TabIndex = 46;
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(260, 353);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(502, 20);
            this.textBox17.TabIndex = 55;
            // 
            // bindKeys9
            // 
            this.bindKeys9.Location = new System.Drawing.Point(24, 353);
            this.bindKeys9.Name = "bindKeys9";
            this.bindKeys9.Size = new System.Drawing.Size(152, 20);
            this.bindKeys9.TabIndex = 54;
            // 
            // bindNumber9
            // 
            this.bindNumber9.Location = new System.Drawing.Point(4, 356);
            this.bindNumber9.Name = "bindNumber9";
            this.bindNumber9.Size = new System.Drawing.Size(29, 16);
            this.bindNumber9.TabIndex = 53;
            this.bindNumber9.Text = "10";
            // 
            // checkBox18
            // 
            this.checkBox18.Location = new System.Drawing.Point(215, 353);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(18, 22);
            this.checkBox18.TabIndex = 52;
            this.checkBox18.UseVisualStyleBackColor = true;
            // 
            // checkBox19
            // 
            this.checkBox19.Location = new System.Drawing.Point(182, 353);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(18, 22);
            this.checkBox19.TabIndex = 51;
            this.checkBox19.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(522, 379);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(102, 23);
            this.saveButton.TabIndex = 56;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(660, 379);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(102, 23);
            this.cancelButton.TabIndex = 57;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // statusButton
            // 
            this.statusButton.Location = new System.Drawing.Point(12, 379);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(164, 23);
            this.statusButton.TabIndex = 58;
            this.statusButton.Text = "Turn On";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Red;
            this.statusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statusLabel.Location = new System.Drawing.Point(180, 380);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(52, 21);
            this.statusLabel.TabIndex = 59;
            this.statusLabel.Text = "  ";
            this.statusLabel.UseMnemonic = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 405);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.bindKeys9);
            this.Controls.Add(this.bindNumber9);
            this.Controls.Add(this.checkBox18);
            this.Controls.Add(this.checkBox19);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.bindKeys8);
            this.Controls.Add(this.bindNumber8);
            this.Controls.Add(this.checkBox16);
            this.Controls.Add(this.checkBox17);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.bindKeys7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBox14);
            this.Controls.Add(this.checkBox15);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.bindKeys6);
            this.Controls.Add(this.bindNumber6);
            this.Controls.Add(this.checkBox12);
            this.Controls.Add(this.checkBox13);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.bindKeys5);
            this.Controls.Add(this.bindNumber5);
            this.Controls.Add(this.checkBox10);
            this.Controls.Add(this.checkBox11);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.bindKeys4);
            this.Controls.Add(this.bindNumber4);
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.checkBox9);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.bindKeys3);
            this.Controls.Add(this.bindNumber3);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.bindKeys2);
            this.Controls.Add(this.bindNumber2);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bindKeys1);
            this.Controls.Add(this.bindNumber1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.bindText0);
            this.Controls.Add(this.bindTextLabel);
            this.Controls.Add(this.bindKeys0);
            this.Controls.Add(this.bindKeysLabel);
            this.Controls.Add(this.bindNumber0);
            this.Controls.Add(this.bindNumberLabel);
            this.Controls.Add(this.enabledLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.multiLabel);
            this.Controls.Add(this.Multi0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binder";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label bindNumber0;

        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.Label statusLabel;

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox bindKeys7;
        private System.Windows.Forms.Label bindNumber8;
        private System.Windows.Forms.Label bindNumberLabel;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox bindText0;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox bindKeys8;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox bindKeys9;
        private System.Windows.Forms.Label bindNumber9;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox19;

        private System.Windows.Forms.TextBox bindKeys1;
        private System.Windows.Forms.Label bindNumber1;
        private System.Windows.Forms.Label bindNumber2;
        private System.Windows.Forms.Label bindNumber3;
        private System.Windows.Forms.Label bindNumber4;
        private System.Windows.Forms.Label bindNumber5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label bindNumber6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox bindKeys2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox bindKeys3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox bindKeys4;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox bindKeys5;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox bindKeys6;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;

        private System.Windows.Forms.TextBox bindKeys0;
        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.CheckBox Multi0;

        private System.Windows.Forms.Label bindKeysLabel;
        private System.Windows.Forms.Label bindTextLabel;

        private System.Windows.Forms.Label multiLabel;
        private System.Windows.Forms.Label enabledLabel;

        private System.Windows.Forms.CheckBox checkBox1;

        #endregion
    }
}