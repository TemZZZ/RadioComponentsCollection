using System;
using ConsoleLoaderModel;
using Model;
using Model.PassiveComponents;


public class MainApp
{
	/// <summary>
	/// Символ выхода из программы
	/// </summary>
	private const string _exitCharacter = "Q";

	/// <summary>
	/// Циклически запрашивает у пользователя символ радиокомпонента
	/// и возвращает объект производного класса от
	/// <see cref="RadiocomponentBase"/>. Цикл завершается, если пользователь
	/// ввел <see cref="_exitCharacter"/> в любом регистре
	/// </summary>
	/// <returns>Объект <see cref="Resistor"/>, <see cref="Inductor"/>,
	/// <see cref="Capacitor"/> или null</returns>
	public static RadiocomponentBase GetRadiocomponentLoop()
	{
		RadiocomponentBase component = null;
		string userAnswer = null;

		while (component == null)
		{
			Console.Write("\nВведите тип радиокомпонента " +
					"R (r), L (l) или C (c): ");
			userAnswer = Console.ReadLine().ToUpper();
			if (userAnswer == _exitCharacter)
				break;

			component = ConsoleLoader.GetRadiocomponent(
				userAnswer, Console.WriteLine);
		}
		return component;
	}

	/// <summary>
	/// Циклически запрашивает у пользователя значение физической величины
	/// радиокомпонента и возвращает значение. Цикл завершается, если
	/// пользователь ввел <see cref="_exitCharacter"/> в любом регистре
	/// </summary>
	/// <returns>Положительное double или double.NaN</returns>
	public static double GetRadiocomponentValueLoop(
		in RadiocomponentBase radiocomponent)
	{
		double value = double.NaN;
		string userAnswer = null;

		while (double.IsNaN(value) || double.IsInfinity(value) || value < 0)
		{
			value = double.NaN;

			ConsoleLoader.AskRadiocomponentValue(in radiocomponent,
				Console.Write);
			userAnswer = Console.ReadLine().ToUpper();
			if (userAnswer == _exitCharacter)
				break;

			value = ConsoleLoader.StringToDouble(userAnswer,
				Console.WriteLine);
			_ = ConsoleLoader.IsPositive(value,
				"Значение физической величины не может быть отрицательным",
				Console.WriteLine);
		}
		return value;
	}

	/// <summary>
	/// Циклически запрашивает у пользователя значение частоты и возвращает
	/// значение. Цикл завершается, если пользователь ввел
	/// <see cref="_exitCharacter"/> в любом регистре
	/// </summary>
	/// <returns>Положительное double или double.NaN</returns>
	public static double GetFrequencyLoop()
	{
		double frequency = double.NaN;
		string userAnswer = null;

		while (double.IsNaN(frequency) || double.IsInfinity(frequency)
			|| frequency < 0)
		{
			frequency = double.NaN;

			Console.Write("Введите частоту в герцах: ");
			userAnswer = Console.ReadLine().ToUpper();
			if (userAnswer == _exitCharacter)
				break;

			frequency = ConsoleLoader.StringToDouble(userAnswer,
				Console.WriteLine);
			_ = ConsoleLoader.IsPositive(frequency,
				"Значение частоты не может быть отрицательным",
				Console.WriteLine);
		}
		return frequency;
	}

	public static void Main()
	{
		Console.WriteLine("Программа для вычисления\n" +
			"комплексного сопротивления радиокомпонентов\n" +
			"\nДля выхода из программы введите Q (q)");

		while (true)
		{
			var radiocomponent = GetRadiocomponentLoop();
			if (radiocomponent is null)
				return;

			double radiocomponentValue = GetRadiocomponentValueLoop(
				in radiocomponent);
			if (double.IsNaN(radiocomponentValue))
				return;

			double frequency = GetFrequencyLoop();
			if (double.IsNaN(frequency))
				return;

			radiocomponent.Value = radiocomponentValue;
			ConsoleLoader.PrintComplex(
				radiocomponent.GetImpedance(frequency), Console.WriteLine);
		}
	}
}
