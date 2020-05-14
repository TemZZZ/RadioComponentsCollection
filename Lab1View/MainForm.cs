using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using System.Xml;
using Lab1Model;
using PositiveDoubleTextBoxLib;

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
            SetupFileDialogs();
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
        /// Редактирует внешний вид окон загрузки
        /// <see cref="openFileDialog"/> и сохранения
        /// <see cref="saveFileDialog"/> файлов
        /// </summary>
        private void SetupFileDialogs()
        {
            const string filesFilter =
                "Файлы радиокомпонентов (*.cmp)|*.cmp|Все файлы (*.*)|*.*";
            const string defaultExtension = "cmp";

            saveFileDialog.Filter = filesFilter;
            saveFileDialog.DefaultExt = defaultExtension;
            saveFileDialog.AddExtension = true;
            saveFileDialog.OverwritePrompt = true;

            openFileDialog.Filter = filesFilter;
            openFileDialog.FileName = string.Empty;
        }

        /// <summary>
        /// Открывает форму добавления новых радиокомпонентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRadioComponentButton_Click(
            object sender, EventArgs e)
        {
            var addRadioComponentForm = new AddRadioComponentForm();

            addRadioComponentForm.RadioComponentCreated +=
                OnRadioComponentCreated;

            addRadioComponentForm.ShowDialog();
        }

        /// <summary>
        /// Добавляет новый радиокомпонент в коллекцию
        /// <see cref="RadioComponents"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRadioComponentCreated(object sender,
            RadioComponentCreatedEventArgs e)
        {
            RadioComponents.Add(e.RadioComponent);
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

        /// <summary>
        /// Формирует и возвращает список радиокомпонентов
        /// для сохранения в файл
        /// </summary>
        /// <param name="saveOption">Опция сохранения
        /// (сохранить все или только выделенные радиокомпоненты)</param>
        /// <returns>Список радиокомпонентов
        /// <see cref="RadioComponentBase"/></returns>
        private List<RadioComponentBase> GetRadioComponentsToSave(
            RadioComponentSaveOption saveOption)
        {
            if (saveOption == RadioComponentSaveOption.SaveAll)
            {
                return RadioComponents.ToList();
            }

            var radioComponentsToSave = new List<RadioComponentBase>();
            if (saveOption == RadioComponentSaveOption.SaveSelected)
            {
                foreach (DataGridViewRow row in
                    radioComponentsDataGridView.SelectedRows)
                {
                    radioComponentsToSave.Add(RadioComponents[row.Index]);
                }
            }
            return radioComponentsToSave;
        }

        /// <summary>
        /// Открывает форму выбора файла для сохранения и сохраняет файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToFile(object sender,
            RadioComponentReadyToSaveEventArgs e)
        {
            var radioComponentsToSave = GetRadioComponentsToSave(
                e.RadioComponentSaveOption);
            if (radioComponentsToSave.Count == 0)
            {
                const string nothingToSaveText =
                    "Не выделен ни один радиокомпонент.";
                PositiveDoubleTextBox.Messager(nothingToSaveText);
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string fileName = saveFileDialog.FileName;
            var xmlWriter = new XmlReaderWriter();
            xmlWriter.SerializeAndWriteXml(radioComponentsToSave,
                fileName, PositiveDoubleTextBox.Messager);
        }

        /// <summary>
        /// Создает и открывает форму выбора
        /// параметров сохранения радиокомпонентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            if (RadioComponents.Count == 0)
            {
                const string nothingToSaveText =
                    "Список радиокомпонентов пуст.";
                PositiveDoubleTextBox.Messager(nothingToSaveText);
                return;
            }

            var setRadioComponentSaveOptionForm =
                new SetRadioComponentSaveOptionForm();

            setRadioComponentSaveOptionForm.RadioComponentReadyToSave +=
                SaveToFile;

            setRadioComponentSaveOptionForm.ShowDialog();
        }

        /// <summary>
        /// Открывает форму выбора файла для загрузки и загружает
        /// радиокомпоненты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFromFile(object sender,
            RadioComponentReadyToLoadEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string fileName = openFileDialog.FileName;
            var xmlReader = new XmlReaderWriter();
            var newRadioComponents =
                xmlReader.ReadXmlAndDeserialize<List<RadioComponentBase>>
                (fileName, PositiveDoubleTextBox.Messager);

            if (newRadioComponents is null)
                return;

            if (newRadioComponents.Count == 0)
            {
                const string emptyList = "Загруженный файл не содержит" +
                    " радиокомпонентов.";
                PositiveDoubleTextBox.Messager(emptyList);
            }

            if (e.RadioComponentLoadOption ==
                RadioComponentLoadOption.ReplaceAll)
            {
                RadioComponents.Clear();
            }

            foreach (var radioComponent in newRadioComponents)
            {
                RadioComponents.Add(radioComponent);
            }
        }

        /// <summary>
        /// Создает и открывает форму выбора
        /// параметров загрузки радиокомпонентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFromFileButton_Click(object sender, EventArgs e)
        {
            var setRadioComponentLoadOptionForm =
                new SetRadioComponentLoadOptionForm();

            setRadioComponentLoadOptionForm.RadioComponentReadyToLoad +=
                LoadFromFile;

            setRadioComponentLoadOptionForm.ShowDialog();
        }
    }
}
