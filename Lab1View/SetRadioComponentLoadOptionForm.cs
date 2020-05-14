using System;
using System.Windows.Forms;


namespace Lab1View
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
		public event RadioComponentReadyToLoadEventHandler
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
			RadioComponentLoadOption loadOption;
			if (replaceAllRadioButton.Checked)
			{
				loadOption = RadioComponentLoadOption.ReplaceAll;
			}
			else
			{
				loadOption = RadioComponentLoadOption.AddToEnd;
			}
			RadioComponentReadyToLoad(this,
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

	/// <summary>
	/// Параметр загрузки радиокомпонентов
	/// </summary>
	public enum RadioComponentLoadOption
	{
		AddToEnd,
		ReplaceAll
	}

	/// <summary>
	/// Событие подтверждения выбора параметра загрузки радиокомпонента
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void RadioComponentReadyToLoadEventHandler(
		object sender, RadioComponentReadyToLoadEventArgs e);

	/// <summary>
	/// Класс данных события
	/// <see cref="RadioComponentReadyToLoadEventHandler"/>
	/// </summary>
	public class RadioComponentReadyToLoadEventArgs : EventArgs
	{
		/// <summary>
		/// Создает объект класса
		/// <see cref="RadioComponentReadyToLoadEventArgs"/>
		/// </summary>
		/// <param name="radioComponentLoadOption">
		/// Параметр сохранения радиокомпонентов</param>
		public RadioComponentReadyToLoadEventArgs(
			RadioComponentLoadOption radioComponentLoadOption)
		{
			RadioComponentLoadOption = radioComponentLoadOption;
		}

		/// <summary>
		/// Позволяет получить параметр загрузки радиокомпонентов
		/// </summary>
		public RadioComponentLoadOption RadioComponentLoadOption { get; }
	}
}
