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
		private readonly RadioComponentTests<Capacitor> _radioComponentTests
			= new RadioComponentTests<Capacitor>();

		private const string _expectedUnit = "Ф";
		private const string _expectedType = "Конденсатор";
		private const string _expectedQuantity = "Емкость";

		#region TestCaseSources
		private static
			IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
		{
			TestCaseData GetImpedanceTestCaseData(double frequency,
				double radioComponentValue, Complex expectedImpedance)
			{
				return new TestCaseData(frequency, radioComponentValue,
					expectedImpedance).SetName($"Когда метод " +
					$"{nameof(Capacitor.GetImpedance)} конденсатора со " +
					$"значением емкости {radioComponentValue} вызывается " +
					$"со значением частоты {frequency}, то он должен " +
					$"вернуть {expectedImpedance}.");
			}

			var onlyNegativeInfinityImaginaryComplex
				= new Complex(0, double.NegativeInfinity);
			var minRadioComponentValue
				= RadioComponentTests<Capacitor>.MinRadioComponentValue;
			var minFrequency
				= RadioComponentTests<Capacitor>.MinFrequency;

			foreach (var frequency in
				RadioComponentTests<Capacitor>.GoodFrequencies)
			{
				yield return GetImpedanceTestCaseData(frequency,
					minRadioComponentValue,
					onlyNegativeInfinityImaginaryComplex);
			}

			foreach (var radioComponentValue in
				RadioComponentTests<Capacitor>.GoodRadioComponentValues)
			{
				yield return GetImpedanceTestCaseData(minFrequency,
					radioComponentValue,
					onlyNegativeInfinityImaginaryComplex);
			}

			var goodFrequencies
				= RadioComponentTests<Capacitor>.GoodFrequencies;
			var goodRadioComponentValues
				= RadioComponentTests<Capacitor>.GoodRadioComponentValues;

			for (int i = 1; i < goodFrequencies.Length; ++i)
			{
				for (int j = 1; j < goodRadioComponentValues.Length; ++j)
				{
					var frequency = goodFrequencies[i];
					var radioComponentValue = goodRadioComponentValues[j];
					var expectedImpedance = new Complex(0,
						-1 / (2 * Math.PI * (frequency * radioComponentValue)));

					yield return GetImpedanceTestCaseData(frequency,
						radioComponentValue, expectedImpedance);
				}
			}
		}

		private static
			IEnumerable<TestCaseData> UnitTypeQuantityPropertiesTestCases()
		{
			return RadioComponentTests<Capacitor>
				.UnitTypeQuantityPropertiesTestCases(_expectedUnit,
					_expectedType, _expectedQuantity);
		}

		private static
			IEnumerable<TestCaseData> ToStringTestCases()
		{
			const double defaultValue = 0;
			string expectedString = $"Тип: {_expectedType}; " +
				$"{_expectedQuantity} = {defaultValue} {_expectedUnit}";

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
				double frequency, double radioComponentValue,
				Complex expectedImpedance)
		{
			_radioComponentTests
				.GetImpedance_GoodParametersAssigned_ReturnsExpectedImpedance(
					frequency, radioComponentValue, expectedImpedance);
		}

		[TestCaseSource(nameof(UnitTypeQuantityPropertiesTestCases))]
		public void UnitTypeQuantityProperties_Always_ReturnsValues(
			string expectedUnit, string expectedType,
			string expectedQuantity)
		{
			_radioComponentTests
				.UnitTypeQuantityProperties_Always_ReturnsValues(
					expectedUnit, expectedType, expectedQuantity);
		}

		[TestCaseSource(nameof(ToStringTestCases))]
		public void ToString_Always_ReturnsValue(string expectedString)
		{
			_radioComponentTests.ToString_Always_ReturnsValue(
				expectedString);
		}
		#endregion
	}
}
