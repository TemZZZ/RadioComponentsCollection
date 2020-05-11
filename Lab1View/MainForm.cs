using System;
using System.Numerics;
using System.Windows.Forms;
using Lab1Model;


namespace Lab1View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список радиокомпонентов
        /// </summary>
        internal static
            SortableBindingList<RadioComponentBase> radioComponents;
        /// <summary>
        /// Форма добавления новых радиокомпонентов
        /// </summary>
        private readonly AddRadioComponentForm addRadioComponentForm;

        public MainForm()
        {
            InitializeComponent();

            addRadioComponentForm = new AddRadioComponentForm();
            radioComponents = new SortableBindingList<RadioComponentBase>();

            /// <summary>
            /// Инструкция связывает источник данных
            /// <see cref="radioComponents"/>
            /// с таблицей <see cref="radioComponentsDataGridView"/>
            /// </summary>
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

        /// <summary>
        /// Открывает форму
        /// <see cref="addRadioComponentForm"/>
        /// для добавления новых радиокомпонентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRadioComponentButton_Click(
            object sender, EventArgs e)
        {
            addRadioComponentForm.ShowDialog();
        }

        /// <summary>
        /// Удаляет выбранные в
        /// <see cref="radioComponentsDataGridView"/>
        /// радиокомпоненты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteRadioComponentButton_Click(
            object sender, EventArgs e)
        {
            foreach (object row in
                radioComponentsDataGridView.SelectedRows)
            {
                radioComponentsDataGridView.Rows.Remove(
                    (DataGridViewRow)row);
            }

            /// <summary>
            /// Если удалить строку, кроме последней, или несколько строк,
            /// не включая последнюю, и при этом в таблице еще есть элементы,
            /// то останется одна выделенная строка. Следующая инструкция
            /// для этой строки вызывает
            /// <see cref="RadioComponentsDataGridView_RowEnter"/>
            /// </summary>
            if (radioComponentsDataGridView.SelectedRows.Count > 0)
            {
                int selectedRowIndex =
                    radioComponentsDataGridView.SelectedRows[0].Index;
                RadioComponentsDataGridView_RowEnter(
                    sender, new DataGridViewCellEventArgs(0,
                    selectedRowIndex));

                return;
            }

            /// <summary>
            /// При удалении последней строки таблицы не остается ни одной
            /// выделенной строки. Если в коллекции
            /// <see cref="radioComponents"/> еще есть елементы, то
            /// следующая инструкция выделяет последнюю строку таблицы
            /// и вызывает для нее
            /// <see cref="RadioComponentsDataGridView_RowEnter"/>
            /// </summary>
            if ((radioComponentsDataGridView.SelectedRows.Count == 0)
                && (radioComponents.Count > 0))
            {
                radioComponentsDataGridView.
                    Rows[radioComponents.Count - 1].Selected = true;
                RadioComponentsDataGridView_RowEnter(
                    sender, new DataGridViewCellEventArgs(0,
                    radioComponents.Count - 1));
            }
        }

        /// <summary>
        /// При выборе строки считается импеданс компонента и
        /// его значение вносится в <see cref="impedanceTextBox"/>.
        /// Если выбрано несколько строк - очищает
        /// <see cref="impedanceTextBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioComponentsDataGridView_RowEnter(
            object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowsCount =
                radioComponentsDataGridView.SelectedRows.Count;

            if ((selectedRowsCount == 0) || (selectedRowsCount > 1))
            {
                impedanceTextBox.Clear();
                return;
            }

            int index = radioComponentsDataGridView.SelectedRows[0].Index;
            if (index >= radioComponents.Count)
            {
                impedanceTextBox.Clear();
                return;
            }

            double frequency = frequencyPositiveDoubleTextBox.GetValue();
            impedanceTextBox.Text = ComplexToText(
                radioComponents[index].GetImpedance(frequency));
        }

        /// <summary>
        /// Возвращает строковое представление комплексного числа
        /// в алгебраической форме
        /// </summary>
        /// <param name="number">Комплексное число</param>
        public static string ComplexToText(Complex number)
        {
            const char signPlus = '+';
            const char signMinus = '-';
            const string infinityString = "INF";
            const string format = "G5";

            string realString = number.Real.ToString(format);
            string absImaginaryString =
                Math.Abs(number.Imaginary).ToString(format);

            if (double.IsInfinity(number.Real))
                { realString = infinityString; }
            if (double.IsInfinity(number.Imaginary))
                { absImaginaryString = infinityString; }

            char sign = signPlus;
            if (number.Imaginary < 0) { sign = signMinus; }

            return $"{realString} {sign} {absImaginaryString}j";
        }

        /// <summary>
        /// После ввода нового значения частоты в
        /// <see cref="frequencyPositiveDoubleTextBox"/>
        /// обновляет <see cref="radioComponentsDataGridView"/>
        /// и импеданс для выбранного компонента пересчитается
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrequencyPositiveDoubleTextBox_LostFocus(
            object sender, EventArgs e)
        {
            radioComponentsDataGridView.Update();
        }

        /// <summary>
        /// Делает самую первую добавленную строку в
        /// <see cref="radioComponentsDataGridView"/>
        /// выделенной
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioComponentsDataGridView_RowsAdded(
            object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (radioComponentsDataGridView.Rows.Count == 1)
            { radioComponentsDataGridView.Rows[0].Selected = true; }
        }

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadFromFileButton_Click(object sender, EventArgs e)
        {

        }
    }
}
