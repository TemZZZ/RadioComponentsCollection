namespace View
{
	partial class SetRadiocomponentSaveOptionForm
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
			this.saveSelectedRadioButton = new System.Windows.Forms.RadioButton();
			this.saveAllRadioButton = new System.Windows.Forms.RadioButton();
			this.saveOptionsGroupBox = new System.Windows.Forms.GroupBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.saveOptionsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// saveSelectedRadioButton
			// 
			this.saveSelectedRadioButton.AutoSize = true;
			this.saveSelectedRadioButton.Location = new System.Drawing.Point(6, 42);
			this.saveSelectedRadioButton.Name = "saveSelectedRadioButton";
			this.saveSelectedRadioButton.Size = new System.Drawing.Size(279, 17);
			this.saveSelectedRadioButton.TabIndex = 0;
			this.saveSelectedRadioButton.Text = "Сохранить только выделенные радиокомпоненты";
			this.saveSelectedRadioButton.UseVisualStyleBackColor = true;
			// 
			// saveAllRadioButton
			// 
			this.saveAllRadioButton.AutoSize = true;
			this.saveAllRadioButton.Checked = true;
			this.saveAllRadioButton.Location = new System.Drawing.Point(6, 19);
			this.saveAllRadioButton.Name = "saveAllRadioButton";
			this.saveAllRadioButton.Size = new System.Drawing.Size(195, 17);
			this.saveAllRadioButton.TabIndex = 1;
			this.saveAllRadioButton.TabStop = true;
			this.saveAllRadioButton.Text = "Сохранить все радиокомпоненты";
			this.saveAllRadioButton.UseVisualStyleBackColor = true;
			// 
			// saveOptionsGroupBox
			// 
			this.saveOptionsGroupBox.Controls.Add(this.saveAllRadioButton);
			this.saveOptionsGroupBox.Controls.Add(this.saveSelectedRadioButton);
			this.saveOptionsGroupBox.Location = new System.Drawing.Point(12, 12);
			this.saveOptionsGroupBox.Name = "saveOptionsGroupBox";
			this.saveOptionsGroupBox.Size = new System.Drawing.Size(291, 67);
			this.saveOptionsGroupBox.TabIndex = 2;
			this.saveOptionsGroupBox.TabStop = false;
			this.saveOptionsGroupBox.Text = "Настройки сохранения";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(78, 85);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 3;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(159, 85);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Отмена";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// SetRadiocomponentSaveOptionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(314, 118);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.saveOptionsGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SetRadiocomponentSaveOptionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Сохранение радиокомпонентов";
			this.saveOptionsGroupBox.ResumeLayout(false);
			this.saveOptionsGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RadioButton saveSelectedRadioButton;
		private System.Windows.Forms.RadioButton saveAllRadioButton;
		private System.Windows.Forms.GroupBox saveOptionsGroupBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
	}
}