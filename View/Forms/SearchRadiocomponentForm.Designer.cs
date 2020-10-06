namespace View.Forms
{
	partial class SearchRadiocomponentForm
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
			this.radiocomponentTypeLabel = new System.Windows.Forms.Label();
			this.valueFiltersGroupBox = new System.Windows.Forms.GroupBox();
			this.equalPositiveDoubleTextBox = new RegexControlsSDK.PositiveDoubleTextBox();
			this.moreThanPositiveDoubleTextBox = new RegexControlsSDK.PositiveDoubleTextBox();
			this.lessThanPositiveDoubleTextBox = new RegexControlsSDK.PositiveDoubleTextBox();
			this.equalCheckBox = new System.Windows.Forms.CheckBox();
			this.moreThanCheckBox = new System.Windows.Forms.CheckBox();
			this.lessThanCheckBox = new System.Windows.Forms.CheckBox();
			this.searchRadiocomponentsButton = new System.Windows.Forms.Button();
			this.searchStatusLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.radiocomponentTypeComboBox = new System.Windows.Forms.ComboBox();
			this.valueFiltersGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// radiocomponentTypeLabel
			// 
			this.radiocomponentTypeLabel.AutoSize = true;
			this.radiocomponentTypeLabel.Location = new System.Drawing.Point(12, 9);
			this.radiocomponentTypeLabel.Name = "radiocomponentTypeLabel";
			this.radiocomponentTypeLabel.Size = new System.Drawing.Size(120, 13);
			this.radiocomponentTypeLabel.TabIndex = 0;
			this.radiocomponentTypeLabel.Text = "Тип радиокомпонента";
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
			// searchRadiocomponentsButton
			// 
			this.searchRadiocomponentsButton.Location = new System.Drawing.Point(66, 156);
			this.searchRadiocomponentsButton.Name = "searchRadiocomponentsButton";
			this.searchRadiocomponentsButton.Size = new System.Drawing.Size(75, 23);
			this.searchRadiocomponentsButton.TabIndex = 3;
			this.searchRadiocomponentsButton.Text = "Найти";
			this.searchRadiocomponentsButton.UseVisualStyleBackColor = true;
			this.searchRadiocomponentsButton.Click += new System.EventHandler(this.SearchRadiocomponentsButton_Click);
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
			// radiocomponentTypeComboBox
			// 
			this.radiocomponentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.radiocomponentTypeComboBox.FormattingEnabled = true;
			this.radiocomponentTypeComboBox.Location = new System.Drawing.Point(15, 25);
			this.radiocomponentTypeComboBox.Name = "radiocomponentTypeComboBox";
			this.radiocomponentTypeComboBox.Size = new System.Drawing.Size(262, 21);
			this.radiocomponentTypeComboBox.TabIndex = 1;
			// 
			// SearchRadiocomponentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(289, 235);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.searchStatusLabel);
			this.Controls.Add(this.searchRadiocomponentsButton);
			this.Controls.Add(this.valueFiltersGroupBox);
			this.Controls.Add(this.radiocomponentTypeComboBox);
			this.Controls.Add(this.radiocomponentTypeLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SearchRadiocomponentForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Поиск радиокомпонентов";
			this.valueFiltersGroupBox.ResumeLayout(false);
			this.valueFiltersGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label radiocomponentTypeLabel;
		private System.Windows.Forms.GroupBox valueFiltersGroupBox;
		private RegexControlsSDK.PositiveDoubleTextBox equalPositiveDoubleTextBox;
		private RegexControlsSDK.PositiveDoubleTextBox moreThanPositiveDoubleTextBox;
		private RegexControlsSDK.PositiveDoubleTextBox lessThanPositiveDoubleTextBox;
		private System.Windows.Forms.CheckBox equalCheckBox;
		private System.Windows.Forms.CheckBox moreThanCheckBox;
		private System.Windows.Forms.CheckBox lessThanCheckBox;
		private System.Windows.Forms.Button searchRadiocomponentsButton;
		private System.Windows.Forms.Label searchStatusLabel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.ComboBox radiocomponentTypeComboBox;
	}
}