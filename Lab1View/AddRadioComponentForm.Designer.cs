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
            this.SuspendLayout();
            // 
            // resistorRadioButton
            // 
            this.resistorRadioButton.AutoSize = true;
            this.resistorRadioButton.Location = new System.Drawing.Point(12, 12);
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
            this.inductorRadioButton.Location = new System.Drawing.Point(12, 35);
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
            this.capacitorRadioButton.Location = new System.Drawing.Point(12, 58);
            this.capacitorRadioButton.Name = "capacitorRadioButton";
            this.capacitorRadioButton.Size = new System.Drawing.Size(91, 17);
            this.capacitorRadioButton.TabIndex = 2;
            this.capacitorRadioButton.TabStop = true;
            this.capacitorRadioButton.Text = "Конденсатор";
            this.capacitorRadioButton.UseVisualStyleBackColor = true;
            // 
            // addRadioComponentButton
            // 
            this.addRadioComponentButton.Location = new System.Drawing.Point(243, 27);
            this.addRadioComponentButton.Name = "addRadioComponentButton";
            this.addRadioComponentButton.Size = new System.Drawing.Size(75, 23);
            this.addRadioComponentButton.TabIndex = 3;
            this.addRadioComponentButton.Text = "Добавить";
            this.addRadioComponentButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(243, 56);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // AddRadioComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 91);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addRadioComponentButton);
            this.Controls.Add(this.capacitorRadioButton);
            this.Controls.Add(this.inductorRadioButton);
            this.Controls.Add(this.resistorRadioButton);
            this.Name = "AddRadioComponentForm";
            this.Text = "AddRadioComponentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton resistorRadioButton;
        private System.Windows.Forms.RadioButton inductorRadioButton;
        private System.Windows.Forms.RadioButton capacitorRadioButton;
        private System.Windows.Forms.Button addRadioComponentButton;
        private System.Windows.Forms.Button cancelButton;
    }
}