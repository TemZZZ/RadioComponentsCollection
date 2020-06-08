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
		private readonly RadioComponentTests<Resistor> _radioComponentTests
			= new RadioComponentTests<Resistor>();

		private const string _expectedUnit = "Ом";
		private const string _expectedType = "Резистор";
		private const string _expectedQuantity = "Сопротивление";

		#region TestCaseSources
		private static
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
						$"Когда метод {nameof(Resistor.GetImpedance)} " +
						$"резистора со значением сопротивления " +
						$"{radioComponentValue} вызывается со значением " +
						$"частоты {frequency}, то он должен вернуть " +
						$"{expectedImpedance}.");
				}
			}
		}

		private static
			IEnumerable<TestCaseData> UnitTypeQuantityPropertiesTestCases()
		{
			return RadioComponentTests<Resistor>
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
