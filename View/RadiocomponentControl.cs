using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace View
{
	/// <summary>
	/// Элемент отбражения информации об уже созданном радиокомпоненте или
	/// предоставляющий информацию для создания нового радиокомпонента
	/// </summary>
	public partial class RadiocomponentControl : UserControl
	{
		private bool _readOnly;

		private List<(RadioButton radioButton, RadiocomponentType type,
			string quantityUnitText)> _radioButtonInfoDictionary;

		/// <summary>
		/// Позволяет сделать элемент доступным только для чтения или
		/// узнать, доступен элемент только для чтения или нет
		/// </summary>
		public bool ReadOnly
		{
			get => _readOnly;

			set
			{
				_readOnly = value;
				valueDoubleTextBox.ReadOnly = _readOnly;

				foreach (var (radioButton, _, _)
					in _radioButtonInfoDictionary)
				{
					radioButton.Enabled = !_readOnly;
				}
			}
		}

		/// <summary>
		/// Создает и возвращает радиокомпонент на основе присутствующей в
		/// полях элемента информации
		/// </summary>
		public RadiocomponentBase Radiocomponent
		{
			get
			{
				var radiocomponentValue = valueDoubleTextBox.GetValue();

				foreach (var (radioButton, radiocomponentType, _) in
					_radioButtonInfoDictionary)
				{
					if (radioButton.Checked)
					{
						return RadiocomponentFactory.GetRadiocomponent(
							radiocomponentType, radiocomponentValue);
					}
				}

				return null;
			}

			set
			{
				if (value is null)
				{
					SetDefaultState();
					return;
				}

				valueDoubleTextBox.Text = value.Value.ToString();
				quantityUnitLabel.Text
					= string.Join(", ", value.Quantity, value.Unit);

				var radiocomponentType = RadiocomponentService
					.GetRadiocomponentType(value);

				foreach (var (radioButton, type, _)
					in _radioButtonInfoDictionary)
				{
					if (type == radiocomponentType)
					{
						radioButton.Checked = true;
						break;
					}
				}
			}
		}

		/// <summary>
		/// Инициализирует список соответствия радиокнопок типам
		/// радиокомпонентов и информации о физической величие и единицах
		/// измерения. Также назначет радиокнопкам обработчик событий
		/// CheckedChanged
		/// </summary>
		private void SetupRadioButtons()
		{
			_radioButtonInfoDictionary = new List<(RadioButton radioButton,
				RadiocomponentType type, string quantityUnitText)>
			{
				(resistorRadioButton, RadiocomponentType.Resistor,
					"Сопротивление, Ом"),
				(inductorRadioButton, RadiocomponentType.Inductor,
					"Индуктивность, Гн"),
				(capacitorRadioButton, RadiocomponentType.Capacitor,
					"Емкость, Ф")
			};

			foreach (var (radioButton, _, _) in _radioButtonInfoDictionary)
			{
				radioButton.CheckedChanged += RadioButton_CheckedChanged;
			}
		}

		/// <summary>
		/// Создает элемент отбражения информации об уже созданном
		/// радиокомпоненте или предоставляющий информацию для создания
		/// нового радиокомпонента
		/// </summary>
		public RadiocomponentControl()
		{
			InitializeComponent();
			SetupRadioButtons();
			SetDefaultState();
		}

		/// <summary>
		/// Устанавливает состояние элемента по умолчанию
		/// </summary>
		private void SetDefaultState()
		{
			const string defaultValueText = "0";

			valueDoubleTextBox.Text = defaultValueText;
			quantityUnitLabel.Text = string.Empty;

			foreach (var (radioButton, _, _) in _radioButtonInfoDictionary)
			{
				radioButton.Checked = false;
			}
		}

		/// <summary>
		/// Изменяет текст <see cref="quantityUnitLabel"/>
		/// в зависимости от выбранной радиокнопки
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RadioButton_CheckedChanged(
			object sender, EventArgs e)
		{
			if (!(sender is RadioButton selectedRadioButton))
				return;

			foreach (var (radioButton, _, quantityUnitText)
				in _radioButtonInfoDictionary)
			{
				if (radioButton == selectedRadioButton)
				{
					quantityUnitLabel.Text = quantityUnitText;
				}
			}
		}
	}
}
