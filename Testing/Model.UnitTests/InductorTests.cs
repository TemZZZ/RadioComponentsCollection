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
	class InductorTests
	{
		private RadioComponentTests<Inductor> _radioComponentTests
			= new RadioComponentTests<Inductor>();

		// TestCaseData

		public static
			IEnumerable<TestCaseData> ValuePropertyGoodValuesTestCases()
		{
			return RadioComponentTests<Inductor>
				.ValuePropertyGoodValuesTestCases();
		}

		public static
			IEnumerable<TestCaseData> ValuePropertyBadValuesTestCases()
		{
			return RadioComponentTests<Inductor>
				.ValuePropertyBadValuesTestCases();
		}

		public static IEnumerable<TestCaseData>
			GetImpedanceMethodBadFrequenciesTestCases()
		{
			return RadioComponentTests<Inductor>
				.GetImpedanceMethodBadFrequenciesTestCases();
		}

		public static
			IEnumerable<TestCaseData> ConstructorNoParametersTestCase()
		{
			return RadioComponentTests<Inductor>
				.ConstructorNoParametersTestCase();
		}

		public static
			IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
		{
			foreach (var radioComponentValue in
				RadioComponentTests<Inductor>.GoodRadioComponentValues)
			{
				foreach (var frequency in
					RadioComponentTests<Inductor>.GoodFrequencies)
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

		[TestCase("Гн", "Катушка индуктивности", "Индуктивность",
			TestName = "Когда вызываются свойства Unit, Type, Quantity, " +
			"то они должны вернуть значения Гн, Катушка индуктивности, " +
			"Индуктивность соответственно.")]
		public void UnitTypeQuantityProperties_Always_ReturnsValues(
			params string[] expectedValues)
		{
			_radioComponentTests.UnitTypeQuantityProperties_Always_ReturnsValues(
				expectedValues);
		}
	}
}
