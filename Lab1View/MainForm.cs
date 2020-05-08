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

            FormatRadioComponentsDataGridView();
        }

        /// <summary>
        /// Редактирует внешний вид таблицы radioComponentsDataGridView
        /// </summary>
        private void FormatRadioComponentsDataGridView()
        {
            radioComponentsDataGridView.Columns["Type"].
                HeaderText = "Тип";
            radioComponentsDataGridView.Columns["Quantity"].
                HeaderText = "Физическая величина";
            radioComponentsDataGridView.Columns["Unit"].
                HeaderText = "Единица измерения";
            radioComponentsDataGridView.Columns["Value"].
                HeaderText = "Значение";

            radioComponentsDataGridView.Columns["Type"].DisplayIndex = 0;
            radioComponentsDataGridView.Columns["Quantity"].DisplayIndex = 1;
            radioComponentsDataGridView.Columns["Unit"].DisplayIndex = 2;
            radioComponentsDataGridView.Columns["Value"].DisplayIndex = 3;

            radioComponentsDataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AddRadioComponentButton_Click(
            object sender, EventArgs e)
        {
            addRadioComponentForm.ShowDialog();
        }

        private void DeleteRadioComponentButton_Click(
            object sender, EventArgs e)
        {
            foreach (object row in
                radioComponentsDataGridView.SelectedRows)
            {
                radioComponentsDataGridView.Rows.Remove(
                    (DataGridViewRow)row);
            }
        }
    }
}
