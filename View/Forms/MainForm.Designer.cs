namespace View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.radiocomponentsGroupBox = new System.Windows.Forms.GroupBox();
			this.radiocomponentsDataGridView = new System.Windows.Forms.DataGridView();
			this.addRadiocomponentButton = new System.Windows.Forms.Button();
			this.deleteRadiocomponentButton = new System.Windows.Forms.Button();
			this.saveToFileButton = new System.Windows.Forms.Button();
			this.loadFromFileButton = new System.Windows.Forms.Button();
			this.searchButton = new System.Windows.Forms.Button();
			this.frequencyLabel = new System.Windows.Forms.Label();
			this.impedanceLabel = new System.Windows.Forms.Label();
			this.frequencyPositiveDoubleTextBox = new RegexControlsSDK.PositiveDoubleTextBox();
			this.impedanceTextBox = new System.Windows.Forms.TextBox();
			this.impedanceGroupBox = new System.Windows.Forms.GroupBox();
			this.addDeleteComponentGroupBox = new System.Windows.Forms.GroupBox();
			this.workWithFilesGroupBox = new System.Windows.Forms.GroupBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.modifyButton = new System.Windows.Forms.Button();
			this._modifyRadiocomponentControl = new View.RadiocomponentControl();
			this.radiocomponentsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.radiocomponentsDataGridView)).BeginInit();
			this.impedanceGroupBox.SuspendLayout();
			this.addDeleteComponentGroupBox.SuspendLayout();
			this.workWithFilesGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// radiocomponentsGroupBox
			// 
			this.radiocomponentsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.radiocomponentsGroupBox.Controls.Add(this.radiocomponentsDataGridView);
			this.radiocomponentsGroupBox.Location = new System.Drawing.Point(12, 12);
			this.radiocomponentsGroupBox.Name = "radiocomponentsGroupBox";
			this.radiocomponentsGroupBox.Size = new System.Drawing.Size(684, 453);
			this.radiocomponentsGroupBox.TabIndex = 0;
			this.radiocomponentsGroupBox.TabStop = false;
			this.radiocomponentsGroupBox.Text = "Радиокомпоненты";
			// 
			// radiocomponentsDataGridView
			// 
			this.radiocomponentsDataGridView.AllowUserToOrderColumns = true;
			this.radiocomponentsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.radiocomponentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.radiocomponentsDataGridView.Location = new System.Drawing.Point(6, 19);
			this.radiocomponentsDataGridView.Name = "radiocomponentsDataGridView";
			this.radiocomponentsDataGridView.ReadOnly = true;
			this.radiocomponentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.radiocomponentsDataGridView.Size = new System.Drawing.Size(672, 424);
			this.radiocomponentsDataGridView.TabIndex = 0;
			this.radiocomponentsDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.RadiocomponentsDataGridView_RowsAdded);
			this.radiocomponentsDataGridView.SelectionChanged += new System.EventHandler(this.RadiocomponentsDataGridView_SelectionChanged);
			// 
			// addRadiocomponentButton
			// 
			this.addRadiocomponentButton.Location = new System.Drawing.Point(6, 19);
			this.addRadiocomponentButton.Name = "addRadiocomponentButton";
			this.addRadiocomponentButton.Size = new System.Drawing.Size(220, 23);
			this.addRadiocomponentButton.TabIndex = 0;
			this.addRadiocomponentButton.Text = "Добавить компонент";
			this.addRadiocomponentButton.UseVisualStyleBackColor = true;
			this.addRadiocomponentButton.Click += new System.EventHandler(this.AddRadiocomponentButton_Click);
			// 
			// deleteRadiocomponentButton
			// 
			this.deleteRadiocomponentButton.Location = new System.Drawing.Point(6, 48);
			this.deleteRadiocomponentButton.Name = "deleteRadiocomponentButton";
			this.deleteRadiocomponentButton.Size = new System.Drawing.Size(220, 23);
			this.deleteRadiocomponentButton.TabIndex = 1;
			this.deleteRadiocomponentButton.Text = "Удалить компонент";
			this.deleteRadiocomponentButton.UseVisualStyleBackColor = true;
			this.deleteRadiocomponentButton.Click += new System.EventHandler(this.DeleteRadiocomponentButton_Click);
			// 
			// saveToFileButton
			// 
			this.saveToFileButton.Location = new System.Drawing.Point(6, 19);
			this.saveToFileButton.Name = "saveToFileButton";
			this.saveToFileButton.Size = new System.Drawing.Size(220, 23);
			this.saveToFileButton.TabIndex = 2;
			this.saveToFileButton.Text = "Сохранить в файл";
			this.saveToFileButton.UseVisualStyleBackColor = true;
			this.saveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
			// 
			// loadFromFileButton
			// 
			this.loadFromFileButton.Location = new System.Drawing.Point(6, 48);
			this.loadFromFileButton.Name = "loadFromFileButton";
			this.loadFromFileButton.Size = new System.Drawing.Size(220, 23);
			this.loadFromFileButton.TabIndex = 3;
			this.loadFromFileButton.Text = "Загрузить из файла";
			this.loadFromFileButton.UseVisualStyleBackColor = true;
			this.loadFromFileButton.Click += new System.EventHandler(this.LoadFromFileButton_Click);
			// 
			// searchButton
			// 
			this.searchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.searchButton.Location = new System.Drawing.Point(708, 442);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(220, 23);
			this.searchButton.TabIndex = 4;
			this.searchButton.Text = "Поиск";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// frequencyLabel
			// 
			this.frequencyLabel.AutoSize = true;
			this.frequencyLabel.Location = new System.Drawing.Point(20, 24);
			this.frequencyLabel.Name = "frequencyLabel";
			this.frequencyLabel.Size = new System.Drawing.Size(70, 13);
			this.frequencyLabel.TabIndex = 5;
			this.frequencyLabel.Text = "Частота, Гц:";
			// 
			// impedanceLabel
			// 
			this.impedanceLabel.AutoSize = true;
			this.impedanceLabel.Location = new System.Drawing.Point(6, 53);
			this.impedanceLabel.Name = "impedanceLabel";
			this.impedanceLabel.Size = new System.Drawing.Size(84, 13);
			this.impedanceLabel.TabIndex = 6;
			this.impedanceLabel.Text = "Импеданс, Ом:";
			// 
			// frequencyPositiveDoubleTextBox
			// 
			this.frequencyPositiveDoubleTextBox.Location = new System.Drawing.Point(96, 21);
			this.frequencyPositiveDoubleTextBox.Name = "frequencyPositiveDoubleTextBox";
			this.frequencyPositiveDoubleTextBox.Pattern = "^([0-9]+[\\.\\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";
			this.frequencyPositiveDoubleTextBox.Size = new System.Drawing.Size(130, 20);
			this.frequencyPositiveDoubleTextBox.TabIndex = 7;
			this.frequencyPositiveDoubleTextBox.Text = "0";
			// 
			// impedanceTextBox
			// 
			this.impedanceTextBox.Location = new System.Drawing.Point(96, 50);
			this.impedanceTextBox.Name = "impedanceTextBox";
			this.impedanceTextBox.ReadOnly = true;
			this.impedanceTextBox.Size = new System.Drawing.Size(130, 20);
			this.impedanceTextBox.TabIndex = 8;
			// 
			// impedanceGroupBox
			// 
			this.impedanceGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.impedanceGroupBox.Controls.Add(this.impedanceLabel);
			this.impedanceGroupBox.Controls.Add(this.impedanceTextBox);
			this.impedanceGroupBox.Controls.Add(this.frequencyLabel);
			this.impedanceGroupBox.Controls.Add(this.frequencyPositiveDoubleTextBox);
			this.impedanceGroupBox.Location = new System.Drawing.Point(702, 190);
			this.impedanceGroupBox.Name = "impedanceGroupBox";
			this.impedanceGroupBox.Size = new System.Drawing.Size(234, 78);
			this.impedanceGroupBox.TabIndex = 9;
			this.impedanceGroupBox.TabStop = false;
			this.impedanceGroupBox.Text = "Импеданс";
			// 
			// addDeleteComponentGroupBox
			// 
			this.addDeleteComponentGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.addDeleteComponentGroupBox.Controls.Add(this.addRadiocomponentButton);
			this.addDeleteComponentGroupBox.Controls.Add(this.deleteRadiocomponentButton);
			this.addDeleteComponentGroupBox.Location = new System.Drawing.Point(702, 274);
			this.addDeleteComponentGroupBox.Name = "addDeleteComponentGroupBox";
			this.addDeleteComponentGroupBox.Size = new System.Drawing.Size(234, 78);
			this.addDeleteComponentGroupBox.TabIndex = 10;
			this.addDeleteComponentGroupBox.TabStop = false;
			this.addDeleteComponentGroupBox.Text = "Добавить/удалить компонент";
			// 
			// workWithFilesGroupBox
			// 
			this.workWithFilesGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.workWithFilesGroupBox.Controls.Add(this.saveToFileButton);
			this.workWithFilesGroupBox.Controls.Add(this.loadFromFileButton);
			this.workWithFilesGroupBox.Location = new System.Drawing.Point(702, 358);
			this.workWithFilesGroupBox.Name = "workWithFilesGroupBox";
			this.workWithFilesGroupBox.Size = new System.Drawing.Size(234, 78);
			this.workWithFilesGroupBox.TabIndex = 11;
			this.workWithFilesGroupBox.TabStop = false;
			this.workWithFilesGroupBox.Text = "Работа с файлами";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// modifyButton
			// 
			this.modifyButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.modifyButton.Location = new System.Drawing.Point(708, 161);
			this.modifyButton.Name = "modifyButton";
			this.modifyButton.Size = new System.Drawing.Size(220, 23);
			this.modifyButton.TabIndex = 13;
			this.modifyButton.Text = "Изменить";
			this.modifyButton.UseVisualStyleBackColor = true;
			this.modifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
			// 
			// _modifyRadiocomponentControl
			// 
			this._modifyRadiocomponentControl.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this._modifyRadiocomponentControl.Location = new System.Drawing.Point(702, 9);
			this._modifyRadiocomponentControl.Name = "_modifyRadiocomponentControl";
			this._modifyRadiocomponentControl.Radiocomponent = null;
			this._modifyRadiocomponentControl.ReadOnly = false;
			this._modifyRadiocomponentControl.Size = new System.Drawing.Size(234, 146);
			this._modifyRadiocomponentControl.TabIndex = 12;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(946, 476);
			this.Controls.Add(this.modifyButton);
			this.Controls.Add(this._modifyRadiocomponentControl);
			this.Controls.Add(this.workWithFilesGroupBox);
			this.Controls.Add(this.addDeleteComponentGroupBox);
			this.Controls.Add(this.impedanceGroupBox);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.radiocomponentsGroupBox);
			this.MinimumSize = new System.Drawing.Size(962, 515);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Коллекция радиокомпонентов";
			this.radiocomponentsGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.radiocomponentsDataGridView)).EndInit();
			this.impedanceGroupBox.ResumeLayout(false);
			this.impedanceGroupBox.PerformLayout();
			this.addDeleteComponentGroupBox.ResumeLayout(false);
			this.workWithFilesGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox radiocomponentsGroupBox;
        private System.Windows.Forms.DataGridView radiocomponentsDataGridView;
        private System.Windows.Forms.Button addRadiocomponentButton;
        private System.Windows.Forms.Button deleteRadiocomponentButton;
        private System.Windows.Forms.Button saveToFileButton;
        private System.Windows.Forms.Button loadFromFileButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Label impedanceLabel;
        private RegexControlsSDK.PositiveDoubleTextBox frequencyPositiveDoubleTextBox;
        private System.Windows.Forms.TextBox impedanceTextBox;
        private System.Windows.Forms.GroupBox impedanceGroupBox;
        private System.Windows.Forms.GroupBox addDeleteComponentGroupBox;
        private System.Windows.Forms.GroupBox workWithFilesGroupBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private RadiocomponentControl _modifyRadiocomponentControl;
		private System.Windows.Forms.Button modifyButton;
	}
}

