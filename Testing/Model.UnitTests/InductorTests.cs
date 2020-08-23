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
		private readonly RadiocomponentTests<Inductor> _radiocomponentTests
			= new RadiocomponentTests<Inductor>();

		private const string _expectedUnitAsString = "Гн";
		private const string _expectedTypeAsString = "Катушка индуктивности";
		private const string _expectedQuantityAsString = "Индуктивность";

        private const RadiocomponentUnit _expectedUnit
            = RadiocomponentUnit.Henry;
        private const RadiocomponentType _expectedType
            = RadiocomponentType.Inductor;
        private const RadiocomponentQuantity _expectedQuantity
            = RadiocomponentQuantity.Inductance;

		#region TestCaseSources
		private static
			IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
		{
			foreach (var radiocomponentValue in
				RadiocomponentTests<Inductor>.GoodRadiocomponentValues)
			{
				foreach (var frequency in
					RadiocomponentTests<Inductor>.GoodFrequencies)
				{
					var expectedImpedance
						= new Complex(0,
							2 * Math.PI * (frequency * radiocomponentValue));

					yield return new TestCaseData(frequency,
						radiocomponentValue, expectedImpedance).SetName(
						$"Когда метод {nameof(Inductor.GetImpedance)} " +
						$"катушки индуктивности со значением " +
						$"индуктивности {radiocomponentValue} вызывается " +
						$"со значением частоты {frequency}, то он должен " +
						$"вернуть {expectedImpedance}.");
				}
			}
		}

		private static
			IEnumerable<TestCaseData> UnitTypeQuantityPropertiesTestCases()
		{
			return RadiocomponentTests<Inductor>
				.UnitTypeQuantityPropertiesTestCases(_expectedUnitAsString,
					_expectedTypeAsString, _expectedQuantityAsString);
		}

		private static
			IEnumerable<TestCaseData> ToStringTestCases()
		{
			const double defaultValue = 0;
            string expectedString
                = $"{_expectedTypeAsString}; {_expectedQuantityAsString} " +
                  $"{defaultValue} {_expectedUnitAsString}";

			string testName = $"Когда вызывается метод " +
				$"{nameof(Inductor.ToString)} у катушки индуктивности " +
				$"с индуктивностью {defaultValue}, то он должен вернуть " +
				$"{expectedString}";

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
