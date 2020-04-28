using System;

using ConsoleLoaderModel;

using Lab1Model;


public class MainApp
{
	/// <summary>Символ выхода из программы</summary>
	const string exitCharacter = "Q";

	public static void Main()
	{
		Console.WriteLine("Программа для вычисления\n" +
			"комплексного сопротивления радиокомпонентов");

		while (true)
		{
			Console.Write("\nДля выхода из программы введите Q (q)\n" +
				"или введите тип радиокомпонента R (r), L (l) или C (c): ");

			string inputStr = Console.ReadLine();

			if (inputStr.ToUpper() == exitCharacter) { return; }

			ComponentBase component = ConsoleLoader.GetComponent(
				inputStr, Console.WriteLine);

			if (component == null) { continue; }

			ConsoleLoader.AskComponentValue(in component, Console.Write);
			inputStr = Console.ReadLine();

			double value = ConsoleLoader.StringToDouble(
				inputStr, Console.WriteLine);

			if ((double.IsNaN(value)) ||
				(!ConsoleLoader.IsPositiveDouble(value,
				"Значение физической величины не может быть отрицательным",
				Console.WriteLine))) { continue; }

			Console.Write("Введите частоту в герцах: ");
			inputStr = Console.ReadLine();

			double freq = ConsoleLoader.StringToDouble(
				inputStr, Console.WriteLine);

			if ((double.IsNaN(freq)) ||
				(!ConsoleLoader.IsPositiveDouble(freq,
				"Значение частоты не может быть отрицательным",
				Console.WriteLine))) { continue; }

			component.Value = value;

			ConsoleLoader.PrintComplex(
				component.GetImpedance(freq), Console.WriteLine);
		}
	}
}
