#define TEST

using System;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
	/// <summary>
	/// Форма добавления новых радиокомпонентов
	/// </summary>
	public partial class AddRadiocomponentForm_ : Form
	{
		private RadiocomponentControl_ _radiocomponentControl;

		/// <summary>
		/// Событие, возникающее при создании нового радиокомпонента
		/// </summary>
		public event EventHandler<RadiocomponentCreatedEventArgs_>
			RadiocomponentCreated;

		/// <summary>
		/// Создает форму <see cref="AddRadiocomponentForm_"/>
		/// </summary>
		public AddRadiocomponentForm_()
		{
			InitializeComponent();
			InitializeRadiocomponentControl();

#if !TEST
            generateRandomDataButton.Visible = false;
#endif
		}

		/// <summary>
		/// Добавляет на форму новый компонент
		/// <see cref="RadiocomponentControl_"/>
		/// </summary>
		private void InitializeRadiocomponentControl()
		{
			_radiocomponentControl = new RadiocomponentControl_
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
				= RadiocomponentFactory_.CreateRandomRadiocomponent();
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
				new RadiocomponentCreatedEventArgs_(
					_radiocomponentControl.Radiocomponent));
		}
	}
}
