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
	class CapacitorTests
	{
		private readonly RadiocomponentTests<Capacitor> _radiocomponentTests
			= new RadiocomponentTests<Capacitor>();

		private const string _expectedUnit = "Ф";
		private const string _expectedType = "Конденсатор";
		private const string _expectedQuantity = "Емкость";

		#region TestCaseSources
		private static
			IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
		{
			TestCaseData GetImpedanceTestCaseData(double frequency,
				double radiocomponentValue, Complex expectedImpedance)
			{
				return new TestCaseData(frequency, radiocomponentValue,
					expectedImpedance).SetName($"Когда метод " +
					$"{nameof(Capacitor.GetImpedance)} конденсатора со " +
					$"значением емкости {radiocomponentValue} вызывается " +
					$"со значением частоты {frequency}, то он должен " +
					$"вернуть {expectedImpedance}.");
			}

			var onlyNegativeInfinityImaginaryComplex
				= new Complex(0, double.NegativeInfinity);
			var minRadiocomponentValue
				= RadiocomponentTests<Capacitor>.MinRadiocomponentValue;
			var minFrequency
				= RadiocomponentTests<Capacitor>.MinFrequency;

			foreach (var frequency in
				RadiocomponentTests<Capacitor>.GoodFrequencies)
			{
				yield return GetImpedanceTestCaseData(frequency,
					minRadiocomponentValue,
					onlyNegativeInfinityImaginaryComplex);
			}

			foreach (var radiocomponentValue in
				RadiocomponentTests<Capacitor>.GoodRadiocomponentValues)
			{
				yield return GetImpedanceTestCaseData(minFrequency,
					radiocomponentValue,
					onlyNegativeInfinityImaginaryComplex);
			}

			var goodFrequencies
				= RadiocomponentTests<Capacitor>.GoodFrequencies;
			var goodRadiocomponentValues
				= RadiocomponentTests<Capacitor>.GoodRadiocomponentValues;

			for (int i = 1; i < goodFrequencies.Length; ++i)
			{
				for (int j = 1; j < goodRadiocomponentValues.Length; ++j)
				{
					var frequency = goodFrequencies[i];
					var radiocomponentValue = goodRadiocomponentValues[j];
					var expectedImpedance = new Complex(0,
						-1 / (2 * Math.PI * (frequency * radiocomponentValue)));

					yield return GetImpedanceTestCaseData(frequency,
						radiocomponentValue, expectedImpedance);
				}
			}
		}

		private static
			IEnumerable<TestCaseData> UnitTypeQuantityPropertiesTestCases()
		{
			return RadiocomponentTests<Capacitor>
				.UnitTypeQuantityPropertiesTestCases(_expectedUnit,
					_expectedType, _expectedQuantity);
		}

		private static
			IEnumerable<TestCaseData> ToStringTestCases()
		{
			const double defaultValue = 0;
            string expectedString
                = $"{_expectedType}; {_expectedQuantity} {defaultValue} " +
                  $"{_expectedUnit}";

			string testName = $"Когда вызывается метод " +
				$"{nameof(Capacitor.ToString)} у конденсатора с емкостью " +
				$"{defaultValue}, то он должен вернуть {expectedString}";

			yield return new TestCaseData(expectedString).SetName(testName);
		}
		#endregion

		#region Tests
		[TestCaseSource(nameof(GetImpedanceMethodTestCases))]
		public void
			GetImpedance_GoodParametersAssigned_ReturnsExpectedImpedance(
				double frequency, double radiocomponentValue,
				Complex expectedImpedance)
		{
			_radiocomponentTests
				.GetImpedance_GoodParametersAssigned_ReturnsExpectedImpedance(
					frequency, radiocomponentValue, expectedImpedance);
		}

		[TestCaseSource(nameof(UnitTypeQuantityPropertiesTestCases))]
		public void UnitTypeQuantityProperties_Always_ReturnsValues(
			RadiocomponentUnit expectedUnit, RadiocomponentType expectedType,
			RadiocomponentQuantity expectedQuantity)
		{
			_radiocomponentTests
				.UnitTypeQuantityProperties_Always_ReturnsValues(
					expectedUnit, expectedType, expectedQuantity);
		}

		[TestCaseSource(nameof(ToStringTestCases))]
		public void ToString_Always_ReturnsValue(string expectedString)
		{
			_radiocomponentTests.ToString_Always_ReturnsValue(
				expectedString);
		}
		#endregion
	}
}
