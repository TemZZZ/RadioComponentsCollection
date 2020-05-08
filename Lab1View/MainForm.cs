using System;
using System.ComponentModel;
using System.Windows.Forms;
using Lab1Model;


namespace Lab1View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список радиокомпонентов
        /// </summary>
        internal static BindingList<RadioComponentBase> radioComponents;
        /// <summary>
        /// Форма добавления новых радиокомпонентов
        /// </summary>
        private readonly AddRadioComponentForm addRadioComponentForm;

        public MainForm()
        {
            InitializeComponent();

            addRadioComponentForm = new AddRadioComponentForm();
            radioComponents = new BindingList<RadioComponentBase>();

            // Инструкция связывает источник данных radioComponents
            // с таблицей radioComponentsDataGridView
            radioComponentsDataGridView.DataSource = radioComponents;
        }

        private void AddRadioComponentButton_Click(
            object sender, EventArgs e)
        {
            addRadioComponentForm.ShowDialog();
        }
    }
}
