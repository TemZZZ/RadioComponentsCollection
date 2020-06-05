using System;
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
	class ResistorTests
	{
		private RadioComponentTests<Resistor> _radioComponentTests
			= new RadioComponentTests<Resistor>();

		// TestCaseData

		public static
			IEnumerable<TestCaseData> ValuePropertyGoodValuesTestCases()
		{
			return RadioComponentTests<Resistor>
				.ValuePropertyGoodValuesTestCases();
		}

		public static
			IEnumerable<TestCaseData> ValuePropertyBadValuesTestCases()
		{
			return RadioComponentTests<Resistor>
				.ValuePropertyBadValuesTestCases();
		}

		public static IEnumerable<TestCaseData>
			GetImpedanceMethodBadFrequenciesTestCases()
		{
			return RadioComponentTests<Resistor>
				.GetImpedanceMethodBadFrequenciesTestCases();
		}

		public static
			IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
		{
			foreach (var radioComponentValue in
				RadioComponentTests<Resistor>.GoodRadioComponentValues)
			{
				foreach (var frequency in
					RadioComponentTests<Resistor>.GoodFrequencies)
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

		public static
			IEnumerable<TestCaseData> ConstructorNoParametersTestCase()
		{
			return RadioComponentTests<Resistor>
				.ConstructorNoParametersTestCase();
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

		[TestCase("Ом", "Резистор", "Сопротивление",
			TestName = "Когда вызываются свойства Unit, Type, Quantity, " +
			"то они должны вернуть значения Ом, Резистор, Сопротивление " +
			"соответственно.")]
		public void UnitTypeQuantityProperties_Always_ReturnsValues(
			params string[] expectedValues)
		{
			_radioComponentTests.UnitTypeQuantityProperties_Always_ReturnsValues(
				expectedValues);
		}

		[TestCaseSource("ConstructorNoParametersTestCase")]
		public void Constructor_NoParameters_SetsDefaultRadioComponentValue()
		{
			_radioComponentTests
				.Constructor_NoParameters_SetsDefaultRadioComponentValue();
		}

		[TestCase("Тип: Резистор; Сопротивление = 0 Ом",
			TestName = "Когда вызывается метод ToString у резистора " +
			"с сопротивлением 0, то он должен вернуть Тип: Резистор; " +
			"Сопротивление = 0 Ом")]
		public void ToString_Always_ReturnsValue(string expectedString)
		{
			_radioComponentTests.ToString_Always_ReturnsValue(expectedString);
		}
	}
}
