#define TEST

using System;
using System.Windows.Forms;


namespace Lab1View
{
    /// <summary>
    /// Форма добавления новых радиокомпонентов
    /// </summary>
    public partial class AddRadioComponentForm : Form
    {
        //const string doublePattern =
        //    @"^[-+]?([0-9]+[\.\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";
        /// <summary>
        /// Шаблон регулярного выражения положительных вещественных чисел
        /// </summary>
        const string positiveDoublePattern =
            @"^([0-9]+[\.\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";

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

            valueRegexTextBox.Pattern = positiveDoublePattern;
        }

        private void RadioButton_CheckedChanged(
            object sender, EventArgs e)
        {
            var selectedRadioButton = sender as RadioButton;
            if (selectedRadioButton is null) { return; }

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

            valueRegexTextBox.Text = Convert.ToString(value);
        }
    }
}
