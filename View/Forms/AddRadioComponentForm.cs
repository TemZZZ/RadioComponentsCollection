#define TEST

using System;
using System.Drawing;
using System.Windows.Forms;
using Model.PassiveComponents;


namespace View
{
    /// <summary>
    /// Форма добавления новых радиокомпонентов
    /// </summary>
    public partial class AddRadioComponentForm : Form
    {
        private RadioComponentControl _radioComponentControl;

        /// <summary>
        /// Событие, возникающее при создании нового радиокомпонента
        /// </summary>
        public event EventHandler<RadioComponentCreatedEventArgs>
            RadioComponentCreated;

        /// <summary>
        /// Создает форму <see cref="AddRadioComponentForm"/>
        /// </summary>
        public AddRadioComponentForm()
        {
            InitializeComponent();
            InitializeRadioComponentControl();

#if !TEST
            generateRandomDataButton.Visible = false;
#endif
        }

        /// <summary>
        /// Добавляет на форму новый компонент
        /// <see cref="RadioComponentControl"/>
        /// </summary>
        private void InitializeRadioComponentControl()
		{
            _radioComponentControl = new RadioComponentControl
            {
                Location = new Point(9, 8),
                ReadOnly = false
            };

            Controls.Add(_radioComponentControl);
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
            var randomIntGenerator = new Random();

            const int maxRadioButtonNumber = 3;

            const double resistorDivisor = 1e6;
            const double inductorDivisor = 1e12;
            const double capacitorDivisor = 1e15;

            double value = randomIntGenerator.Next();
            switch (randomIntGenerator.Next(maxRadioButtonNumber))
            {
                case 0:
                    value /= resistorDivisor;
                    _radioComponentControl.RadioComponent
                        = new Resistor(value);
                    break;
                case 1:
                    value /= inductorDivisor;
                    _radioComponentControl.RadioComponent
                        = new Inductor(value);
                    break;
                case 2:
                    value /= capacitorDivisor;
                    _radioComponentControl.RadioComponent
                        = new Capacitor(value);
                    break;
            }
        }

        /// <summary>
        /// Создает новый объект класса <see cref="Resistor"/>,
        /// <see cref="Inductor"/> или <see cref="Capacitor"/>
        /// и вызывает событие <see cref="RadioComponentCreated"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRadioComponentButton_Click(
            object sender, EventArgs e)
        {
            if (!(_radioComponentControl.RadioComponent is null))
			{
                RadioComponentCreated?.Invoke(this,
                    new RadioComponentCreatedEventArgs(
                        _radioComponentControl.RadioComponent));
            }
        }
    }
}
