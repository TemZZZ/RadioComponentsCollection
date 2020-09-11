using System;
using System.Windows.Forms;

namespace View
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
		public event EventHandler<RadiocomponentReadyToSaveEventArgs>
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
			RadiocomponentsSaveOption saveOption
				= saveSelectedRadioButton.Checked
					? RadiocomponentsSaveOption.SaveSelected
					: RadiocomponentsSaveOption.SaveAll;

			RadiocomponentReadyToSave?.Invoke(this,
				new RadiocomponentReadyToSaveEventArgs(saveOption));

			this.Close();
		}
	}
}
