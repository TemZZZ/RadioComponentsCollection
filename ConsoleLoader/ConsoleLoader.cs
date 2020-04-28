using System;
using System.Numerics;

using Lab1Model;
using Lab1Model.PassiveComponents;


namespace ConsoleLoaderModel
{
    /// <summary>
    /// Содержит методы, необходимые для работы
    /// консольного приложения
    /// </summary>
    public static class ConsoleLoader
    {
        /// <summary>Символ резистора</summary>
        const string resistorCharacter = "R";

        /// <summary>Символ катушки индуктивности</summary>
        const string inductorCharacter = "L";

        /// <summary>Символ конденсатора</summary>
        const string capacitorCharacter = "C";

        /// <summary>Знак плюс</summary>
        const char plusSign = '+';

        /// <summary>Знак минус</summary>
        const char minusSign = '-';

        /// <summary>
        /// Конвертирует строку в вещественное число
        /// </summary>
        /// <param name="inputString">Строка</param>
        /// <param name="printer">Делегат для передачи
        /// сообщений об ошибках</param>
        /// <returns>Вещественное число, <see cref="double.NaN"/>,
        /// <see cref="double.PositiveInfinity"/> или
        /// <see cref="double.NegativeInfinity"/></returns>
        public static double StringToDouble(
            string inputString, Action<string> printer = null)
        {
            double value = double.NaN;

            try
            {
                value = Convert.ToDouble(inputString.Replace('.', ','));
            }
            catch (FormatException)
            {
                printer?.Invoke("Введенная строка не соответствует " +
                    "формату вещественного числа.\n" +
                    "Введите число вида X.Y или X,Y, где X и Y - наборы цифр.");
            }

            if (double.IsInfinity(value))
            {
                printer?.Invoke("Введенное число не укладывается в диапазон " +
                    "вещественных чисел двойной точности.\n" +
                    "Введите чило из диапазона от " +
                    "(-/+)5.0*10^(-324) до (-/+)1.7*10^308.");
            }

            return value;
        }

        /// <summary>
        /// Проверяет, положительно ли вещественное число
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <param name="errorMessage">Сообщение об ошибке, которое
        /// необходимо передать пользователю в случае
        /// отрицательного числа</param>
        /// <param name="printer">Делегат для передачи
        /// сообщений об ошибках</param>
        /// <returns><see cref="true"/> или
        /// <see cref="false"/></returns>
        public static bool IsPositiveDouble(
            double value, string errorMessage, Action<string> printer = null)
        {
            if (value < 0)
            {
                printer?.Invoke(errorMessage);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Возвращает объект радиокомпонента в зависимости
        /// от введенной пользователем строки
        /// </summary>
        /// <param name="type">Тип компонента
        /// <see cref="resistorCharacter">R</see> (r),
        /// <see cref="inductorCharacter">L</see> (l) или
        /// <see cref="capacitorCharacter">C</see> (c)</param>
        /// <param name="printer">Делегат для передачи
        /// сообщений об ошибках</param>
        /// <returns>Объект класса <see cref="Resistor"/>,
        /// <see cref="Inductor"/> или
        /// <see cref="Capacitor"/></returns>
        public static ComponentBase GetComponent(
            string type, Action<string> printer = null)
        {
            switch (type.ToUpper())
            {
                case resistorCharacter:
                    return new Resistor();

                case inductorCharacter:
                    return new Inductor();

                case capacitorCharacter:
                    return new Capacitor();

                default:
                    printer?.Invoke("Неизвестный тип компонента");

                    return null;
            }
        }

        /// <summary>
        /// Выводит запрос для ввода значения физической
        /// величины радиокомпонента
        /// </summary>
        /// <param name="component">Объект класса радиокомпонента
        /// <see cref="ComponentBase"/></param>
        /// <param name="printer">Делегат для передачи запросов</param>
        public static void AskComponentValue(
            in ComponentBase component, Action<string> printer)
        {
            switch (component)
            {
                case Resistor _:
                    printer("Введите сопротивление резистора в омах: ");
                    break;
                case Inductor _:
                    printer("Введите индуктивность катушки в генри: ");
                    break;
                case Capacitor _:
                    printer("Введите емкость конденсатора в фарадах: ");
                    break;
            }
        }

        /// <summary>
        /// Выводит строковое представление импеданса типа Complex
        /// </summary>
        /// <param name="value">Комплексный импеданс</param>
        /// <param name="printer">Делегат для вывода строкового
        /// представления</param>
        public static void PrintComplex(Complex value, Action<string> printer)
        {
            double im = value.Imaginary;
            char sign = plusSign;

            if (im < 0)
            {
                sign = minusSign;
            }

            printer($"Импеданс равен {value.Real} {sign} " +
                $"{Math.Abs(im)}j Ом");
        }
    }
}
