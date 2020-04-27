using System;

using ConsoleLoaderModel;

using Lab1Model;


public class MainApp
{
	public static void Main()
	{
		Console.WriteLine("Программа для вычисления\n" +
			"комплексного сопротивления радиокомпонентов");

		while (true)
		{
			Console.Write("\nДля выхода из программы введите Q (q)\n" +
				"или введите тип радиокомпонента R (r), L (l) или C (c): ");

			string inputStr = Console.ReadLine();

			if (inputStr.ToUpper() == "Q") { return; }

			ComponentBase cmp = ConsoleLoader.GetComponent(
				inputStr, Console.WriteLine);

			if (cmp == null) { continue; }

			ConsoleLoader.AskComponentValue(in cmp, Console.Write);
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

			cmp.Value = value;

			ConsoleLoader.PrintComplex(
				cmp.GetImpedance(freq), Console.WriteLine);
		}
	}
}
