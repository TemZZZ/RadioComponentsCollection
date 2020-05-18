namespace Lab1View
{
	partial class SearchRadioComponentForm
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
			this.radioComponentTypeLabel = new System.Windows.Forms.Label();
			this.valueFiltersGroupBox = new System.Windows.Forms.GroupBox();
			this.equalPositiveDoubleTextBox = new PositiveDoubleTextBoxLib.PositiveDoubleTextBox();
			this.moreThanPositiveDoubleTextBox = new PositiveDoubleTextBoxLib.PositiveDoubleTextBox();
			this.lessThanPositiveDoubleTextBox = new PositiveDoubleTextBoxLib.PositiveDoubleTextBox();
			this.equalCheckBox = new System.Windows.Forms.CheckBox();
			this.moreThanCheckBox = new System.Windows.Forms.CheckBox();
			this.lessThanCheckBox = new System.Windows.Forms.CheckBox();
			this.searchRadioComponentsButton = new System.Windows.Forms.Button();
			this.searchStatusLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.radioComponentTypeComboBox = new System.Windows.Forms.ComboBox();
			this.valueFiltersGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioComponentTypeLabel
			// 
			this.radioComponentTypeLabel.AutoSize = true;
			this.radioComponentTypeLabel.Location = new System.Drawing.Point(12, 9);
			this.radioComponentTypeLabel.Name = "radioComponentTypeLabel";
			this.radioComponentTypeLabel.Size = new System.Drawing.Size(120, 13);
			this.radioComponentTypeLabel.TabIndex = 0;
			this.radioComponentTypeLabel.Text = "Тип радиокомпонента";
			// 
			// valueFiltersGroupBox
			// 
			this.valueFiltersGroupBox.Controls.Add(this.equalPositiveDoubleTextBox);
			this.valueFiltersGroupBox.Controls.Add(this.moreThanPositiveDoubleTextBox);
			this.valueFiltersGroupBox.Controls.Add(this.lessThanPositiveDoubleTextBox);
			this.valueFiltersGroupBox.Controls.Add(this.equalCheckBox);
			this.valueFiltersGroupBox.Controls.Add(this.moreThanCheckBox);
			this.valueFiltersGroupBox.Controls.Add(this.lessThanCheckBox);
			this.valueFiltersGroupBox.Location = new System.Drawing.Point(15, 52);
			this.valueFiltersGroupBox.Name = "valueFiltersGroupBox";
			this.valueFiltersGroupBox.Size = new System.Drawing.Size(262, 98);
			this.valueFiltersGroupBox.TabIndex = 2;
			this.valueFiltersGroupBox.TabStop = false;
			this.valueFiltersGroupBox.Text = "Значение физической величины";
			// 
			// equalPositiveDoubleTextBox
			// 
			this.equalPositiveDoubleTextBox.Location = new System.Drawing.Point(132, 69);
			this.equalPositiveDoubleTextBox.Name = "equalPositiveDoubleTextBox";
			this.equalPositiveDoubleTextBox.Pattern = "^([0-9]+[\\.\\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";
			this.equalPositiveDoubleTextBox.Size = new System.Drawing.Size(124, 20);
			this.equalPositiveDoubleTextBox.TabIndex = 5;
			this.equalPositiveDoubleTextBox.Text = "0";
			// 
			// moreThanPositiveDoubleTextBox
			// 
			this.moreThanPositiveDoubleTextBox.Location = new System.Drawing.Point(132, 42);
			this.moreThanPositiveDoubleTextBox.Name = "moreThanPositiveDoubleTextBox";
			this.moreThanPositiveDoubleTextBox.Pattern = "^([0-9]+[\\.\\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";
			this.moreThanPositiveDoubleTextBox.Size = new System.Drawing.Size(124, 20);
			this.moreThanPositiveDoubleTextBox.TabIndex = 4;
			this.moreThanPositiveDoubleTextBox.Text = "0";
			// 
			// lessThanPositiveDoubleTextBox
			// 
			this.lessThanPositiveDoubleTextBox.Location = new System.Drawing.Point(132, 16);
			this.lessThanPositiveDoubleTextBox.Name = "lessThanPositiveDoubleTextBox";
			this.lessThanPositiveDoubleTextBox.Pattern = "^([0-9]+[\\.\\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";
			this.lessThanPositiveDoubleTextBox.Size = new System.Drawing.Size(124, 20);
			this.lessThanPositiveDoubleTextBox.TabIndex = 3;
			this.lessThanPositiveDoubleTextBox.Text = "0";
			// 
			// equalCheckBox
			// 
			this.equalCheckBox.AutoSize = true;
			this.equalCheckBox.Location = new System.Drawing.Point(6, 71);
			this.equalCheckBox.Name = "equalCheckBox";
			this.equalCheckBox.Size = new System.Drawing.Size(71, 17);
			this.equalCheckBox.TabIndex = 2;
			this.equalCheckBox.Text = "= (равно)";
			this.equalCheckBox.UseVisualStyleBackColor = true;
			// 
			// moreThanCheckBox
			// 
			this.moreThanCheckBox.AutoSize = true;
			this.moreThanCheckBox.Location = new System.Drawing.Point(6, 45);
			this.moreThanCheckBox.Name = "moreThanCheckBox";
			this.moreThanCheckBox.Size = new System.Drawing.Size(104, 17);
			this.moreThanCheckBox.TabIndex = 1;
			this.moreThanCheckBox.Text = "> (больше, чем)";
			this.moreThanCheckBox.UseVisualStyleBackColor = true;
			// 
			// lessThanCheckBox
			// 
			this.lessThanCheckBox.AutoSize = true;
			this.lessThanCheckBox.Location = new System.Drawing.Point(6, 19);
			this.lessThanCheckBox.Name = "lessThanCheckBox";
			this.lessThanCheckBox.Size = new System.Drawing.Size(106, 17);
			this.lessThanCheckBox.TabIndex = 0;
			this.lessThanCheckBox.Text = "< (меньше, чем)";
			this.lessThanCheckBox.UseVisualStyleBackColor = true;
			// 
			// searchRadioComponentsButton
			// 
			this.searchRadioComponentsButton.Location = new System.Drawing.Point(66, 156);
			this.searchRadioComponentsButton.Name = "searchRadioComponentsButton";
			this.searchRadioComponentsButton.Size = new System.Drawing.Size(75, 23);
			this.searchRadioComponentsButton.TabIndex = 3;
			this.searchRadioComponentsButton.Text = "Найти";
			this.searchRadioComponentsButton.UseVisualStyleBackColor = true;
			this.searchRadioComponentsButton.Click += new System.EventHandler(this.SearchRadioComponentsButton_Click);
			// 
			// searchStatusLabel
			// 
			this.searchStatusLabel.AutoSize = true;
			this.searchStatusLabel.Location = new System.Drawing.Point(15, 186);
			this.searchStatusLabel.Name = "searchStatusLabel";
			this.searchStatusLabel.Size = new System.Drawing.Size(249, 13);
			this.searchStatusLabel.TabIndex = 4;
			this.searchStatusLabel.Text = "Задайте параметры поиска и нажмите \"Найти\"";
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(147, 156);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Отмена";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// radioComponentTypeComboBox
			// 
			this.radioComponentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.radioComponentTypeComboBox.FormattingEnabled = true;
			this.radioComponentTypeComboBox.Location = new System.Drawing.Point(15, 25);
			this.radioComponentTypeComboBox.Name = "radioComponentTypeComboBox";
			this.radioComponentTypeComboBox.Size = new System.Drawing.Size(262, 21);
			this.radioComponentTypeComboBox.TabIndex = 1;
			// 
			// SearchRadioComponentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(289, 235);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.searchStatusLabel);
			this.Controls.Add(this.searchRadioComponentsButton);
			this.Controls.Add(this.valueFiltersGroupBox);
			this.Controls.Add(this.radioComponentTypeComboBox);
			this.Controls.Add(this.radioComponentTypeLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SearchRadioComponentForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Поиск радиокомпонентов";
			this.valueFiltersGroupBox.ResumeLayout(false);
			this.valueFiltersGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label radioComponentTypeLabel;
		private System.Windows.Forms.GroupBox valueFiltersGroupBox;
		private PositiveDoubleTextBoxLib.PositiveDoubleTextBox equalPositiveDoubleTextBox;
		private PositiveDoubleTextBoxLib.PositiveDoubleTextBox moreThanPositiveDoubleTextBox;
		private PositiveDoubleTextBoxLib.PositiveDoubleTextBox lessThanPositiveDoubleTextBox;
		private System.Windows.Forms.CheckBox equalCheckBox;
		private System.Windows.Forms.CheckBox moreThanCheckBox;
		private System.Windows.Forms.CheckBox lessThanCheckBox;
		private System.Windows.Forms.Button searchRadioComponentsButton;
		private System.Windows.Forms.Label searchStatusLabel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.ComboBox radioComponentTypeComboBox;
	}
}