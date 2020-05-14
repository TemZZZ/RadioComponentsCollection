namespace Lab1View
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
			this.radioComponentsGroupBox = new System.Windows.Forms.GroupBox();
			this.radioComponentsDataGridView = new System.Windows.Forms.DataGridView();
			this.addRadioComponentButton = new System.Windows.Forms.Button();
			this.deleteRadioComponentButton = new System.Windows.Forms.Button();
			this.saveToFileButton = new System.Windows.Forms.Button();
			this.loadFromFileButton = new System.Windows.Forms.Button();
			this.searchButton = new System.Windows.Forms.Button();
			this.frequencyLabel = new System.Windows.Forms.Label();
			this.impedanceLabel = new System.Windows.Forms.Label();
			this.frequencyPositiveDoubleTextBox = new PositiveDoubleTextBoxLib.PositiveDoubleTextBox();
			this.impedanceTextBox = new System.Windows.Forms.TextBox();
			this.impedanceGroupBox = new System.Windows.Forms.GroupBox();
			this.addDeleteComponentGroupBox = new System.Windows.Forms.GroupBox();
			this.workWithFilesGroupBox = new System.Windows.Forms.GroupBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.radioComponentsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.radioComponentsDataGridView)).BeginInit();
			this.impedanceGroupBox.SuspendLayout();
			this.addDeleteComponentGroupBox.SuspendLayout();
			this.workWithFilesGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioComponentsGroupBox
			// 
			this.radioComponentsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.radioComponentsGroupBox.Controls.Add(this.radioComponentsDataGridView);
			this.radioComponentsGroupBox.Location = new System.Drawing.Point(12, 12);
			this.radioComponentsGroupBox.Name = "radioComponentsGroupBox";
			this.radioComponentsGroupBox.Size = new System.Drawing.Size(684, 332);
			this.radioComponentsGroupBox.TabIndex = 0;
			this.radioComponentsGroupBox.TabStop = false;
			this.radioComponentsGroupBox.Text = "Радиокомпоненты";
			// 
			// radioComponentsDataGridView
			// 
			this.radioComponentsDataGridView.AllowUserToOrderColumns = true;
			this.radioComponentsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.radioComponentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.radioComponentsDataGridView.Location = new System.Drawing.Point(6, 19);
			this.radioComponentsDataGridView.Name = "radioComponentsDataGridView";
			this.radioComponentsDataGridView.ReadOnly = true;
			this.radioComponentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.radioComponentsDataGridView.Size = new System.Drawing.Size(672, 303);
			this.radioComponentsDataGridView.TabIndex = 0;
			this.radioComponentsDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.RadioComponentsDataGridView_RowsAdded);
			this.radioComponentsDataGridView.SelectionChanged += new System.EventHandler(this.RadioComponentsDataGridView_SelectionChanged);
			// 
			// addRadioComponentButton
			// 
			this.addRadioComponentButton.Location = new System.Drawing.Point(6, 19);
			this.addRadioComponentButton.Name = "addRadioComponentButton";
			this.addRadioComponentButton.Size = new System.Drawing.Size(161, 23);
			this.addRadioComponentButton.TabIndex = 0;
			this.addRadioComponentButton.Text = "Добавить компонент";
			this.addRadioComponentButton.UseVisualStyleBackColor = true;
			this.addRadioComponentButton.Click += new System.EventHandler(this.AddRadioComponentButton_Click);
			// 
			// deleteRadioComponentButton
			// 
			this.deleteRadioComponentButton.Location = new System.Drawing.Point(6, 48);
			this.deleteRadioComponentButton.Name = "deleteRadioComponentButton";
			this.deleteRadioComponentButton.Size = new System.Drawing.Size(161, 23);
			this.deleteRadioComponentButton.TabIndex = 1;
			this.deleteRadioComponentButton.Text = "Удалить компонент";
			this.deleteRadioComponentButton.UseVisualStyleBackColor = true;
			this.deleteRadioComponentButton.Click += new System.EventHandler(this.DeleteRadioComponentButton_Click);
			// 
			// saveToFileButton
			// 
			this.saveToFileButton.Location = new System.Drawing.Point(6, 19);
			this.saveToFileButton.Name = "saveToFileButton";
			this.saveToFileButton.Size = new System.Drawing.Size(161, 23);
			this.saveToFileButton.TabIndex = 2;
			this.saveToFileButton.Text = "Сохранить в файл";
			this.saveToFileButton.UseVisualStyleBackColor = true;
			this.saveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
			// 
			// loadFromFileButton
			// 
			this.loadFromFileButton.Location = new System.Drawing.Point(6, 48);
			this.loadFromFileButton.Name = "loadFromFileButton";
			this.loadFromFileButton.Size = new System.Drawing.Size(161, 23);
			this.loadFromFileButton.TabIndex = 3;
			this.loadFromFileButton.Text = "Загрузить из файла";
			this.loadFromFileButton.UseVisualStyleBackColor = true;
			this.loadFromFileButton.Click += new System.EventHandler(this.LoadFromFileButton_Click);
			// 
			// searchButton
			// 
			this.searchButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.searchButton.Location = new System.Drawing.Point(612, 383);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(84, 23);
			this.searchButton.TabIndex = 4;
			this.searchButton.Text = "Поиск";
			this.searchButton.UseVisualStyleBackColor = true;
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
			this.frequencyPositiveDoubleTextBox.Location = new System.Drawing.Point(96, 20);
			this.frequencyPositiveDoubleTextBox.Name = "frequencyPositiveDoubleTextBox";
			this.frequencyPositiveDoubleTextBox.Pattern = "^([0-9]+[\\.\\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";
			this.frequencyPositiveDoubleTextBox.Size = new System.Drawing.Size(130, 20);
			this.frequencyPositiveDoubleTextBox.TabIndex = 7;
			this.frequencyPositiveDoubleTextBox.Text = "0";
			// 
			// impedanceTextBox
			// 
			this.impedanceTextBox.Location = new System.Drawing.Point(96, 49);
			this.impedanceTextBox.Name = "impedanceTextBox";
			this.impedanceTextBox.ReadOnly = true;
			this.impedanceTextBox.Size = new System.Drawing.Size(130, 20);
			this.impedanceTextBox.TabIndex = 8;
			// 
			// impedanceGroupBox
			// 
			this.impedanceGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.impedanceGroupBox.Controls.Add(this.impedanceLabel);
			this.impedanceGroupBox.Controls.Add(this.impedanceTextBox);
			this.impedanceGroupBox.Controls.Add(this.frequencyLabel);
			this.impedanceGroupBox.Controls.Add(this.frequencyPositiveDoubleTextBox);
			this.impedanceGroupBox.Location = new System.Drawing.Point(12, 350);
			this.impedanceGroupBox.Name = "impedanceGroupBox";
			this.impedanceGroupBox.Size = new System.Drawing.Size(234, 78);
			this.impedanceGroupBox.TabIndex = 9;
			this.impedanceGroupBox.TabStop = false;
			this.impedanceGroupBox.Text = "Импеданс";
			// 
			// addDeleteComponentGroupBox
			// 
			this.addDeleteComponentGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.addDeleteComponentGroupBox.Controls.Add(this.addRadioComponentButton);
			this.addDeleteComponentGroupBox.Controls.Add(this.deleteRadioComponentButton);
			this.addDeleteComponentGroupBox.Location = new System.Drawing.Point(252, 350);
			this.addDeleteComponentGroupBox.Name = "addDeleteComponentGroupBox";
			this.addDeleteComponentGroupBox.Size = new System.Drawing.Size(174, 78);
			this.addDeleteComponentGroupBox.TabIndex = 10;
			this.addDeleteComponentGroupBox.TabStop = false;
			this.addDeleteComponentGroupBox.Text = "Добавить/удалить компонент";
			// 
			// workWithFilesGroupBox
			// 
			this.workWithFilesGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.workWithFilesGroupBox.Controls.Add(this.saveToFileButton);
			this.workWithFilesGroupBox.Controls.Add(this.loadFromFileButton);
			this.workWithFilesGroupBox.Location = new System.Drawing.Point(432, 350);
			this.workWithFilesGroupBox.Name = "workWithFilesGroupBox";
			this.workWithFilesGroupBox.Size = new System.Drawing.Size(174, 78);
			this.workWithFilesGroupBox.TabIndex = 11;
			this.workWithFilesGroupBox.TabStop = false;
			this.workWithFilesGroupBox.Text = "Работа с файлами";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(707, 439);
			this.Controls.Add(this.workWithFilesGroupBox);
			this.Controls.Add(this.addDeleteComponentGroupBox);
			this.Controls.Add(this.impedanceGroupBox);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.radioComponentsGroupBox);
			this.MinimumSize = new System.Drawing.Size(723, 478);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Коллекция радиокомпонентов";
			this.radioComponentsGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.radioComponentsDataGridView)).EndInit();
			this.impedanceGroupBox.ResumeLayout(false);
			this.impedanceGroupBox.PerformLayout();
			this.addDeleteComponentGroupBox.ResumeLayout(false);
			this.workWithFilesGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox radioComponentsGroupBox;
        private System.Windows.Forms.DataGridView radioComponentsDataGridView;
        private System.Windows.Forms.Button addRadioComponentButton;
        private System.Windows.Forms.Button deleteRadioComponentButton;
        private System.Windows.Forms.Button saveToFileButton;
        private System.Windows.Forms.Button loadFromFileButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Label impedanceLabel;
        private PositiveDoubleTextBoxLib.PositiveDoubleTextBox frequencyPositiveDoubleTextBox;
        private System.Windows.Forms.TextBox impedanceTextBox;
        private System.Windows.Forms.GroupBox impedanceGroupBox;
        private System.Windows.Forms.GroupBox addDeleteComponentGroupBox;
        private System.Windows.Forms.GroupBox workWithFilesGroupBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

