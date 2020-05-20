using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Lab1Model;


namespace Lab1View
{
	/// <summary>
	/// Класс формы поиска радиокомпонентов
	/// </summary>
	public partial class SearchRadioComponentForm : Form
	{
		/// <summary>
		/// Событие, происходящее после завершения поиска
		/// </summary>
		public event EventHandler<SearchFinishedEventArgs> SearchFinished;

		/// <summary>
		/// Список радиокомпонентов, по которым осуществляется поиск
		/// </summary>
		private SortableBindingList<RadioComponentBase>
			RadioComponents { get; }

		const string allTypesText = "<Все>";
		const string resistorTypeText = "Резистор";
		const string inductorTypeText = "Катушка индуктивности";
		const string capacitorTypeText = "Конденсатор";

		/// <summary>
		/// Создает форму поиска радиокомпонентов
		/// </summary>
		public SearchRadioComponentForm(
			SortableBindingList<RadioComponentBase> radioComponents)
		{
			RadioComponents = radioComponents;

			InitializeComponent();

			// Заполняет radioComponentTypeComboBox типами радиокомпонентов
			radioComponentTypeComboBox.DataSource =
				GetRadioComponentTypeComboBoxItems();

			SetupOnSearchOptionsChanged();

			RadioComponents.ListChanged += OnRadioComponentsChanged;
		}

		/// <summary>
		/// Возвращает названия типов радиокомпонентов для заполнения
		/// <see cref="radioComponentTypeComboBox"/>
		/// </summary>
		/// <returns>Массив строк</returns>
		private string[] GetRadioComponentTypeComboBoxItems()
		{
			string[] radioComponentTypeComboBoxItems =
			{
				allTypesText,
				resistorTypeText,
				inductorTypeText,
				capacitorTypeText
			};

			return radioComponentTypeComboBoxItems;
		}

		/// <summary>
		/// Добавляет обработчик <see cref="OnSearchOptionsChanged"/>
		/// к событиям изменения состояния элементов в форме поиска
		/// </summary>
		private void SetupOnSearchOptionsChanged()
		{
			Control[] controlsWithTextChangedEvent =
			{
				radioComponentTypeComboBox,
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
		/// <see cref="searchRadioComponentsButton"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSearchOptionsChanged(object sender, EventArgs e)
		{
			const string searchOptionsChangedText
				= "Параметры поиска изменены. Нажмите \"Найти\"";

			searchStatusLabel.Text = searchOptionsChangedText;
			searchRadioComponentsButton.Enabled = true;
		}

		/// <summary>
		/// Производит поиск радиокомпонентов в соответствие с
		/// фильтрами поиска, сообщает пользователю в
		/// <see cref="searchStatusLabel"/> статус поиска,
		/// деактивирует кнопку
		/// <see cref="searchRadioComponentsButton"/> и
		/// передает индексы найденных радиокомпонентов через
		/// событие <see cref="SearchFinished"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SearchRadioComponentsButton_Click(
			object sender, EventArgs e)
		{
			const string searchFinishedText = "Поиск завершен.\n";

			int[] foundIndices = GetFilteredRadioComponentsIndices();
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

			searchRadioComponentsButton.Enabled = false;

			SearchFinished?.Invoke(this,
				new SearchFinishedEventArgs(foundIndices));
		}

		/// <summary>
		/// При изменениях в списке радиокомпонентов
		/// <see cref="RadioComponents"/> сообщает пользователю в
		/// <see cref="searchStatusLabel"/> об изменениях и
		/// активирует кнопку <see cref="searchRadioComponentsButton"/>
		/// для возобновления поиска, если список не пуст
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnRadioComponentsChanged(
			object sender, ListChangedEventArgs e)
		{
			if (RadioComponents.Count == 0)
			{
				const string noRadioComponents =
					"Список радиокомпонентов пуст.\n" +
					"Поиск невозможен.";
				searchStatusLabel.Text = noRadioComponents;
				searchRadioComponentsButton.Enabled = false;
				return;
			}

			const string radioComponentsChangedText =
				"Список радиокомпонентов изменился.\n" +
				"Можно возобновить поиск.";
			searchStatusLabel.Text = radioComponentsChangedText;
			searchRadioComponentsButton.Enabled = true;
		}

		/// <summary>
		/// Возвращает индексы радиокомпонентов из списка
		/// <see cref="RadioComponents"/>, удовлетворяющих
		/// условиям поиска
		/// </summary>
		/// <returns>Массив целых чисел</returns>
		private int[] GetFilteredRadioComponentsIndices()
		{
			// Создает перечислитель "индекс-радиокомпонент"
			IEnumerable <KeyValuePair<int, RadioComponentBase>>
				byTypeIndexToRadioComponentMap = RadioComponents
				.ToDictionary(
					radioComponent
					=> RadioComponents.IndexOf(radioComponent),
					radioComponent => radioComponent);

			// Фильтр по типу радиокомпонентов
			string radioComponentType = radioComponentTypeComboBox.Text;
			if (radioComponentType != allTypesText)
			{
				byTypeIndexToRadioComponentMap
				= byTypeIndexToRadioComponentMap
					.GetFilteredByTypeIndexToRadioComponentMap(
						radioComponentType);
			}

			if ((lessThanCheckBox.Checked == false)
				&& (moreThanCheckBox.Checked == false)
				&& (equalCheckBox.Checked == false))
			{
				return byTypeIndexToRadioComponentMap
					.Select(indexedRadioComponent
							=> indexedRadioComponent.Key)
					.ToArray();
			}

			// Фильтр меньше, чем
			var lessThanIndexToRadioComponentMap
				= byTypeIndexToRadioComponentMap
					.GetFilteredByValueIndexToRadioComponentMap(
						lessThanCheckBox.Checked, WhereExtension.LessThan,
						lessThanPositiveDoubleTextBox.GetValue());

			// Фильтр больше, чем
			var moreThanIndexToRadioComponentMap
				= byTypeIndexToRadioComponentMap
					.GetFilteredByValueIndexToRadioComponentMap(
						moreThanCheckBox.Checked, WhereExtension.MoreThan,
						moreThanPositiveDoubleTextBox.GetValue());

			// Фильтр равно
			var equalIndexToRadioComponentMap
				= byTypeIndexToRadioComponentMap
					.GetFilteredByValueIndexToRadioComponentMap(
						equalCheckBox.Checked, WhereExtension.Equal,
						equalPositiveDoubleTextBox.GetValue());

			var filteredIndexToRadioComponentMap =
				lessThanIndexToRadioComponentMap.Intersect(
					moreThanIndexToRadioComponentMap);

			if (!filteredIndexToRadioComponentMap.Any())
			{
				filteredIndexToRadioComponentMap =
					lessThanIndexToRadioComponentMap.Union(
						moreThanIndexToRadioComponentMap);
			}

			filteredIndexToRadioComponentMap =
				filteredIndexToRadioComponentMap.Union(
					equalIndexToRadioComponentMap);

			return filteredIndexToRadioComponentMap.Select(
				indexedRadioComponent => indexedRadioComponent.Key)
				.ToArray();
		}
	}
}
