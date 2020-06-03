using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Model.PassiveComponents;


namespace Model.UnitTests
{
	/// <summary>
	/// Набор тестов для класса <see cref="Resistor"/>
	/// </summary>
	[TestFixture]
	class ResistorTests : RadioComponentBaseTests<Resistor>
	{
		private static
			IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
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
						$"со значением частоты {frequency}, то он должен " +
						$"вернуть {expectedImpedance}.");
				}
			}
		}

		[Test, TestCaseSource("GetImpedanceMethodTestCases")]
		public override void
			GetImpedance_GoodParametersAssigned_ReturnsExpectedImpedance(
				double frequency, double radioComponentValue,
				Complex expectedImpedance)
		{
			base.GetImpedance_GoodParametersAssigned_ReturnsExpectedImpedance(
				frequency, radioComponentValue, expectedImpedance);
		}
	}
}
