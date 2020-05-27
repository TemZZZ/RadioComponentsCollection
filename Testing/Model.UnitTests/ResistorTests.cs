using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Model.PassiveComponents;


namespace Model.UnitTests
{
	/// <summary>
	/// Набор тестов для класса <see cref="Resistor"/>
	/// </summary>
	class ResistorTests : RadioComponentBaseTests<Resistor>
	{
		/// <summary>
		/// Формирует и возвращает перечислитель позитивных тестовых
		/// случаев для метода <see cref="Resistor.GetImpedance(double)"/>
		/// </summary>
		/// <returns>Перечислитель наборов значений
		/// "сопротивление, частота, импеданс"</returns>
		static IEnumerable<TestCaseData> TestCasesForGetImpedanceMethod()
		{
			double[] radioComponentValues =
			{
				MinRadioComponentValue,
				MinRadioComponentValue + 1,
				double.MaxValue - 1,
				double.MaxValue
			};

			double[] frequencies =
			{
				MinFrequency,
				MinFrequency + 1,
				double.MaxValue - 1,
				double.MaxValue
			};

			foreach (var radioComponentValue in radioComponentValues)
			{
				foreach (var frequency in frequencies)
				{
					var expectedImpedance
						= new Complex(radioComponentValue, 0);

					yield return new TestCaseData(radioComponentValue,
						frequency, expectedImpedance).SetName($"Когда " +
						$"метод GetImpedance резистора со значением " +
						$"сопротивления {radioComponentValue} вызывается " +
						$"со значением частоты {frequency}, то  он должен " +
						$"вернуть {expectedImpedance}");
				}
			}
		}

		/// <inheritdoc/>
		[Test, TestCaseSource("TestCasesForGetImpedanceMethod")]
		public override
			void GetImpedance_GoodValuesAndFrequencies_ReturnsValue(
				double value, double frequency, Complex expectedImpedance)
		{
			// Setup
			var resistor = new Resistor
			{
				Value = value
			};

			// Act
			var actual = resistor.GetImpedance(frequency);

			// Assert
			Assert.AreEqual(actual, expectedImpedance);
		}
	}
}
