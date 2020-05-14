using System;
using System.Windows.Forms;


namespace Lab1View
{
	/// <summary>
	/// Форма выбора параметров сохранения радиокомпонентов
	/// </summary>
	public partial class SetRadioComponentSaveOptionForm : Form
	{
		/// <summary>
		/// Событие, возникающее при выборе параметра сохранения
		/// и подтверждении выбора
		/// </summary>
		public event RadioComponentReadyToSaveEventHandler
			RadioComponentReadyToSave;

		/// <summary>
		/// Создает форму выбора параметров сохранения радиокомпонентов
		/// </summary>
		public SetRadioComponentSaveOptionForm()
		{
			InitializeComponent();
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

		/// <summary>
		/// Подтверждает выбор параметра сохранения радиокнопкой:
		/// сохранить все радиокомпоненты <see cref="saveAllRadioButton"/>
		/// или сохранить выделенные радиокомпоненты
		/// <see cref="saveSelectedRadioButton"/>.
		/// Вызывает событие <see cref="RadioComponentReadyToSave"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OkButton_Click(object sender, EventArgs e)
		{
			RadioComponentSaveOption saveOption;
			if (saveSelectedRadioButton.Checked)
			{
				saveOption = RadioComponentSaveOption.SaveSelected;
			}
			else
			{
				saveOption = RadioComponentSaveOption.SaveAll;
			}
			RadioComponentReadyToSave(this,
				new RadioComponentReadyToSaveEventArgs(saveOption));
		}
	}

	/// <summary>
	/// Параметр сохранения радиокомпонентов
	/// </summary>
	public enum RadioComponentSaveOption
	{
		SaveAll,
		SaveSelected
	}

	/// <summary>
	/// Событие подтверждения выбора параметра сохранения радиокомпонента
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void RadioComponentReadyToSaveEventHandler(
		object sender, RadioComponentReadyToSaveEventArgs e);

	/// <summary>
	/// Класс данных события
	/// <see cref="RadioComponentReadyToSaveEventHandler"/>
	/// </summary>
	public class RadioComponentReadyToSaveEventArgs : EventArgs
    {
		/// <summary>
		/// Создает объект класса
		/// <see cref="RadioComponentReadyToSaveEventArgs"/>
		/// </summary>
		/// <param name="radioComponentSaveOption">
		/// Параметр сохранения радиокомпонентов</param>
		public RadioComponentReadyToSaveEventArgs(
			RadioComponentSaveOption radioComponentSaveOption)
        {
			RadioComponentSaveOption = radioComponentSaveOption;
        }

		/// <summary>
		/// Позволяет получить параметр сохранения радиокомпонентов
		/// </summary>
        public RadioComponentSaveOption RadioComponentSaveOption { get; }
    }
}
