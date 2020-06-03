using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Model.PassiveComponents;


namespace Model.UnitTests
{
	/// <summary>
	/// Набор тестов для класса <see cref="Inductor"/>
	/// </summary>
	[TestFixture]
	class InductorTests : IRadioComponentTestsBase<Inductor>
	{
		private static
			IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
		{
			foreach (var radioComponentValue in GoodRadioComponentValues)
			{
				foreach (var frequency in GoodFrequencies)
				{
					var expectedImpedance
						= new Complex(0,
							2 * Math.PI * (frequency * radioComponentValue));

					yield return new TestCaseData(frequency,
						radioComponentValue, expectedImpedance).SetName(
						$"Когда метод GetImpedance катушки индуктивности " +
						$"со значением индуктивности " +
						$"{radioComponentValue} вызывается со значением " +
						$"частоты {frequency}, то он должен вернуть " +
						$"{expectedImpedance}.");
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
