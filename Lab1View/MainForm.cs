using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using Lab1Model;


namespace Lab1View
{
    /// <summary>
    /// Главная форма программы. Также является стартовой формой программы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список радиокомпонентов
        /// </summary>
        internal SortableBindingList<RadioComponentBase> RadioComponents =
            new SortableBindingList<RadioComponentBase>();

        /// <summary>
        /// Создает форму <see cref="MainForm"/>
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            radioComponentsDataGridView.DataSource = RadioComponents;

            SetupRadioComponentsDataGridView();
        }

        /// <summary>
        /// Пара значений "имя столбца-заголовок столбца".
        /// Используется для редактирования внешнего вида
        /// <see cref="DataGridView"/>
        /// </summary>
        private struct NameHeaderTextPair
        {
            /// <summary>
            /// Создает пару значений "имя столбца-заголовок столбца"
            /// </summary>
            /// <param name="name">Имя столбца</param>
            /// <param name="headerText">Заголовок столбца</param>
            public NameHeaderTextPair(string name, string headerText)
            {
                Name = name;
                HeaderText = headerText;
            }
            /// <summary>
            /// Имя стобца таблицы <see cref="DataGridView"/>
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Заголовок стобца таблицы <see cref="DataGridView"/>
            /// </summary>
            public string HeaderText { get; set; }
        }

        /// <summary>
        /// Редактирует внешний вид таблицы
        /// <see cref="radioComponentsDataGridView"/>
        /// </summary>
        private void SetupRadioComponentsDataGridView()
        {
            var properties = new List<NameHeaderTextPair>
            {
                new NameHeaderTextPair("Type", "Тип"),
                new NameHeaderTextPair("Quantity", "Физическая величина"),
                new NameHeaderTextPair("Unit", "Единица измерения"),
                new NameHeaderTextPair("Value", "Значение")
            };

            for (int i = 0; i < properties.Count; ++i)
            {
                radioComponentsDataGridView.Columns[properties[i].Name].
                    HeaderText = properties[i].HeaderText;
                radioComponentsDataGridView.Columns[properties[i].Name].
                    DisplayIndex = i;
            }

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
            var addRadioComponentForm = new AddRadioComponentForm();
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

            // Если удалить строку таблицы radioComponentsDataGridView,
            // кроме последней, или несколько строк, не включая последнюю,
            // и при этом в таблице еще есть элементы, то останется
            // одна выделенная строка. Следующая инструкция для этой строки
            // вызывает метод RadioComponentsDataGridView_RowEnter
            if (radioComponentsDataGridView.SelectedRows.Count > 0)
            {
                int selectedRowIndex =
                    radioComponentsDataGridView.SelectedRows[0].Index;
                RadioComponentsDataGridView_RowEnter(
                    sender, new DataGridViewCellEventArgs(0,
                    selectedRowIndex));

                return;
            }

            // При удалении последней строки таблицы не остается ни одной
            // выделенной строки. Если в коллекции radioComponents 
            // еще есть объекты, то следующая инструкция выделяет
            // последнюю строку таблицы и вызывает для нее метод
            // RadioComponentsDataGridView_RowEnter
            if ((radioComponentsDataGridView.SelectedRows.Count == 0)
                && (RadioComponents.Count > 0))
            {
                radioComponentsDataGridView.
                    Rows[RadioComponents.Count - 1].Selected = true;
                RadioComponentsDataGridView_RowEnter(
                    sender, new DataGridViewCellEventArgs(0,
                    RadioComponents.Count - 1));
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
            if (index >= RadioComponents.Count)
            {
                impedanceTextBox.Clear();
                return;
            }

            double frequency = frequencyPositiveDoubleTextBox.GetValue();
            impedanceTextBox.Text = ComplexToText(
                RadioComponents[index].GetImpedance(frequency));
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
            {
                realString = infinityString;
            }
            if (double.IsInfinity(number.Imaginary))
            {
                absImaginaryString = infinityString;
            }

            char sign = signPlus;
            if (number.Imaginary < 0)
            {
                sign = signMinus;
            }

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
            {
                radioComponentsDataGridView.Rows[0].Selected = true;
            }
        }

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadFromFileButton_Click(object sender, EventArgs e)
        {

        }
    }
}
