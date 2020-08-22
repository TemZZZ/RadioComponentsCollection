using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Model;


namespace View
{
	/// <summary>
	/// Класс формы поиска радиокомпонентов
	/// </summary>
	public partial class SearchRadiocomponentForm : Form
	{
		/// <summary>
		/// Событие, происходящее после завершения поиска
		/// </summary>
		public event EventHandler<SearchFinishedEventArgs> SearchFinished;

		/// <summary>
		/// Список радиокомпонентов, по которым осуществляется поиск
		/// </summary>
		private SortableBindingList<RadiocomponentBase> Radiocomponents { get; }

		private const string allTypesText = "<Все>";
		private const string resistorTypeText = "Резистор";
		private const string inductorTypeText = "Катушка индуктивности";
		private const string capacitorTypeText = "Конденсатор";

		/// <summary>
		/// Создает форму поиска радиокомпонентов
		/// </summary>
		public SearchRadiocomponentForm(
			SortableBindingList<RadiocomponentBase> radiocomponents)
		{
			Radiocomponents = radiocomponents;

			InitializeComponent();

			// Заполняет radiocomponentTypeComboBox типами радиокомпонентов
			radiocomponentTypeComboBox.DataSource =
				GetRadiocomponentTypeComboBoxItems();

			SetupOnSearchOptionsChanged();

			Radiocomponents.ListChanged += OnRadiocomponentsChanged;
		}

		/// <summary>
		/// Возвращает названия типов радиокомпонентов
		/// </summary>
		/// <returns>Массив строк</returns>
		private string[] GetRadiocomponentTypeComboBoxItems()
		{
			string[] radiocomponentTypeComboBoxItems =
			{
				allTypesText,
				resistorTypeText,
				inductorTypeText,
				capacitorTypeText
			};

			return radiocomponentTypeComboBoxItems;
		}

		/// <summary>
		/// Добавляет обработчик <see cref="OnSearchOptionsChanged"/>
		/// к событиям изменения состояния элементов в форме поиска
		/// </summary>
		private void SetupOnSearchOptionsChanged()
		{
			Control[] controlsWithTextChangedEvent =
			{
				radiocomponentTypeComboBox,
				lessThanPositiveDoubleTextBox,
				moreThanPositiveDoubleTextBox,
				equalPositiveDoubleTextBox
			};

			CheckBox[] checkBoxes =
			{
				lessThanCheckBox,
				moreThanCheckBox,
				equalCheckBox
			};

			foreach (var control in controlsWithTextChangedEvent)
			{
				control.TextChanged += OnSearchOptionsChanged;
			}

			foreach (var checkBox in checkBoxes)
			{
				checkBox.CheckedChanged += OnSearchOptionsChanged;
			}
		}

		/// <summary>
		/// Закрывает форму
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Сообщает пользователю в <see cref="searchStatusLabel"/>
		/// о том, что фильтр поиска был изменен и активирует кнопку
		/// <see cref="searchRadiocomponentsButton"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSearchOptionsChanged(object sender, EventArgs e)
		{
			const string searchOptionsChangedText
				= "Параметры поиска изменены. Нажмите \"Найти\"";

			searchStatusLabel.Text = searchOptionsChangedText;
			searchRadiocomponentsButton.Enabled = true;
		}

		/// <summary>
		/// Производит поиск радиокомпонентов в соответствие с
		/// фильтрами поиска, сообщает пользователю в
		/// <see cref="searchStatusLabel"/> статус поиска,
		/// деактивирует кнопку
		/// <see cref="searchRadiocomponentsButton"/> и
		/// передает индексы найденных радиокомпонентов через
		/// событие <see cref="SearchFinished"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SearchRadiocomponentsButton_Click(
			object sender, EventArgs e)
		{
			const string searchFinishedText = "Поиск завершен.\n";

			int[] foundIndices = GetFilteredRadiocomponentsIndices();
			string searchStatusText = searchFinishedText;

			if (foundIndices.Length == 0)
			{
				const string notFoundText = "Ничего не найдено.\n";
				searchStatusText += notFoundText;
			}
			else
			{
				const string foundText =
					"Найденные радиокомпоненты подсвечены.\n";
				searchStatusText += foundText;
			}

			const string changeSearchParametersText =
				"Измените параметры для нового поиска.";
			searchStatusText += changeSearchParametersText;
			searchStatusLabel.Text = searchStatusText;

			searchRadiocomponentsButton.Enabled = false;

			SearchFinished?.Invoke(this,
				new SearchFinishedEventArgs(foundIndices));
		}

		/// <summary>
		/// При изменениях в списке радиокомпонентов
		/// <see cref="Radiocomponents"/> сообщает пользователю в
		/// <see cref="searchStatusLabel"/> об изменениях и
		/// активирует кнопку <see cref="searchRadiocomponentsButton"/>
		/// для возобновления поиска, если список не пуст
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnRadiocomponentsChanged(
			object sender, ListChangedEventArgs e)
		{
			if (Radiocomponents.Count == 0)
			{
				const string noRadiocomponents =
					"Список радиокомпонентов пуст.\n" +
					"Поиск невозможен.";
				searchStatusLabel.Text = noRadiocomponents;
				searchRadiocomponentsButton.Enabled = false;
				return;
			}

			const string radiocomponentsChangedText =
				"Список радиокомпонентов изменился.\n" +
				"Можно возобновить поиск.";
			searchStatusLabel.Text = radiocomponentsChangedText;
			searchRadiocomponentsButton.Enabled = true;
		}

		/// <summary>
		/// Возвращает индексы радиокомпонентов из списка
		/// <see cref="Radiocomponents"/>, удовлетворяющих
		/// условиям поиска
		/// </summary>
		/// <returns>Массив целых чисел</returns>
		private int[] GetFilteredRadiocomponentsIndices()
		{
			// Создает перечислитель "индекс-радиокомпонент"
			var byTypeIndexToRadiocomponentMap
				= Radiocomponents.ToIndexToRadiocomponentMap();

			// Фильтр по типу радиокомпонентов
			string radiocomponentType = radiocomponentTypeComboBox.Text;
			if (radiocomponentType != allTypesText)
			{
				byTypeIndexToRadiocomponentMap
				= byTypeIndexToRadiocomponentMap
					.GetFilteredByTypeIndexToRadiocomponentMap(
						radiocomponentType.ToRadiocomponentType());
			}

			if ((lessThanCheckBox.Checked == false)
				&& (moreThanCheckBox.Checked == false)
				&& (equalCheckBox.Checked == false))
			{
				return byTypeIndexToRadiocomponentMap.GetIndices();
			}

			// Фильтр меньше, чем
			var lessThanIndexToRadiocomponentMap
				= byTypeIndexToRadiocomponentMap
					.GetFilteredByValueIndexToRadiocomponentMap(
						lessThanCheckBox.Checked, WhereExtension.LessThan,
						lessThanPositiveDoubleTextBox.GetValue());

			// Фильтр больше, чем
			var moreThanIndexToRadiocomponentMap
				= byTypeIndexToRadiocomponentMap
					.GetFilteredByValueIndexToRadiocomponentMap(
						moreThanCheckBox.Checked, WhereExtension.MoreThan,
						moreThanPositiveDoubleTextBox.GetValue());

			// Фильтр равно
			var equalIndexToRadiocomponentMap
				= byTypeIndexToRadiocomponentMap
					.GetFilteredByValueIndexToRadiocomponentMap(
						equalCheckBox.Checked, WhereExtension.Equal,
						equalPositiveDoubleTextBox.GetValue());

			var filteredIndexToRadiocomponentMap =
				lessThanIndexToRadiocomponentMap.Intersect(
					moreThanIndexToRadiocomponentMap);

			if (!filteredIndexToRadiocomponentMap.Any())
			{
				filteredIndexToRadiocomponentMap =
					lessThanIndexToRadiocomponentMap.Union(
						moreThanIndexToRadiocomponentMap);
			}

			filteredIndexToRadiocomponentMap =
				filteredIndexToRadiocomponentMap.Union(
					equalIndexToRadiocomponentMap);

			return filteredIndexToRadiocomponentMap.GetIndices();
		}
	}
}
