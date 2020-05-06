//#define TEST

using System;
using System.Windows.Forms;


namespace Lab1View
{
    /// <summary>
    /// Форма добавления новых радиокомпонентов
    /// </summary>
    public partial class AddRadioComponentForm : Form
    {
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
    }
}
