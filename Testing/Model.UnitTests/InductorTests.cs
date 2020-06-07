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
		private readonly RadioComponentTests<Inductor> _radioComponentTests
			= new RadioComponentTests<Inductor>();

		private const string _expectedUnit = "Гн";
		private const string _expectedType = "Катушка индуктивности";
		private const string _expectedQuantity = "Индуктивность";

		// TestCaseSources

		private static
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
						$"Когда метод {nameof(Inductor.GetImpedance)} " +
						$"катушки индуктивности со значением " +
						$"индуктивности {radioComponentValue} вызывается " +
						$"со значением частоты {frequency}, то он должен " +
						$"вернуть {expectedImpedance}.");
				}
			}
		}

		private static
			IEnumerable<TestCaseData> UnitTypeQuantityPropertiesTestCases()
		{
			string testName = $"Когда вызываются свойства " +
				$"{nameof(Inductor.Unit)}, {nameof(Inductor.Type)}, " +
				$"{nameof(Inductor.Quantity)}, то они должны вернуть " +
				$"значения {_expectedUnit}, {_expectedType}, " +
				$"{_expectedQuantity} соответственно.";

			yield return new TestCaseData(_expectedUnit, _expectedType,
				_expectedQuantity).SetName(testName);
		}

		private static
			IEnumerable<TestCaseData> ToStringTestCases()
		{
			const double defaultValue = 0;
			string expectedString = $"Тип: {_expectedType}; " +
				$"{_expectedQuantity} = {defaultValue} {_expectedUnit}";

			string testName = $"Когда вызывается метод " +
				$"{nameof(Inductor.ToString)} у катушки индуктивности " +
				$"с индуктивностью {defaultValue}, то он должен вернуть " +
				$"{expectedString}";

			yield return new TestCaseData(expectedString).SetName(testName);
		}

		// Tests

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
	}
}
