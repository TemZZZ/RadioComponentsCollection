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
		private RadioComponentTests<Capacitor> _radioComponentTests
			= new RadioComponentTests<Capacitor>();

		// TestCaseData

		public static
			IEnumerable<TestCaseData> ValuePropertyGoodValuesTestCases()
		{
			return RadioComponentTests<Capacitor>
				.ValuePropertyGoodValuesTestCases();
		}

		public static
			IEnumerable<TestCaseData> ValuePropertyBadValuesTestCases()
		{
			return RadioComponentTests<Capacitor>
				.ValuePropertyBadValuesTestCases();
		}

		public static IEnumerable<TestCaseData>
			GetImpedanceMethodBadFrequenciesTestCases()
		{
			return RadioComponentTests<Capacitor>
				.GetImpedanceMethodBadFrequenciesTestCases();
		}

		public static
			IEnumerable<TestCaseData> ConstructorNoParametersTestCase()
		{
			return RadioComponentTests<Capacitor>
				.ConstructorNoParametersTestCase();
		}

		public static
			IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
		{
			var onlyNegativeInfinityImaginaryComplex
				= new Complex(0, double.NegativeInfinity);
			var minRadioComponentValue
				= RadioComponentTests<Capacitor>.MinRadioComponentValue;
			var minFrequency
				= RadioComponentTests<Capacitor>.MinFrequency;

			foreach (var frequency in
				RadioComponentTests<Capacitor>.GoodFrequencies)
			{
				yield return new TestCaseData(frequency,
					minRadioComponentValue,
					onlyNegativeInfinityImaginaryComplex).SetName(
					$"Когда метод GetImpedance конденсатора со значением " +
					$"емкости {minRadioComponentValue} вызывается со " +
					$"значением частоты {frequency}, то он должен вернуть " +
					$"{onlyNegativeInfinityImaginaryComplex}.");
			}

			foreach (var radioComponentValue in
				RadioComponentTests<Capacitor>.GoodRadioComponentValues)
			{
				yield return new TestCaseData(minFrequency,
					radioComponentValue,
					onlyNegativeInfinityImaginaryComplex).SetName(
					$"Когда метод GetImpedance конденсатора со значением " +
					$"емкости {radioComponentValue} вызывается со " +
					$"значением частоты {minFrequency}, то он должен " +
					$"вернуть {onlyNegativeInfinityImaginaryComplex}.");
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

					yield return new TestCaseData(frequency,
						radioComponentValue, expectedImpedance).SetName(
						$"Когда метод GetImpedance конденсатора со " +
						$"значением емкости {radioComponentValue} " +
						$"вызывается со значением частоты {frequency}, " +
						$"то он должен вернуть {expectedImpedance}.");
				}
			}
		}

		// Tests

		[TestCaseSource("ValuePropertyGoodValuesTestCases")]
		public void ValueProperty_AssignedGoodValue_IsAssigned(double value)
		{
			_radioComponentTests
				.ValueProperty_AssignedGoodValue_IsAssigned(value);
		}

		[TestCaseSource("ValuePropertyBadValuesTestCases")]
		public void ValueProperty_AssignedBadValue_ThrowsExpectedException(
			KeyValuePair<double, Type> doubleToExpectedExceptionType)
		{
			_radioComponentTests
				.ValueProperty_AssignedBadValue_ThrowsExpectedException(
					doubleToExpectedExceptionType);
		}

		[TestCaseSource("GetImpedanceMethodBadFrequenciesTestCases")]
		public void GetImpedance_BadFrequency_ThrowsExpectedException(
			KeyValuePair<double, Type> doubleToExpectedExceptionType)
		{
			_radioComponentTests
				.GetImpedance_BadFrequency_ThrowsExpectedException(
					doubleToExpectedExceptionType);
		}

		[TestCaseSource("ConstructorNoParametersTestCase")]
		public void Constructor_NoParameters_SetsDefaultRadioComponentValue()
		{
			_radioComponentTests
				.Constructor_NoParameters_SetsDefaultRadioComponentValue();
		}

		[TestCaseSource("GetImpedanceMethodTestCases")]
		public void
			GetImpedance_GoodParametersAssigned_ReturnsExpectedImpedance(
				double frequency, double radioComponentValue,
				Complex expectedImpedance)
		{
			_radioComponentTests
				.GetImpedance_GoodParametersAssigned_ReturnsExpectedImpedance(
					frequency, radioComponentValue, expectedImpedance);
		}

		[TestCase("Ф", "Конденсатор", "Емкость",
			TestName = "Когда вызываются свойства Unit, Type, Quantity, " +
			"то они должны вернуть значения Ф, Конденсатор, Емкость " +
			"соответственно.")]
		public void UnitTypeQuantityProperties_Always_ReturnsValues(
			params string[] expectedValues)
		{
			_radioComponentTests.UnitTypeQuantityProperties_Always_ReturnsValues(
				expectedValues);
		}
	}
}
