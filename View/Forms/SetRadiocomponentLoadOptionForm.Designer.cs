namespace View.Forms
{
	partial class SetRadiocomponentLoadOptionForm
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
			this.loadOptionsGroupBox = new System.Windows.Forms.GroupBox();
			this.replaceAllRadioButton = new System.Windows.Forms.RadioButton();
			this.addToEndRadioButton = new System.Windows.Forms.RadioButton();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.loadOptionsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// loadOptionsGroupBox
			// 
			this.loadOptionsGroupBox.Controls.Add(this.replaceAllRadioButton);
			this.loadOptionsGroupBox.Controls.Add(this.addToEndRadioButton);
			this.loadOptionsGroupBox.Location = new System.Drawing.Point(12, 12);
			this.loadOptionsGroupBox.Name = "loadOptionsGroupBox";
			this.loadOptionsGroupBox.Size = new System.Drawing.Size(271, 64);
			this.loadOptionsGroupBox.TabIndex = 0;
			this.loadOptionsGroupBox.TabStop = false;
			this.loadOptionsGroupBox.Text = "Настройки загрузки";
			// 
			// replaceAllRadioButton
			// 
			this.replaceAllRadioButton.AutoSize = true;
			this.replaceAllRadioButton.Location = new System.Drawing.Point(6, 42);
			this.replaceAllRadioButton.Name = "replaceAllRadioButton";
			this.replaceAllRadioButton.Size = new System.Drawing.Size(245, 17);
			this.replaceAllRadioButton.TabIndex = 1;
			this.replaceAllRadioButton.Text = "Заменить все радиокомпоненты в таблице";
			this.replaceAllRadioButton.UseVisualStyleBackColor = true;
			// 
			// addToEndRadioButton
			// 
			this.addToEndRadioButton.AutoSize = true;
			this.addToEndRadioButton.Checked = true;
			this.addToEndRadioButton.Location = new System.Drawing.Point(6, 19);
			this.addToEndRadioButton.Name = "addToEndRadioButton";
			this.addToEndRadioButton.Size = new System.Drawing.Size(259, 17);
			this.addToEndRadioButton.TabIndex = 0;
			this.addToEndRadioButton.TabStop = true;
			this.addToEndRadioButton.Text = "Добавить радиокомпоненты в конец таблицы";
			this.addToEndRadioButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(69, 82);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(151, 82);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Отмена";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// SetRadiocomponentLoadOptionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 115);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.loadOptionsGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SetRadiocomponentLoadOptionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Загрузка радиокомпонентов";
			this.loadOptionsGroupBox.ResumeLayout(false);
			this.loadOptionsGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox loadOptionsGroupBox;
		private System.Windows.Forms.RadioButton replaceAllRadioButton;
		private System.Windows.Forms.RadioButton addToEndRadioButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
	}
}