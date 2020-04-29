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
            this.componentsDataGridView = new System.Windows.Forms.DataGridView();
            this.addRadioComponentButton = new System.Windows.Forms.Button();
            this.deleteRadioComponentButton = new System.Windows.Forms.Button();
            this.radioComponentsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.componentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // radioComponentsGroupBox
            // 
            this.radioComponentsGroupBox.Controls.Add(this.componentsDataGridView);
            this.radioComponentsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.radioComponentsGroupBox.Name = "radioComponentsGroupBox";
            this.radioComponentsGroupBox.Size = new System.Drawing.Size(544, 328);
            this.radioComponentsGroupBox.TabIndex = 0;
            this.radioComponentsGroupBox.TabStop = false;
            this.radioComponentsGroupBox.Text = "Радиокомпоненты";
            // 
            // componentsDataGridView
            // 
            this.componentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.componentsDataGridView.Location = new System.Drawing.Point(6, 19);
            this.componentsDataGridView.Name = "componentsDataGridView";
            this.componentsDataGridView.ReadOnly = true;
            this.componentsDataGridView.Size = new System.Drawing.Size(532, 303);
            this.componentsDataGridView.TabIndex = 0;
            // 
            // addRadioComponentButton
            // 
            this.addRadioComponentButton.Location = new System.Drawing.Point(157, 346);
            this.addRadioComponentButton.Name = "addRadioComponentButton";
            this.addRadioComponentButton.Size = new System.Drawing.Size(124, 23);
            this.addRadioComponentButton.TabIndex = 0;
            this.addRadioComponentButton.Text = "Добавить компонент";
            this.addRadioComponentButton.UseVisualStyleBackColor = true;
            // 
            // deleteRadioComponentButton
            // 
            this.deleteRadioComponentButton.Location = new System.Drawing.Point(287, 346);
            this.deleteRadioComponentButton.Name = "deleteRadioComponentButton";
            this.deleteRadioComponentButton.Size = new System.Drawing.Size(124, 23);
            this.deleteRadioComponentButton.TabIndex = 1;
            this.deleteRadioComponentButton.Text = "Удалить компонент";
            this.deleteRadioComponentButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 381);
            this.Controls.Add(this.deleteRadioComponentButton);
            this.Controls.Add(this.radioComponentsGroupBox);
            this.Controls.Add(this.addRadioComponentButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.radioComponentsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.componentsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox radioComponentsGroupBox;
        private System.Windows.Forms.DataGridView componentsDataGridView;
        private System.Windows.Forms.Button addRadioComponentButton;
        private System.Windows.Forms.Button deleteRadioComponentButton;
    }
}

