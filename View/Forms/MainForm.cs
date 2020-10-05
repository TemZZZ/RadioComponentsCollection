using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

using Model;
using RegexControlsSDK;

namespace View
{
	/// <summary>
	/// Главная форма программы. Также является стартовой формой программы
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Делегат для вывода сообщений об ошибках и предупреждений
		/// </summary>
		internal Action<string> ErrorMessager =
			PositiveDoubleTextBox.Messager;

		/// <summary>
		/// Позволяет получить список радиокомпонентов
		/// </summary>
		private SortableBindingList<RadiocomponentBase> Radiocomponents { get; }
			= new SortableBindingList<RadiocomponentBase>();

		/// <summary>
		/// Создает форму <see cref="MainForm"/>
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			radiocomponentsDataGridView.DataSource = Radiocomponents;

			frequencyPositiveDoubleTextBox.LostFocus +=
				RadiocomponentsDataGridView_SelectionChanged;

			SetupRadiocomponentsDataGridView();
			SetupFileDialogs();
		}

		/// <summary>
		/// Редактирует внешний вид таблицы
		/// <see cref="radiocomponentsDataGridView"/>
		/// </summary>
		private void SetupRadiocomponentsDataGridView()
		{
			var columnNameToHeaderTextMap
				= new List<(string columnName, string headerText)>
			{
				("Type", "Тип"),
				("Quantity", "Физическая величина"),
				("Unit", "Единица измерения"),
				("Value", "Значение")
			};

			for (int i = 0; i < columnNameToHeaderTextMap.Count; ++i)
			{
				var (columnName, headerText) = columnNameToHeaderTextMap[i];
				radiocomponentsDataGridView.Columns[columnName]
					.HeaderText = headerText;
				radiocomponentsDataGridView.Columns[columnName]
					.DisplayIndex = i;
			}

			radiocomponentsDataGridView.AutoSizeColumnsMode =
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
		private void AddRadiocomponentButton_Click(
			object sender, EventArgs e)
		{
			var addRadiocomponentForm = new AddRadiocomponentForm();

			addRadiocomponentForm.RadiocomponentCreated +=
				OnRadiocomponentCreated;

			addRadiocomponentForm.ShowDialog();
		}

		/// <summary>
		/// Добавляет новый радиокомпонент в коллекцию
		/// <see cref="Radiocomponents"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRadiocomponentCreated(object sender,
			RadiocomponentCreatedEventArgs e)
		{
			Radiocomponents.Add(e.Radiocomponent);
		}

		/// <summary>
		/// Удаляет выбранные в
		/// <see cref="radiocomponentsDataGridView"/>
		/// радиокомпоненты
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteRadiocomponentButton_Click(
			object sender, EventArgs e)
		{
			foreach (object row in
				radiocomponentsDataGridView.SelectedRows)
			{
				radiocomponentsDataGridView.Rows.Remove(
					(DataGridViewRow)row);
			}
		}

		/// <summary>
		/// Возвращает строковое представление комплексного числа
		/// в алгебраической форме
		/// </summary>
		/// <param name="number">Комплексное число</param>
		/// <returns>Строковое представление комплексного числа
		/// </returns>
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
		/// Делает самую первую добавленную строку в
		/// <see cref="radiocomponentsDataGridView"/>
		/// выделенной
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RadiocomponentsDataGridView_RowsAdded(
			object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (radiocomponentsDataGridView.Rows.Count == 1)
			{
				radiocomponentsDataGridView.Rows[0].Selected = true;
			}
		}

		/// <summary>
		/// Формирует и возвращает список радиокомпонентов
		/// для сохранения в файл
		/// </summary>
		/// <param name="saveOption">Опция сохранения
		/// (сохранить все или только выделенные радиокомпоненты)</param>
		/// <returns>Список радиокомпонентов
		/// <see cref="RadiocomponentBase"/></returns>
		private List<RadiocomponentBase> GetRadiocomponentsToSave(
			RadiocomponentsSaveOption saveOption)
		{
			if (saveOption == RadiocomponentsSaveOption.SaveAll)
			{
				return Radiocomponents.ToList();
			}

			var radiocomponentsToSave = new List<RadiocomponentBase>();
			if (saveOption == RadiocomponentsSaveOption.SaveSelected)
			{
				foreach (DataGridViewRow row in
					radiocomponentsDataGridView.SelectedRows)
				{
					radiocomponentsToSave.Add(Radiocomponents[row.Index]);
				}
			}
			return radiocomponentsToSave;
		}

		/// <summary>
		/// Открывает форму выбора файла для сохранения и сохраняет файл
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveToFile(object sender,
			RadiocomponentsReadyToSaveEventArgs e)
		{
			var radiocomponentsToSave = GetRadiocomponentsToSave(
				e.RadiocomponentsSaveOption);
			if (radiocomponentsToSave.Count == 0)
			{
				const string nothingToSaveText =
					"Не выделен ни один радиокомпонент.";
				ErrorMessager(nothingToSaveText);
				return;
			}

			if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			string fileName = saveFileDialog.FileName;
			var xmlWriter = new XmlReaderWriter();
			xmlWriter.SerializeAndWriteToFile(radiocomponentsToSave,
				fileName, ErrorMessager);
		}

		/// <summary>
		/// Создает и открывает форму выбора
		/// параметров сохранения радиокомпонентов
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveToFileButton_Click(object sender, EventArgs e)
		{
			if (Radiocomponents.Count == 0)
			{
				const string nothingToSaveText =
					"Список радиокомпонентов пуст.";
				ErrorMessager(nothingToSaveText);
				return;
			}

			var setRadiocomponentSaveOptionForm =
				new SetRadiocomponentSaveOptionForm();

			setRadiocomponentSaveOptionForm.RadiocomponentReadyToSave +=
				SaveToFile;

			setRadiocomponentSaveOptionForm.ShowDialog();
		}

		/// <summary>
		/// Открывает форму выбора файла для загрузки и загружает
		/// радиокомпоненты
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoadFromFile(object sender,
			RadiocomponentsReadyToLoadEventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			string fileName = openFileDialog.FileName;
			var xmlReader = new XmlReaderWriter();
			var newRadiocomponents =
				xmlReader.ReadFileAndDeserialize<List<RadiocomponentBase>>
				(fileName, ErrorMessager);

			if (newRadiocomponents is null)
				return;

			if (newRadiocomponents.Count == 0)
			{
				const string emptyList = "Загруженный файл не содержит" +
					" радиокомпонентов.";
				ErrorMessager(emptyList);
			}

			if (e.RadiocomponentsLoadOption ==
				RadiocomponentsLoadOption.ReplaceAll)
			{
				Radiocomponents.Clear();
			}

			foreach (var radiocomponent in newRadiocomponents)
			{
				Radiocomponents.Add(radiocomponent);
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
			var setRadiocomponentLoadOptionForm =
				new SetRadiocomponentLoadOptionForm();

			setRadiocomponentLoadOptionForm.RadiocomponentReadyToLoad +=
				LoadFromFile;

			setRadiocomponentLoadOptionForm.ShowDialog();
		}

		/// <summary>
		/// После смены выделенной строки пересчитывает импеданс
		/// радиокомпонента, зависящий от частоты в поле
		/// <see cref="frequencyPositiveDoubleTextBox"/>, и
		/// вносит его значение в поле <see cref="impedanceTextBox"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RadiocomponentsDataGridView_SelectionChanged(
			object sender, EventArgs e)
		{
			int selectedRowsCount =
				radiocomponentsDataGridView.SelectedRows.Count;
			if ((selectedRowsCount == 0) || (selectedRowsCount > 1))
			{
				impedanceTextBox.Clear();
				_modifyRadiocomponentControl.Radiocomponent = null;
				return;
			}

			int index = radiocomponentsDataGridView.SelectedRows[0].Index;
			double frequency = frequencyPositiveDoubleTextBox.GetValue();
			impedanceTextBox.Text = ComplexToText(
				Radiocomponents[index].GetImpedance(frequency));

			_modifyRadiocomponentControl.Radiocomponent
				= Radiocomponents[index];
		}

		/// <summary>
		/// Открывает форму поиска радиокомпонентов,
		/// если список радиокомпонентов не пустой,
		/// и деактивирует кнопку <see cref="searchButton"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SearchButton_Click(object sender, EventArgs e)
		{
			const string radiocomponentsEmty =
				"Список радиокомпонентов пуст.\nНечего искать.";

			if (Radiocomponents.Count == 0)
			{
				ErrorMessager(radiocomponentsEmty);
				return;
			}

			var searchRadiocomponentForm =
				new SearchRadiocomponentForm(Radiocomponents);
			searchRadiocomponentForm.Show();
			searchRadiocomponentForm.Location = this.Location;

			searchButton.Enabled = false;
			searchRadiocomponentForm.FormClosed +=
				(_sender, _e) => searchButton.Enabled = true;
			searchRadiocomponentForm.SearchFinished += OnSearchFinished;
		}

		/// <summary>
		/// Выделяет найденные радиокомпоненты в
		/// <see cref="radiocomponentsDataGridView"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSearchFinished(
			object sender, SearchFinishedEventArgs e)
		{
			radiocomponentsDataGridView.ClearSelection();

			if (e.FoundIndices.Length == 0)
				return;

			foreach (var index in e.FoundIndices)
			{
				radiocomponentsDataGridView.Rows[index].Selected = true;
			}
		}

		/// <summary>
		/// Изменяет выделенный радиокомпонент
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ModifyButton_Click(object sender, EventArgs e)
		{
			int selectedRowsCount =
				radiocomponentsDataGridView.SelectedRows.Count;
			if (selectedRowsCount != 1)
				return;

			if (_modifyRadiocomponentControl.Radiocomponent is null)
				return;

			int index = radiocomponentsDataGridView.SelectedRows[0].Index;
			Radiocomponents[index]
				= _modifyRadiocomponentControl.Radiocomponent;
		}
	}
}
