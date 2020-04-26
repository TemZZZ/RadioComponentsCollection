using System;

using Lab1Model;
using Lab1Model.PassiveComponents;


namespace ConsoleLoaderModel
{
    public delegate void Printer(string message);

    public static class ConsoleLoader
    {
        public static ComponentBase GetComponent(string type,
            Printer printer=null)
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
                        "Допустимые R, L или C");

                    return null;
            }
        }

        public static double StringToDouble(string inputStr,
            Printer printer = null)
        {
            double value = 0;

            try
            {
                value = Convert.ToDouble(inputStr.Replace('.', ','));
            }
            catch (FormatException)
            {
                printer?.Invoke("Введенная строка не соответствует " +
                    "формату вещественного числа.\n" +
                    "Введите число вида X.Y или X,Y, где X и Y - наборы цифр.");

                return double.NaN;
            }

            if ((value < double.MinValue) || (value > double.MaxValue))
            {
                printer?.Invoke("Введенное число не укладывается в диапазон " +
                    "вещественных чисел двойной точности.\n" +
                    "Введите чило из диапазона от " +
                    "(-/+)5.0*10^(-324) до (-/+)1.7*10^308.");

                return double.NaN;
            }

            return value;
        }

        public static void AskComponentValue(in ComponentBase cmp,
            Printer printer)
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
            else
            {
                printer("Это не радиокомпонент");
            }
        }
    }
}
