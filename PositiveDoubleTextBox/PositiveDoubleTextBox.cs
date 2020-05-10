using System;
using System.Windows.Forms;
using RegexTextBoxLib;


namespace PositiveDoubleTextBoxLib
{
    /// <summary>
    /// Представляет элемент управления Windows текстового поля
    /// с проверкой на соответствие введенного текста положительному
    /// вещественному числу
    /// </summary>
    public partial class PositiveDoubleTextBox : RegexTextBox
    {
        public PositiveDoubleTextBox()
        {
            /// <summary>
            /// Шаблон регулярного выражения положительных вещественных чисел
            /// </summary>
            const string positiveDoublePattern =
                @"^([0-9]+[\.\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";

            Pattern = positiveDoublePattern;

            InitializeComponent();
        }

        /// <summary>
        /// Преобразует строку в вещественное число
        /// и сообщает о результате преобразования
        /// </summary>
        /// <param name="text">Исходная строка</param>
        /// <param name="isPositiveDouble">Результат преобразования</param>
        /// <param name="messager">Делегат для сообщений об ошибках</param>
        /// <returns>Преобразованное число</returns>
        public static double ToPositiveDouble(
            string text, out bool isPositiveDouble,
            Action<string> messager = null)
        {
            const string emptyTextCaution = "Поле не может быть пустым";
            const string notNumberCaution =
                "Введенное значение не является числом";
            const string notPositiveNumberCaution =
                "Число не может быть отрицательным";

            isPositiveDouble = false;

            if (string.IsNullOrEmpty(text.Replace('.', ',')))
            {
                messager?.Invoke(emptyTextCaution);
                const double zero = 0;
                return zero;
            }

            bool isDouble = double.TryParse(
                text.Replace('.', ','), out double doubleValue);

            if (!isDouble)
            {
                messager?.Invoke(notNumberCaution);
                return doubleValue;
            }

            if (doubleValue < 0)
            {
                messager?.Invoke(notPositiveNumberCaution);
                return doubleValue;
            }

            isPositiveDouble = true;
            return doubleValue;
        }

        /// <summary>
        /// Выводит предупреждающее сообщение в MessageBox
        /// с единственной кнопкой OK
        /// </summary>
        /// <param name="message">Предупреждающее сообщение</param>
        public static void Messager(string message)
        {
            const string messageBoxHeader = "Предупреждение";
            MessageBox.Show(message, messageBoxHeader,
                MessageBoxButtons.OK);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            _ = ToPositiveDouble(this.Text, out _, Messager);
        }

        /// <summary>
        /// Возвращает вещественное число, введенное в поле
        /// </summary>
        public double GetValue()
        {
            return ToPositiveDouble(this.Text, out _);
        }
    }
}
