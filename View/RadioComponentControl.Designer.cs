namespace View
{
	partial class RadioComponentControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.radioComponentTypeGroupBox = new System.Windows.Forms.GroupBox();
			this.resistorRadioButton = new System.Windows.Forms.RadioButton();
			this.inductorRadioButton = new System.Windows.Forms.RadioButton();
			this.capacitorRadioButton = new System.Windows.Forms.RadioButton();
			this.quantityUnitLabel = new System.Windows.Forms.Label();
			this.valueDoubleTextBox = new RegexControlsSDK.PositiveDoubleTextBox();
			this.radioComponentTypeGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioComponentTypeGroupBox
			// 
			this.radioComponentTypeGroupBox.Controls.Add(this.capacitorRadioButton);
			this.radioComponentTypeGroupBox.Controls.Add(this.inductorRadioButton);
			this.radioComponentTypeGroupBox.Controls.Add(this.resistorRadioButton);
			this.radioComponentTypeGroupBox.Location = new System.Drawing.Point(3, 3);
			this.radioComponentTypeGroupBox.Name = "radioComponentTypeGroupBox";
			this.radioComponentTypeGroupBox.Size = new System.Drawing.Size(232, 90);
			this.radioComponentTypeGroupBox.TabIndex = 0;
			this.radioComponentTypeGroupBox.TabStop = false;
			this.radioComponentTypeGroupBox.Text = "Тип радиокомпонента";
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
			// QuantityUnitLabel
			// 
			this.quantityUnitLabel.AutoSize = true;
			this.quantityUnitLabel.Location = new System.Drawing.Point(6, 102);
			this.quantityUnitLabel.Name = "QuantityUnitLabel";
			this.quantityUnitLabel.Size = new System.Drawing.Size(71, 13);
			this.quantityUnitLabel.TabIndex = 3;
			this.quantityUnitLabel.Text = "Quantity, Unit";
			// 
			// valueDoubleTextBox
			// 
			this.valueDoubleTextBox.Location = new System.Drawing.Point(131, 99);
			this.valueDoubleTextBox.Name = "valueDoubleTextBox";
			this.valueDoubleTextBox.Pattern = "^([0-9]+[\\.\\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";
			this.valueDoubleTextBox.Size = new System.Drawing.Size(104, 20);
			this.valueDoubleTextBox.TabIndex = 4;
			// 
			// RadioComponentControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.valueDoubleTextBox);
			this.Controls.Add(this.quantityUnitLabel);
			this.Controls.Add(this.radioComponentTypeGroupBox);
			this.Name = "RadioComponentControl";
			this.Size = new System.Drawing.Size(239, 125);
			this.radioComponentTypeGroupBox.ResumeLayout(false);
			this.radioComponentTypeGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox radioComponentTypeGroupBox;
		private System.Windows.Forms.RadioButton capacitorRadioButton;
		private System.Windows.Forms.RadioButton inductorRadioButton;
		private System.Windows.Forms.RadioButton resistorRadioButton;
		private System.Windows.Forms.Label quantityUnitLabel;
		private RegexControlsSDK.PositiveDoubleTextBox valueDoubleTextBox;
	}
}
