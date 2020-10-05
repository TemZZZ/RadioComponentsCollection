namespace View
{
	partial class RadiocomponentControl_
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
			this.radiocomponentTypeGroupBox = new System.Windows.Forms.GroupBox();
			this.capacitorRadioButton = new System.Windows.Forms.RadioButton();
			this.inductorRadioButton = new System.Windows.Forms.RadioButton();
			this.resistorRadioButton = new System.Windows.Forms.RadioButton();
			this.quantityUnitLabel = new System.Windows.Forms.Label();
			this.valueDoubleTextBox = new RegexControlsSDK.PositiveDoubleTextBox();
			this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
			this.radiocomponentTypeGroupBox.SuspendLayout();
			this.propertiesGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// radiocomponentTypeGroupBox
			// 
			this.radiocomponentTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.radiocomponentTypeGroupBox.Controls.Add(this.capacitorRadioButton);
			this.radiocomponentTypeGroupBox.Controls.Add(this.inductorRadioButton);
			this.radiocomponentTypeGroupBox.Controls.Add(this.resistorRadioButton);
			this.radiocomponentTypeGroupBox.Location = new System.Drawing.Point(3, 3);
			this.radiocomponentTypeGroupBox.Name = "radiocomponentTypeGroupBox";
			this.radiocomponentTypeGroupBox.Size = new System.Drawing.Size(261, 90);
			this.radiocomponentTypeGroupBox.TabIndex = 0;
			this.radiocomponentTypeGroupBox.TabStop = false;
			this.radiocomponentTypeGroupBox.Text = "Тип радиокомпонента";
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
			// quantityUnitLabel
			// 
			this.quantityUnitLabel.AutoSize = true;
			this.quantityUnitLabel.Location = new System.Drawing.Point(6, 19);
			this.quantityUnitLabel.Name = "quantityUnitLabel";
			this.quantityUnitLabel.Size = new System.Drawing.Size(71, 13);
			this.quantityUnitLabel.TabIndex = 3;
			this.quantityUnitLabel.Text = "Quantity, Unit";
			// 
			// valueDoubleTextBox
			// 
			this.valueDoubleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.valueDoubleTextBox.Location = new System.Drawing.Point(125, 16);
			this.valueDoubleTextBox.Name = "valueDoubleTextBox";
			this.valueDoubleTextBox.Pattern = "^([0-9]+[\\.\\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";
			this.valueDoubleTextBox.Size = new System.Drawing.Size(130, 20);
			this.valueDoubleTextBox.TabIndex = 4;
			this.valueDoubleTextBox.Text = "0";
			// 
			// propertiesGroupBox
			// 
			this.propertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertiesGroupBox.Controls.Add(this.quantityUnitLabel);
			this.propertiesGroupBox.Controls.Add(this.valueDoubleTextBox);
			this.propertiesGroupBox.Location = new System.Drawing.Point(3, 99);
			this.propertiesGroupBox.Name = "propertiesGroupBox";
			this.propertiesGroupBox.Size = new System.Drawing.Size(261, 45);
			this.propertiesGroupBox.TabIndex = 7;
			this.propertiesGroupBox.TabStop = false;
			this.propertiesGroupBox.Text = "Свойства радиокомпонента";
			// 
			// RadiocomponentControl_
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.propertiesGroupBox);
			this.Controls.Add(this.radiocomponentTypeGroupBox);
			this.Name = "RadiocomponentControl_";
			this.Size = new System.Drawing.Size(267, 146);
			this.radiocomponentTypeGroupBox.ResumeLayout(false);
			this.radiocomponentTypeGroupBox.PerformLayout();
			this.propertiesGroupBox.ResumeLayout(false);
			this.propertiesGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox radiocomponentTypeGroupBox;
		private System.Windows.Forms.RadioButton capacitorRadioButton;
		private System.Windows.Forms.RadioButton inductorRadioButton;
		private System.Windows.Forms.RadioButton resistorRadioButton;
		private System.Windows.Forms.Label quantityUnitLabel;
		private RegexControlsSDK.PositiveDoubleTextBox valueDoubleTextBox;
		private System.Windows.Forms.GroupBox propertiesGroupBox;
	}
}
