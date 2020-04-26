using System;

using ConsoleLoaderModel;

using Lab1Model;


public class MainApp
{
	public static void Main()
	{
		string inputStr = default;

		while (true)
		{
			Console.Write("\nДля выхода из программы введите Q или\n" +
				"введите тип радиокомпонента (R, L или C): ");

			inputStr = Console.ReadLine();

			if (inputStr.ToUpper() == "Q")
			{
				return;
			}

			ComponentBase cmp = default;
			cmp = ConsoleLoader.GetComponent(inputStr, Console.WriteLine);

			if (cmp != null)
			{
				ConsoleLoader.AskComponentValue(in cmp, Console.Write);
				inputStr = Console.ReadLine();

				double value;
				value = ConsoleLoader.StringToDouble(inputStr, Console.WriteLine);

				if (value < 0)
				{
					Console.WriteLine("Значение физической величины " +
						"не может быть меньше нуля.");

					continue;
				}

				if (value == double.NaN)
				{
					continue;
				}

				Console.Write("Введите частоту в герцах: ");
				inputStr = Console.ReadLine();

				double freq;
				freq = ConsoleLoader.StringToDouble(inputStr, Console.WriteLine);

				if (freq < 0)
				{
					Console.WriteLine("Значение частоты " +
						"не может быть меньше нуля.");

					continue;
				}

				if (freq == double.NaN)
				{
					continue;
				}

				cmp.Value = value;

				double im = cmp.GetImpedance(freq).Imaginary;

				char sign = '+';

				if (im < 0)
				{
					sign = '-';
				}

				Console.WriteLine($"Импеданс равен " +
					$"{cmp.GetImpedance(freq).Real} {sign} " +
					$"{Math.Abs(im)}j Ом");
			}
		}
	}
}
