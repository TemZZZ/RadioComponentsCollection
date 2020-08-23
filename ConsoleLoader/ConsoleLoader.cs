using System;
using System.Globalization;
using System.Numerics;
using Model;
using Model.PassiveComponents;

namespace ConsoleLoaderModel
{
	/// <summary>
	/// Содержит методы, необходимые для работы
	/// консольного приложения
	/// </summary>
	public static class ConsoleLoader
	{
		/// <summary>
		/// Заменяет в исходной строке запятые и точки на региональный
		/// десятичный разделитель числа
		/// </summary>
		/// <param name="text">Исходная строка</param>
		/// <returns>Измененная строка</returns>
		public static string DotAndCommaToNumberDecimalSeparator(string text)
		{
			string regionalNumberDecimalSeparator = CultureInfo.
				CurrentCulture.NumberFormat.NumberDecimalSeparator;

			return text.Replace(",", regionalNumberDecimalSeparator)
					   .Replace(".", regionalNumberDecimalSeparator);
		}

		/// <summary>
		/// Конвертирует строку в вещественное число
		/// </summary>
		/// <param name="inputString">Строка</param>
		/// <param name="printer">Делегат для передачи
		/// сообщений об ошибках</param>
		/// <returns>Вещественное число, double.NaN,
		/// double.PositiveInfinity или
		/// double.NegativeInfinity</returns>
		public static double StringToDouble(
			string inputString, Action<string> printer = null)
		{
			double value = double.NaN;

			try
			{
				value = Convert.ToDouble(DotAndCommaToNumberDecimalSeparator(
					inputString));
			}
			catch (FormatException)
			{
				printer?.Invoke("Введенная строка не соответствует " +
					"формату вещественного числа.\n" +
					"Введите число вида X.Y или X,Y, " +
					"где X и Y - наборы цифр.");
			}

			if (double.IsInfinity(value))
			{
				printer?.Invoke("Введенное число не укладывается " +
					"в диапазон вещественных чисел двойной точности.\n" +
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
		/// <returns>true или false</returns>
		public static bool IsPositive(double value, string errorMessage,
			Action<string> printer = null)
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
		/// <param name="type">Тип компонента R (r), L (l)
		/// или C (c)</param>
		/// <param name="printer">Делегат для передачи
		/// сообщений об ошибках</param>
		/// <returns>Объект класса <see cref="Resistor"/>,
		/// <see cref="Inductor"/> или
		/// <see cref="Capacitor"/></returns>
		public static RadiocomponentBase GetRadiocomponent(
			string type, Action<string> printer = null)
		{
			const string resistorCharacter = "R";
			const string inductorCharacter = "L";
			const string capacitorCharacter = "C";

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
		/// <see cref="RadiocomponentBase"/></param>
		/// <param name="printer">Делегат для передачи запросов</param>
		public static void AskRadiocomponentValue(
			in RadiocomponentBase component, Action<string> printer)
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
		/// <param name="number">Комплексный импеданс</param>
		/// <param name="printer">Делегат для вывода строкового
		/// представления</param>
		public static void PrintComplex(Complex number,
			Action<string> printer)
		{
			const char signPlus = '+';
			const char signMinus = '-';
			const string infinityString = "INF";
			const string format = "G5";

			string realString = number.Real.ToString(format);
			string absImaginaryString =
				Math.Abs(number.Imaginary).ToString(format);

			if (double.IsInfinity(number.Real))
			{
				realString = infinityString;
			}
			if (double.IsInfinity(number.Imaginary))
			{
				absImaginaryString = infinityString;
			}

			char sign = signPlus;
			if (number.Imaginary < 0)
			{
				sign = signMinus;
			}

			printer($"Импеданс равен " +
				$"{realString} {sign} {absImaginaryString}j Ом");
		}
	}
}
