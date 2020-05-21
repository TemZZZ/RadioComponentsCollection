using System;
using ConsoleLoaderModel;
using Lab1Model;
using Lab1Model.PassiveComponents;


public class MainApp
{
	/// <summary>
	/// Символ выхода из программы
	/// </summary>
	const string exitCharacter = "Q";

	/// <summary>
	/// Циклически запрашивает у пользователя символ радиокомпонента
	/// и возвращает объект производного класса от
	/// <see cref="ComponentBase"/>. Цикл завершается, если пользователь
	/// ввел <see cref="exitCharacter"/> в любом регистре
	/// </summary>
	/// <returns>Объект <see cref="Resistor"/>, <see cref="Inductor"/>,
	/// <see cref="Capacitor"/> или null</returns>
	public static ComponentBase GetRadioComponentLoop()
	{
		ComponentBase component = null;
		string userAnswer = null;

		while (component == null)
		{
			Console.Write("\nВведите тип радиокомпонента " +
					"R (r), L (l) или C (c): ");
			userAnswer = Console.ReadLine().ToUpper();
			if (userAnswer == exitCharacter)
				break;

			component = ConsoleLoader.GetRadioComponent(
				userAnswer, Console.WriteLine);
		}
		return component;
	}

	/// <summary>
	/// Циклически запрашивает у пользователя значение физической величины
	/// радиокомпонента и возвращает значение. Цикл завершается, если
	/// пользователь ввел <see cref="exitCharacter"/> в любом регистре
	/// </summary>
	/// <returns>Положительное double или double.NaN</returns>
	public static double GetRadioComponentValueLoop(
		in ComponentBase radioComponent)
	{
		double value = double.NaN;
		string userAnswer = null;

		while (double.IsNaN(value) || double.IsInfinity(value) || value < 0)
		{
			value = double.NaN;

			ConsoleLoader.AskRadioComponentValue(in radioComponent,
				Console.Write);
			userAnswer = Console.ReadLine().ToUpper();
			if (userAnswer == exitCharacter)
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
	/// <see cref="exitCharacter"/> в любом регистре
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
			if (userAnswer == exitCharacter)
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
			var radioComponent = GetRadioComponentLoop();
			if (radioComponent is null)
				return;

			double radioComponentValue = GetRadioComponentValueLoop(
				in radioComponent);
			if (double.IsNaN(radioComponentValue))
				return;

			double frequency = GetFrequencyLoop();
			if (double.IsNaN(frequency))
				return;

			radioComponent.Value = radioComponentValue;
			ConsoleLoader.PrintComplex(
				radioComponent.GetImpedance(frequency), Console.WriteLine);
		}
	}
}
