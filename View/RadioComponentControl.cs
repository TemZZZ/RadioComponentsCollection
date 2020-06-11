using System;
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

				resistorRadioButton.Enabled = !_readOnly;
				inductorRadioButton.Enabled = !_readOnly;
				capacitorRadioButton.Enabled = !_readOnly;

				valueDoubleTextBox.ReadOnly = _readOnly;
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
				if ((value is null) || !(value is RadioComponentBase))
				{
					SetDefaultState();
					return;
				}

				valueDoubleTextBox.Text = value.Value.ToString();
				
				quantityUnitLabel.Text
					= string.Join(", ", value.Quantity, value.Unit);

				if (value.GetType() == typeof(Resistor))
				{
					resistorRadioButton.Checked = true;
				}
				else if (value.GetType() == typeof(Inductor))
				{
					inductorRadioButton.Checked = true;
				}
				else if (value.GetType() == typeof(Capacitor))
				{
					capacitorRadioButton.Checked = true;
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
			SetDefaultState();

			resistorRadioButton.CheckedChanged +=
				RadioButton_CheckedChanged;
			inductorRadioButton.CheckedChanged +=
				RadioButton_CheckedChanged;
			capacitorRadioButton.CheckedChanged +=
				RadioButton_CheckedChanged;
		}

		/// <summary>
		/// Устанавливает состояние элемента по умолчанию
		/// </summary>
		private void SetDefaultState()
		{
			const string defaultValueText = "0";
			valueDoubleTextBox.Text = defaultValueText;
			quantityUnitLabel.Text = string.Empty;

			resistorRadioButton.Checked = false;
			inductorRadioButton.Checked = false;
			capacitorRadioButton.Checked = false;
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

			const string resistorQuantityUnitText = "Сопротивление, Ом";
			const string inductorQuantityUnitText = "Индуктивность, Гн";
			const string capacitorQuantityUnitText = "Емкость, Ф";

			if (selectedRadioButton == resistorRadioButton)
			{
				quantityUnitLabel.Text = resistorQuantityUnitText;
			}
			else if (selectedRadioButton == inductorRadioButton)
			{
				quantityUnitLabel.Text = inductorQuantityUnitText;
			}
			else if (selectedRadioButton == capacitorRadioButton)
			{
				quantityUnitLabel.Text = capacitorQuantityUnitText;
			}
		}
	}
}
