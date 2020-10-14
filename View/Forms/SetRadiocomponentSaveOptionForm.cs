using System;
using System.Windows.Forms;
using Model;
using Model.IO;
using View.EventArgsClasses;

namespace View.Forms
{
	/// <summary>
	/// Форма выбора параметров сохранения радиокомпонентов
	/// </summary>
	public partial class SetRadiocomponentSaveOptionForm : Form
	{
		/// <summary>
		/// Событие, возникающее после подтверждения выбора
		/// параметра сохранения радиокомпонента
		/// </summary>
		public event EventHandler<RadiocomponentsReadyToSaveEventArgs>
			RadiocomponentReadyToSave;

		/// <summary>
		/// Создает форму выбора параметров сохранения радиокомпонентов
		/// </summary>
		public SetRadiocomponentSaveOptionForm()
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
		/// Подтверждает выбор параметра сохранения радиокомпонентов:
		/// сохранить все радиокомпоненты или сохранить выделенные
		/// радиокомпоненты. Вызывает событие
		/// <see cref="RadiocomponentReadyToSave"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OkButton_Click(object sender, EventArgs e)
		{
			SaveOption saveOption
				= saveSelectedRadioButton.Checked
					? SaveOption.SaveSelected
					: SaveOption.SaveAll;

			RadiocomponentReadyToSave?.Invoke(this,
				new RadiocomponentsReadyToSaveEventArgs(saveOption));

			this.Close();
		}
	}
}
