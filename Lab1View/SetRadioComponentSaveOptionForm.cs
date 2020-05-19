﻿using System;
using System.Windows.Forms;


namespace Lab1View
{
	/// <summary>
	/// Форма выбора параметров сохранения радиокомпонентов
	/// </summary>
	public partial class SetRadioComponentSaveOptionForm : Form
	{
		/// <summary>
		/// Событие, возникающее после подтверждения выбора
		/// параметра сохранения радиокомпонента
		/// </summary>
		public event EventHandler<RadioComponentReadyToSaveEventArgs>
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
			RadioComponentReadyToSave?.Invoke(this,
				new RadioComponentReadyToSaveEventArgs(saveOption));

			this.Close();
		}
	}
}
