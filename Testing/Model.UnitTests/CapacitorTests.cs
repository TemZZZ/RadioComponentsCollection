using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Model.PassiveComponents;


namespace Model.UnitTests
{
	/// <summary>
	/// Набор тестов для класса <see cref="Capacitor"/>
	/// </summary>
	[TestFixture]
	class CapacitorTests : IRadioComponentTestsBase<Capacitor>
	{
		private static
			IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
		{
			var onlyNegativeInfinityImaginaryComplex
				= new Complex(0, double.NegativeInfinity);

			foreach (var frequency in GoodFrequencies)
			{
				yield return new TestCaseData(frequency,
					MinRadioComponentValue,
					onlyNegativeInfinityImaginaryComplex).SetName(
					$"Когда метод GetImpedance конденсатора со значением " +
					$"емкости {MinRadioComponentValue} вызывается со " +
					$"значением частоты {frequency}, то он должен вернуть " +
					$"{onlyNegativeInfinityImaginaryComplex}.");
			}

			foreach (var radioComponentValue in GoodRadioComponentValues)
			{
				yield return new TestCaseData(MinFrequency,
					radioComponentValue,
					onlyNegativeInfinityImaginaryComplex).SetName(
					$"Когда метод GetImpedance конденсатора со значением " +
					$"емкости {radioComponentValue} вызывается со " +
					$"значением частоты {MinFrequency}, то он должен " +
					$"вернуть {onlyNegativeInfinityImaginaryComplex}.");
			}

			for (int i = 1; i < GoodFrequencies.Length; ++i)
			{
				for (int j = 1; j < GoodRadioComponentValues.Length; ++j)
				{
					var frequency = GoodFrequencies[i];
					var radioComponentValue = GoodRadioComponentValues[j];
					var expectedImpedance = new Complex(0,
						-1 / (2 * Math.PI * (frequency * radioComponentValue)));

					yield return new TestCaseData(frequency,
						radioComponentValue, expectedImpedance).SetName(
						$"Когда метод GetImpedance конденсатора со " +
						$"значением емкости {radioComponentValue} " +
						$"вызывается со значением частоты {frequency}, " +
						$"то он должен вернуть {expectedImpedance}.");
				}
			}
		}

		[Test, TestCaseSource("GetImpedanceMethodTestCases")]
		public override void
			GetImpedance_GoodFrequencyForRadioComponentWithAssignedGoodValueToValueProperty_ReturnsExpectedImpedance(
				double frequency, double radioComponentValue,
				Complex expectedImpedance)
		{
			base.GetImpedance_GoodFrequencyForRadioComponentWithAssignedGoodValueToValueProperty_ReturnsExpectedImpedance(
				frequency, radioComponentValue, expectedImpedance);
		}
	}
}
