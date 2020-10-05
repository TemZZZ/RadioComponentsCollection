using System;
using System.Windows.Forms;
using Model;

namespace View
{
	/// <summary>
	/// Форма выбора параметров загрузки радиокомпонентов
	/// </summary>
	public partial class SetRadiocomponentLoadOptionForm : Form
	{
		/// <summary>
		/// Событие, возникающее после подтверждения выбора
		/// параметра загрузки радиокомпонента
		/// </summary>
		public event EventHandler<RadiocomponentsReadyToLoadEventArgs>
			RadiocomponentReadyToLoad;

		/// <summary>
		/// Создает форму выбора параметров загрузки радиокомпонентов
		/// </summary>
		public SetRadiocomponentLoadOptionForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Подтверждает выбор параметра загрузки радиокомпонентов:
		/// добавить радиокомпоненты в конец таблицы
		/// или заменить радиокомпоненты в таблице.
		/// Вызывает событие <see cref="RadiocomponentReadyToLoad"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OkButton_Click(object sender, EventArgs e)
		{
			RadiocomponentsLoadOption loadOption
				= replaceAllRadioButton.Checked
					? RadiocomponentsLoadOption.ReplaceAll
					: RadiocomponentsLoadOption.AddToEnd;

			RadiocomponentReadyToLoad?.Invoke(this,
				new RadiocomponentsReadyToLoadEventArgs(loadOption));

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
