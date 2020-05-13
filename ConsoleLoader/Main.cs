using System;
using ConsoleLoaderModel;
using Lab1Model;


public class MainApp
{
	public static void Main()
	{
		const string exitCharacter = "Q";

		Console.WriteLine("Программа для вычисления\n" +
			"комплексного сопротивления радиокомпонентов");

		while (true)
		{
			Console.Write("\nДля выхода из программы введите Q (q)\n" +
					"или введите тип радиокомпонента" +
					"R (r), L (l) или C (c): ");
			string userAnswer = Console.ReadLine();
			if (userAnswer.ToUpper() == exitCharacter)
				return;

			ComponentBase component = ConsoleLoader.GetRadioComponent(
				userAnswer,	Console.WriteLine);
			if (component == null)
				continue;

			ConsoleLoader.AskRadioComponentValue(in component, Console.Write);
			double value = ConsoleLoader.StringToDouble(Console.ReadLine(),
				Console.WriteLine);
			if (double.IsNaN(value) || double.IsInfinity(value))
				continue;

			if (!ConsoleLoader.IsPositive(value,
				"Значение физической величины не может быть отрицательным",
				Console.WriteLine))
				continue;

			Console.Write("Введите частоту в герцах: ");
			double freq = ConsoleLoader.StringToDouble(Console.ReadLine(),
				Console.WriteLine);
			if (double.IsNaN(freq) || double.IsInfinity(freq))
				continue;

			if (!ConsoleLoader.IsPositive(freq,
				"Значение частоты не может быть отрицательным",
				Console.WriteLine))
				continue;

			component.Value = value;
			ConsoleLoader.PrintComplex(component.GetImpedance(freq),
				Console.WriteLine);
		}
	}
}
