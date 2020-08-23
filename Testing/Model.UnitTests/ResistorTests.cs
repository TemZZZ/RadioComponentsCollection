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
	public class ResistorTests
	{
		private readonly RadiocomponentTests<Resistor> _radiocomponentTests
			= new RadiocomponentTests<Resistor>();

		private const string _expectedUnitAsString = "Ом";
		private const string _expectedTypeAsString = "Резистор";
		private const string _expectedQuantityAsString = "Сопротивление";

        private const RadiocomponentUnit _expectedUnit
            = RadiocomponentUnit.Ohm;
        private const RadiocomponentType _expectedType
            = RadiocomponentType.Resistor;
        private const RadiocomponentQuantity _expectedQuantity
            = RadiocomponentQuantity.Resistance;

		#region TestCaseSources
		private static
			IEnumerable<TestCaseData> GetImpedanceMethodTestCases()
		{
			foreach (var radiocomponentValue in
				RadiocomponentTests<Resistor>.GoodRadiocomponentValues)
			{
				foreach (var frequency in
					RadiocomponentTests<Resistor>.GoodFrequencies)
				{
					var expectedImpedance
						= new Complex(radiocomponentValue, 0);

					yield return new TestCaseData(frequency,
						radiocomponentValue, expectedImpedance).SetName(
						$"Когда метод {nameof(Resistor.GetImpedance)} " +
						$"резистора со значением сопротивления " +
						$"{radiocomponentValue} вызывается со значением " +
						$"частоты {frequency}, то он должен вернуть " +
						$"{expectedImpedance}.");
				}
			}
		}

		private static
			IEnumerable<TestCaseData> UnitTypeQuantityPropertiesTestCases()
		{
			return RadiocomponentTests<Resistor>
				.UnitTypeQuantityPropertiesTestCases(_expectedUnit,
					_expectedType, _expectedQuantity);
		}

		private static
			IEnumerable<TestCaseData> ToStringTestCases()
		{
			const double defaultValue = 0;
            string expectedString
                = $"{_expectedTypeAsString}; {_expectedQuantityAsString} {defaultValue} " +
                  $"{_expectedUnitAsString}";

			string testName = $"Когда вызывается метод " +
				$"{nameof(Resistor.ToString)} у резистора " +
				$"с сопротивлением {defaultValue}, то он должен вернуть " +
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
