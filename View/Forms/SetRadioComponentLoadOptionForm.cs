using System;
using System.Windows.Forms;


namespace View
{
	/// <summary>
	/// Форма выбора параметров загрузки радиокомпонентов
	/// </summary>
	public partial class SetRadioComponentLoadOptionForm : Form
	{
		/// <summary>
		/// Событие, возникающее после подтверждения выбора
		/// параметра загрузки радиокомпонента
		/// </summary>
		public event EventHandler<RadioComponentReadyToLoadEventArgs>
			RadioComponentReadyToLoad;

		/// <summary>
		/// Создает форму выбора параметров загрузки радиокомпонентов
		/// </summary>
		public SetRadioComponentLoadOptionForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Подтверждает выбор параметра загрузки радиокнопкой:
		/// добавить радиокомпоненты в конец таблицы
		/// <see cref="addToEndRadioButton"/>
		/// или заменить радиокомпоненты в таблице
		/// <see cref="replaceAllRadioButton"/>.
		/// Вызывает событие <see cref="RadioComponentReadyToLoad"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OkButton_Click(object sender, EventArgs e)
		{
			RadioComponentLoadOption loadOption
				= replaceAllRadioButton.Checked
					? RadioComponentLoadOption.ReplaceAll
					: RadioComponentLoadOption.AddToEnd;

			RadioComponentReadyToLoad?.Invoke(this,
				new RadioComponentReadyToLoadEventArgs(loadOption));

			this.Close();
		}

		/// <summary>
		/// Закрывает форму
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
