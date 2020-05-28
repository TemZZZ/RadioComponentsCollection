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
		static IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
		{
			foreach (var radioComponentValue in GoodRadioComponentValues)
			{
				foreach (var frequency in GoodFrequencies)
				{
					var expectedImpedance
						= new Complex(radioComponentValue, 0);

					yield return new TestCaseData(frequency,
						radioComponentValue, expectedImpedance).SetName(
						$"Когда метод GetImpedance резистора со значением " +
						$"сопротивления {radioComponentValue} вызывается " +
						$"со значением частоты {frequency}, то  он должен " +
						$"вернуть {expectedImpedance}");
				}
			}
		}

		[Test, TestCaseSource("TestCasesForGetImpedanceMethod")]
		public override
			void GetImpedance_GoodFrequencyForRadioComponentWithAssignedGoodValueToValueProperty_ReturnsExpectedImpedance(
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
