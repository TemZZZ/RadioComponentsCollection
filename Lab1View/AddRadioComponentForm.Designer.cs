namespace Lab1View
{
    partial class AddRadioComponentForm
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
            this.resistorRadioButton = new System.Windows.Forms.RadioButton();
            this.inductorRadioButton = new System.Windows.Forms.RadioButton();
            this.capacitorRadioButton = new System.Windows.Forms.RadioButton();
            this.addRadioComponentButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.componentTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.generateRandomDataButton = new System.Windows.Forms.Button();
            this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.valueRegexTextBox = new RegexTextBoxLib.RegexTextBox();
            this.valueUnitLabel = new System.Windows.Forms.Label();
            this.componentTypeGroupBox.SuspendLayout();
            this.propertiesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // resistorRadioButton
            // 
            this.resistorRadioButton.AutoSize = true;
            this.resistorRadioButton.Location = new System.Drawing.Point(6, 19);
            this.resistorRadioButton.Name = "resistorRadioButton";
            this.resistorRadioButton.Size = new System.Drawing.Size(73, 17);
            this.resistorRadioButton.TabIndex = 0;
            this.resistorRadioButton.TabStop = true;
            this.resistorRadioButton.Text = "Резистор";
            this.resistorRadioButton.UseVisualStyleBackColor = true;
            // 
            // inductorRadioButton
            // 
            this.inductorRadioButton.AutoSize = true;
            this.inductorRadioButton.Location = new System.Drawing.Point(6, 42);
            this.inductorRadioButton.Name = "inductorRadioButton";
            this.inductorRadioButton.Size = new System.Drawing.Size(146, 17);
            this.inductorRadioButton.TabIndex = 1;
            this.inductorRadioButton.TabStop = true;
            this.inductorRadioButton.Text = "Катушка индуктивности";
            this.inductorRadioButton.UseVisualStyleBackColor = true;
            // 
            // capacitorRadioButton
            // 
            this.capacitorRadioButton.AutoSize = true;
            this.capacitorRadioButton.Location = new System.Drawing.Point(6, 65);
            this.capacitorRadioButton.Name = "capacitorRadioButton";
            this.capacitorRadioButton.Size = new System.Drawing.Size(91, 17);
            this.capacitorRadioButton.TabIndex = 2;
            this.capacitorRadioButton.TabStop = true;
            this.capacitorRadioButton.Text = "Конденсатор";
            this.capacitorRadioButton.UseVisualStyleBackColor = true;
            // 
            // addRadioComponentButton
            // 
            this.addRadioComponentButton.Location = new System.Drawing.Point(12, 159);
            this.addRadioComponentButton.Name = "addRadioComponentButton";
            this.addRadioComponentButton.Size = new System.Drawing.Size(126, 23);
            this.addRadioComponentButton.TabIndex = 3;
            this.addRadioComponentButton.Text = "Добавить";
            this.addRadioComponentButton.UseVisualStyleBackColor = true;
            this.addRadioComponentButton.Click += new System.EventHandler(this.AddRadioComponentButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(147, 159);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(126, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // componentTypeGroupBox
            // 
            this.componentTypeGroupBox.Controls.Add(this.generateRandomDataButton);
            this.componentTypeGroupBox.Controls.Add(this.resistorRadioButton);
            this.componentTypeGroupBox.Controls.Add(this.inductorRadioButton);
            this.componentTypeGroupBox.Controls.Add(this.capacitorRadioButton);
            this.componentTypeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.componentTypeGroupBox.Name = "componentTypeGroupBox";
            this.componentTypeGroupBox.Size = new System.Drawing.Size(261, 89);
            this.componentTypeGroupBox.TabIndex = 5;
            this.componentTypeGroupBox.TabStop = false;
            this.componentTypeGroupBox.Text = "Тип компонента";
            // 
            // generateRandomDataButton
            // 
            this.generateRandomDataButton.Location = new System.Drawing.Point(159, 16);
            this.generateRandomDataButton.Name = "generateRandomDataButton";
            this.generateRandomDataButton.Size = new System.Drawing.Size(96, 23);
            this.generateRandomDataButton.TabIndex = 3;
            this.generateRandomDataButton.Text = "Random Data";
            this.generateRandomDataButton.UseVisualStyleBackColor = true;
            this.generateRandomDataButton.Click += new System.EventHandler(this.GenerateRandomDataButton_Click);
            // 
            // propertiesGroupBox
            // 
            this.propertiesGroupBox.Controls.Add(this.valueRegexTextBox);
            this.propertiesGroupBox.Controls.Add(this.valueUnitLabel);
            this.propertiesGroupBox.Location = new System.Drawing.Point(12, 108);
            this.propertiesGroupBox.Name = "propertiesGroupBox";
            this.propertiesGroupBox.Size = new System.Drawing.Size(261, 45);
            this.propertiesGroupBox.TabIndex = 6;
            this.propertiesGroupBox.TabStop = false;
            this.propertiesGroupBox.Text = "Свойства компонента";
            // 
            // valueRegexTextBox
            // 
            this.valueRegexTextBox.Location = new System.Drawing.Point(135, 16);
            this.valueRegexTextBox.Name = "valueRegexTextBox";
            this.valueRegexTextBox.Pattern = null;
            this.valueRegexTextBox.Size = new System.Drawing.Size(120, 20);
            this.valueRegexTextBox.TabIndex = 1;
            // 
            // valueUnitLabel
            // 
            this.valueUnitLabel.AutoSize = true;
            this.valueUnitLabel.Location = new System.Drawing.Point(6, 19);
            this.valueUnitLabel.Name = "valueUnitLabel";
            this.valueUnitLabel.Size = new System.Drawing.Size(59, 13);
            this.valueUnitLabel.TabIndex = 0;
            this.valueUnitLabel.Text = "Value, Unit";
            // 
            // AddRadioComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 193);
            this.Controls.Add(this.propertiesGroupBox);
            this.Controls.Add(this.componentTypeGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addRadioComponentButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddRadioComponentForm";
            this.Text = "Добавить радиокомпонент";
            this.componentTypeGroupBox.ResumeLayout(false);
            this.componentTypeGroupBox.PerformLayout();
            this.propertiesGroupBox.ResumeLayout(false);
            this.propertiesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton resistorRadioButton;
        private System.Windows.Forms.RadioButton inductorRadioButton;
        private System.Windows.Forms.RadioButton capacitorRadioButton;
        private System.Windows.Forms.Button addRadioComponentButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox componentTypeGroupBox;
        private System.Windows.Forms.GroupBox propertiesGroupBox;
        private RegexTextBoxLib.RegexTextBox valueRegexTextBox;
        private System.Windows.Forms.Label valueUnitLabel;
        private System.Windows.Forms.Button generateRandomDataButton;
    }
}