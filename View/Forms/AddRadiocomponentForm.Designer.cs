namespace View.Forms
{
    partial class AddRadiocomponentForm
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
			this.addRadiocomponentButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.generateRandomDataButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// addRadiocomponentButton
			// 
			this.addRadiocomponentButton.Location = new System.Drawing.Point(12, 159);
			this.addRadiocomponentButton.Name = "addRadiocomponentButton";
			this.addRadiocomponentButton.Size = new System.Drawing.Size(126, 23);
			this.addRadiocomponentButton.TabIndex = 3;
			this.addRadiocomponentButton.Text = "Добавить";
			this.addRadiocomponentButton.UseVisualStyleBackColor = true;
			this.addRadiocomponentButton.Click += new System.EventHandler(this.AddRadiocomponentButton_Click);
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
			// generateRandomDataButton
			// 
			this.generateRandomDataButton.Location = new System.Drawing.Point(168, 31);
			this.generateRandomDataButton.Name = "generateRandomDataButton";
			this.generateRandomDataButton.Size = new System.Drawing.Size(96, 23);
			this.generateRandomDataButton.TabIndex = 3;
			this.generateRandomDataButton.Text = "Random Data";
			this.generateRandomDataButton.UseVisualStyleBackColor = true;
			this.generateRandomDataButton.Click += new System.EventHandler(this.GenerateRandomDataButton_Click);
			// 
			// AddRadiocomponentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 193);
			this.Controls.Add(this.generateRandomDataButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.addRadiocomponentButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "AddRadiocomponentForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Добавить радиокомпонент";
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addRadiocomponentButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button generateRandomDataButton;
    }
}