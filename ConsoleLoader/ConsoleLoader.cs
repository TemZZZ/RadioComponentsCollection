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
        /// <summary>
        /// Конвертирует строку в вещественное число
        /// </summary>
        /// <param name="inputStr">Строка</param>
        /// <param name="printer">Делегат для передачи
        /// сообщений об ошибках</param>
        /// <returns>Вещественное число, <see cref="double.NaN"/>,
        /// <see cref="double.PositiveInfinity"/> или
        /// <see cref="double.NegativeInfinity"/></returns>
        public static double StringToDouble(
            string inputStr, Action<string> printer = null)
        {
            double value = double.NaN;

            try
            {
                value = Convert.ToDouble(inputStr.Replace('.', ','));
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
        /// <param name="type">Тип компонента "R" ("r"),
        /// "L" ("l") или "C" ("c")</param>
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
                case "R":
                    return new Resistor();

                case "L":
                    return new Inductor();

                case "C":
                    return new Capacitor();

                default:
                    printer?.Invoke("Неизвестный тип компонента.\n" +
                        "Допустимые R (r), L (l) или C (c)");

                    return null;
            }
        }

        /// <summary>
        /// Выводит запрос для ввода значения физической
        /// величины радиокомпонента
        /// </summary>
        /// <param name="cmp">Объект класса радиокомпонента
        /// <see cref="ComponentBase"/></param>
        /// <param name="printer">Делегат для передачи запросов</param>
        public static void AskComponentValue(
            in ComponentBase cmp, Action<string> printer)
        {
            if (cmp is Resistor)
            {
                printer("Введите сопротивление резистора в омах: ");
            }
            else if (cmp is Inductor)
            {
                printer("Введите индуктивность катушки в генри: ");
            }
            else if (cmp is Capacitor)
            {
                printer("Введите емкость конденсатора в фарадах: ");
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
            char sign = '+';

            if (im < 0)
            {
                sign = '-';
            }

            printer($"Импеданс равен {value.Real} {sign} " +
                $"{Math.Abs(im)}j Ом");
        }
    }
}
