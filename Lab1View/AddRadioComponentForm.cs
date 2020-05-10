#define TEST

using System;
using System.Windows.Forms;
using Lab1Model;
using Lab1Model.PassiveComponents;
using PositiveDoubleTextBoxLib;


namespace Lab1View
{
    /// <summary>
    /// Форма добавления новых радиокомпонентов
    /// </summary>
    public partial class AddRadioComponentForm : Form
    {
        private readonly Random randomIntGenerator = new Random();

        /// <summary>
        /// Создает новый форму добавления радиокомпонентов
        /// </summary>
        public AddRadioComponentForm()
        {
            InitializeComponent();
#if !TEST
            generateRandomDataButton.Visible = false;
#endif
            // Регистрируются обработчики событий
            // изменения состояния радиокнопок

            resistorRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            inductorRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            capacitorRadioButton.CheckedChanged += RadioButton_CheckedChanged;

            // По умолчанию выбрана радиокнопка резистора
            resistorRadioButton.Checked = true;
        }

        private void RadioButton_CheckedChanged(
            object sender, EventArgs e)
        {
            if (!(sender is RadioButton selectedRadioButton)) { return; }

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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateRandomDataButton_Click(
            object sender, EventArgs e)
        {
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

        private void AddRadioComponentButton_Click(
            object sender, EventArgs e)
        {
            double radioComponentValue =
                PositiveDoubleTextBox.ToPositiveDouble(
                    valuePositiveDoubleTextBox.Text,
                    out bool isPositiveDouble,
                    PositiveDoubleTextBox.Messager);

            if (!isPositiveDouble) { return; }

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
            MainForm.radioComponents.Add(radioComponent);
        }
    }
}
