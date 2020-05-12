#define TEST

using System;
using System.Windows.Forms;
using Lab1Model;
using Lab1Model.PassiveComponents;
using PositiveDoubleTextBoxLib;


namespace Lab1View
{
    /// <summary>
    /// Событие создания нового радиокомпонента
    /// <see cref="RadioComponentBase"/> или производного от него
    /// класса
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void RadioComponentCreatedEventHandler(
        object sender, RadioComponentCreatedEventArgs e);

    /// <summary>
    /// Класс данных события <see cref="RadioComponentCreatedEventHandler"/>
    /// </summary>
    public class RadioComponentCreatedEventArgs : EventArgs
    {
        /// <summary>
        /// Создает объект класса
        /// <see cref="RadioComponentCreatedEventArgs"/>
        /// </summary>
        /// <param name="radioComponent">
        /// Созданный объект радиокомпонента</param>
        public RadioComponentCreatedEventArgs(
            RadioComponentBase radioComponent)
        {
            RadioComponent = radioComponent;
        }

        /// <summary>
        /// Объект радиокомпонента
        /// </summary>
        public RadioComponentBase RadioComponent { get; }
    }

    /// <summary>
    /// Форма добавления новых радиокомпонентов
    /// </summary>
    public partial class AddRadioComponentForm : Form
    {
        /// <summary>
        /// Событие, возникающее при создании нового радиокомпонента
        /// </summary>
        public event RadioComponentCreatedEventHandler RadioComponentCreated;

        /// <summary>
        /// Создает форму <see cref="AddRadioComponentForm"/>
        /// </summary>
        public AddRadioComponentForm()
        {
            InitializeComponent();
#if !TEST
            generateRandomDataButton.Visible = false;
#endif
            // Регистрируются обработчики событий
            // изменения состояния радиокнопок

            resistorRadioButton.CheckedChanged +=
                RadioButton_CheckedChanged;
            inductorRadioButton.CheckedChanged +=
                RadioButton_CheckedChanged;
            capacitorRadioButton.CheckedChanged +=
                RadioButton_CheckedChanged;

            // По умолчанию выбрана радиокнопка резистора
            resistorRadioButton.Checked = true;
        }

        /// <summary>
        /// Изменяет текст <see cref="valueUnitLabel"/>
        /// в зависимости от выбранной радиокнопки:
        /// <see cref="resistorRadioButton"/>
        /// <see cref="inductorRadioButton"/> или
        /// <see cref="capacitorRadioButton"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(
            object sender, EventArgs e)
        {
            if (!(sender is RadioButton selectedRadioButton))
                return;

            const string resistorValueUnitText = "Сопротивление, Ом";
            const string inductorValueUnitText = "Индуктивность, Гн";
            const string capacitorValueUnitText = "Емкость, Ф";

            if (selectedRadioButton == resistorRadioButton)
            {
                valueUnitLabel.Text = resistorValueUnitText;
            }
            else if (selectedRadioButton == inductorRadioButton)
            {
                valueUnitLabel.Text = inductorValueUnitText;
            }                
            else if (selectedRadioButton == capacitorRadioButton)
            {
                valueUnitLabel.Text = capacitorValueUnitText;
            }
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
        /// Генерирует случайные данные значения
        /// <see cref="valuePositiveDoubleTextBox"/> и
        /// случайно выбирает радиокнопку:
        /// <see cref="resistorRadioButton"/>
        /// <see cref="inductorRadioButton"/> или
        /// <see cref="capacitorRadioButton"/>
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
                    resistorRadioButton.Checked = true;
                    value /= resistorDivisor;
                    break;
                case 1:
                    inductorRadioButton.Checked = true;
                    value /= inductorDivisor;
                    break;
                case 2:
                    capacitorRadioButton.Checked = true;
                    value /= capacitorDivisor;
                    break;
            }
            valuePositiveDoubleTextBox.Text = Convert.ToString(value);
        }

        /// <summary>
        /// Создает новый объект класса <see cref="Resistor"/>,
        /// <see cref="Inductor"/> или <see cref="Capacitor"/>
        /// и вызывает событие <see cref="RadioComponentCreated"/>.
        /// Тип объекта зависит от выбранной радиокнопки:
        /// <see cref="resistorRadioButton"/>
        /// <see cref="inductorRadioButton"/> или
        /// <see cref="capacitorRadioButton"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRadioComponentButton_Click(
            object sender, EventArgs e)
        {
            double radioComponentValue =
                PositiveDoubleTextBox.ToPositiveDouble(
                    valuePositiveDoubleTextBox.Text,
                    out bool isPositiveDouble,
                    PositiveDoubleTextBox.Messager);

            if (!isPositiveDouble)
                return;

            RadioComponentBase radioComponent = null;
            if (resistorRadioButton.Checked)
            {
                radioComponent = new Resistor(radioComponentValue);
            }
            else if (inductorRadioButton.Checked)
            {
                radioComponent = new Inductor(radioComponentValue);
            }
            else if (capacitorRadioButton.Checked)
            {
                radioComponent = new Capacitor(radioComponentValue);
            }
            RadioComponentCreated(this,
                new RadioComponentCreatedEventArgs(radioComponent));
        }
    }
}
