#define TEST

using System;
using System.Drawing;
using System.Windows.Forms;
using Model;
using View.EventArgsClasses;

namespace View.Forms
{
	/// <summary>
	/// Форма добавления новых радиокомпонентов
	/// </summary>
	public partial class AddRadiocomponentForm : Form
	{
		private RadiocomponentControl _radiocomponentControl;

		/// <summary>
		/// Событие, возникающее при создании нового радиокомпонента
		/// </summary>
		public event EventHandler<RadiocomponentCreatedEventArgs>
			RadiocomponentCreated;

		/// <summary>
		/// Создает форму <see cref="AddRadiocomponentForm"/>
		/// </summary>
		public AddRadiocomponentForm()
		{
			InitializeComponent();
			InitializeRadiocomponentControl();

#if !TEST
            generateRandomDataButton.Visible = false;
#endif
		}

		/// <summary>
		/// Добавляет на форму новый компонент
		/// <see cref="RadiocomponentControl"/>
		/// </summary>
		private void InitializeRadiocomponentControl()
		{
			_radiocomponentControl = new RadiocomponentControl
			{
				Location = new Point(9, 8),
				ReadOnly = false
			};

			Controls.Add(_radiocomponentControl);
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
		/// Генерирует случайный радиокомпонент
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GenerateRandomDataButton_Click(
			object sender, EventArgs e)
		{
			_radiocomponentControl.Radiocomponent
				= RadiocomponentFactory.GetRandomRadiocomponent();
		}

		/// <summary>
		/// Создает новый объект класса <see cref="Resistor"/>,
		/// <see cref="Inductor"/> или <see cref="Capacitor"/>
		/// и вызывает событие <see cref="RadiocomponentCreated"/>.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddRadiocomponentButton_Click(
			object sender, EventArgs e)
		{
			if (_radiocomponentControl.Radiocomponent is null)
				return;

			RadiocomponentCreated?.Invoke(this,
				new RadiocomponentCreatedEventArgs(
					_radiocomponentControl.Radiocomponent));
		}
	}
}
