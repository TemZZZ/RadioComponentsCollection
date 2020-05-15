using System;
using System.Windows.Forms;
using System.Globalization;
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
        /// <summary>
        /// Текст по умолчанию
        /// </summary>
        private const string _defaultText = "0";

        /// <summary>
        /// Создает элемент <see cref="PositiveDoubleTextBox"/>
        /// </summary>
        public PositiveDoubleTextBox()
        {
            // Шаблон регулярного выражения положительных вещественных чисел
            const string positiveDoublePattern =
                @"^([0-9]+[\.\,]?[0-9]*([eE]?[-+]?[0-9]*))?$";

            Pattern = positiveDoublePattern;
            Text = _defaultText;
            LostFocus += OnLostFocus;

            InitializeComponent();
        }

        /// <summary>
        /// Заменяет в исходной строке запятые и точки на региональный
        /// десятичный разделитель числа
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string DotAndCommaToNumberDecimalSeparator(string text)
        {
            string sep = CultureInfo.
                CurrentCulture.NumberFormat.NumberDecimalSeparator;

            return text.Replace(",", sep).Replace(".", sep);
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

            if (string.IsNullOrEmpty(text))
            {
                messager?.Invoke(emptyTextCaution);
                const double zero = 0;
                return zero;
            }

            bool isDouble = double.TryParse(
                DotAndCommaToNumberDecimalSeparator(text),
                out double doubleValue);

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
        /// Выводит предупреждающее сообщение в
        /// <see cref="MessageBox"/>
        /// с единственной кнопкой OK
        /// </summary>
        /// <param name="message">Предупреждающее сообщение</param>
        public static void Messager(string message)
        {
            const string messageBoxHeader = "Предупреждение";
            MessageBox.Show(message, messageBoxHeader,
                MessageBoxButtons.OK);
        }

        /// <summary>
        /// При потере фокуса элементом
        /// <see cref="PositiveDoubleTextBox"/>,  если введенное
        /// пользователем значение все же не соответствует
        /// положительному вещественному числу, вывести пользователю
        /// предупреждение через <see cref="Messager"/>
        /// </summary>
        /// <param name="e"></param>
        private void OnLostFocus(object sender, EventArgs e)
        {
            _ = ToPositiveDouble(Text, out _, Messager);

            if (string.IsNullOrEmpty(Text))
            {
                Text = _defaultText;
            }
        }

        /// <summary>
        /// Возвращает вещественное число, введенное в поле
        /// </summary>
        public double GetValue()
        {
            return ToPositiveDouble(Text, out _);
        }
    }
}
