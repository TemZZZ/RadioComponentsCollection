using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Model.PassiveComponents;


namespace View
{
	/// <summary>
	/// Элемент отбражения информации об уже созданном радиокомпоненте или
	/// предоставляющий информацию для создания нового радиокомпонента
	/// </summary>
	public partial class RadioComponentControl : UserControl
	{
		private bool _readOnly;
		private List<RadioButton> _radioButtons;

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

				foreach (var radioButton in _radioButtons)
				{
					radioButton.Enabled = !_readOnly;
				}
			}
		}

		/// <summary>
		/// Создает и возвращает радиокомпонент на основе присутствующей в
		/// полях элемента информации
		/// </summary>
		public RadioComponentBase RadioComponent
		{
			get
			{
				var radioComponentValue = valueDoubleTextBox.GetValue();

				if (resistorRadioButton.Checked)
				{
					return new Resistor(radioComponentValue);
				}
				else if (inductorRadioButton.Checked)
				{
					return new Inductor(radioComponentValue);
				}
				else if (capacitorRadioButton.Checked)
				{
					return new Capacitor(radioComponentValue);
				}
				else
				{
					return null;
				}
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

				var typeToRadioButtonMap
					= new List<(Type type, RadioButton radioButton)>
					{
						(typeof(Resistor), resistorRadioButton),
						(typeof(Inductor), inductorRadioButton),
						(typeof(Capacitor), capacitorRadioButton),
					};

				foreach (var (type, radioButton) in typeToRadioButtonMap)
				{
					if (value.GetType() == type)
					{
						radioButton.Checked = true;
						break;
					}
				}
			}
		}

		/// <summary>
		/// Создает элемент отбражения информации об уже созданном
		/// радиокомпоненте или предоставляющий информацию для создания
		/// нового радиокомпонента
		/// </summary>
		public RadioComponentControl()
		{
			InitializeComponent();

			_radioButtons = new List<RadioButton>
			{
				resistorRadioButton,
				inductorRadioButton,
				capacitorRadioButton
			};

			foreach (var radioButton in _radioButtons)
			{
				radioButton.CheckedChanged += RadioButton_CheckedChanged;
			}

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

			foreach (var radioButton in _radioButtons)
			{
				radioButton.Checked = false;
			}
		}

		/// <summary>
		/// Изменяет текст <see cref="quantityUnitLabel"/>
		/// в зависимости от выбранной радиокнопки:
		/// <see cref="resistorRadioButton"/>
		/// <see cref="inductorRadioButton"/> или
		/// <see cref="capacitorRadioButton"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RadioButton_CheckedChanged(
			object sender, EventArgs e)
		{
			if (!(sender is RadioButton selectedRadioButton))
				return;

			var radioButtonToQuantityUnitTextMap
				= new List<(RadioButton radioButton, string quantityUnitText)>
				{
					(resistorRadioButton, "Сопротивление, Ом"),
					(inductorRadioButton, "Индуктивность, Гн"),
					(capacitorRadioButton, "Емкость, Ф"),
				};

			foreach (var (radioButton, quantityUnitText)
				in radioButtonToQuantityUnitTextMap)
			{
				if (selectedRadioButton == radioButton)
				{
					quantityUnitLabel.Text = quantityUnitText;
					break;
				}
			}
		}
	}
}
