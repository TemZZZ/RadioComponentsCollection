using System;
using System.Collections.Generic;
using System.Numerics;
using Model.PassiveComponents;
using NUnit.Framework;


namespace Model.UnitTests
{
	/// <summary>
	/// Набор общих тестовых методов и тестовых случаев
	/// для классов, реализующих интерфейс
	/// <see cref="IRadioComponent"/>
	/// </summary>
	/// <typeparam name="T">Класс, реализующий интерфейс
	/// <see cref="IRadioComponent"/></typeparam>
	[TestFixture(typeof(Resistor))]
	[TestFixture(typeof(Inductor))]
	[TestFixture(typeof(Capacitor))]
	public class RadioComponentTests<T> where T : IRadioComponent, new()
	{
		public const double MinRadioComponentValue = 0;
		public const double MinFrequency = 0;

		private static readonly double[] _goodDoubles
			= { 0, 1, double.MaxValue };

		private static readonly
			Dictionary<double, Type> _badDoubleToExpectedExceptionTypeMap
				= new Dictionary<double, Type>
				{
					[double.NegativeInfinity]
						= typeof(ArgumentOutOfRangeException),
					[-1] = typeof(ArgumentOutOfRangeException),
					[double.PositiveInfinity]
						= typeof(ArgumentOutOfRangeException),
					[double.NaN] = typeof(ArgumentException)
				};

		public static double[] GoodRadioComponentValues => _goodDoubles;
		public static double[] GoodFrequencies => _goodDoubles;

		private T GetRadioComponent(double radioComponentValue = 0)
		{
			return new T()
			{
				Value = radioComponentValue
			};
		}

		// TestCaseSources that are common for all radiocomponents

		public static
			IEnumerable<TestCaseData> ValuePropertyGoodValuesTestCases()
		{
			foreach (var radioComponentValue in GoodRadioComponentValues)
			{
				yield return new TestCaseData(radioComponentValue)
					.SetName($"Когда свойству " +
					$"{nameof(IRadioComponent.Value)} объекта типа " +
					$"{nameof(T)} присваивается значение " +
					$"{radioComponentValue}, то свойство " +
					$"{nameof(IRadioComponent.Value)} должно стать равным " +
					$"{radioComponentValue}.");
			}
		}

		public static
			IEnumerable<TestCaseData> ValuePropertyBadValuesTestCases()
		{
			foreach (var doubleToExpectedExceptionType
				in _badDoubleToExpectedExceptionTypeMap)
			{
				yield return new TestCaseData(doubleToExpectedExceptionType)
					.SetName($"Когда свойству " +
					$"{nameof(IRadioComponent.Value)} объекта типа " +
					$"{nameof(T)} присваивается значение " +
					$"{doubleToExpectedExceptionType.Key}, то должно " +
					$"выбрасываться исключение " +
					$"{nameof(doubleToExpectedExceptionType.Value)}.");
			}
		}

		public static IEnumerable<TestCaseData>
			GetImpedanceMethodBadFrequenciesTestCases()
		{
			foreach (var doubleToExpectedExceptionType
				in _badDoubleToExpectedExceptionTypeMap)
			{
				yield return new TestCaseData(doubleToExpectedExceptionType)
					.SetName($"Когда в метод " +
					$"{nameof(IRadioComponent.GetImpedance)} объекта типа " +
					$"{nameof(T)} передается значение частоты " +
					$"{doubleToExpectedExceptionType.Key}, то должно " +
					$"выбрасываться исключение " +
					$"{nameof(doubleToExpectedExceptionType.Value)}.");
			}
		}

		public static
			IEnumerable<TestCaseData> ConstructorNoParametersTestCase()
		{
			yield return new TestCaseData().SetName($"Когда объекта типа " +
				$"{nameof(T)} создается конструтором без параметров, то " +
				$"свойство {nameof(IRadioComponent.Value)} объекта должно " +
				$"стать равным 0.");
		}

		// TestMethods that are common for all radiocomponents

		[TestCaseSource(nameof(ValuePropertyGoodValuesTestCases))]
		public void ValueProperty_AssignedGoodValue_IsAssigned(double value)
		{
			// Arrange
			var expectedValue = value;
			var radioComponent = GetRadioComponent();

			// Act
			radioComponent.Value = value;
			var actualValue = radioComponent.Value;

			// Assert
			Assert.AreEqual(expectedValue, actualValue);
		}

		[TestCaseSource(nameof(ValuePropertyBadValuesTestCases))]
		public void ValueProperty_AssignedBadValue_ThrowsExpectedException(
			KeyValuePair<double, Type> doubleToExpectedExceptionType)
		{
			// Arrange
			var radioComponent = GetRadioComponent();
			var expectedException = doubleToExpectedExceptionType.Value;

			TestDelegate SetRadioComponentValue
				= () => radioComponent.Value
					= doubleToExpectedExceptionType.Key;

			// Assert
			_ = Assert.Throws(expectedException, SetRadioComponentValue);
		}

		[TestCaseSource(nameof(GetImpedanceMethodBadFrequenciesTestCases))]
		public void GetImpedance_BadFrequency_ThrowsExpectedException(
			KeyValuePair<double, Type> doubleToExpectedExceptionType)
		{
			// Arrange
			var radioComponent = GetRadioComponent();
			var expectedException = doubleToExpectedExceptionType.Value;

			TestDelegate GetRadioComponentImpedance
				= () => radioComponent.GetImpedance(
					doubleToExpectedExceptionType.Key);

			// Assert
			_ = Assert.Throws(expectedException, GetRadioComponentImpedance);
		}

		[TestCaseSource(nameof(ConstructorNoParametersTestCase))]
		public void Constructor_NoParameters_SetsDefaultRadioComponentValue()
		{
			// Arrange
			var radioComponent = new T();
			double expectedRadioComponentValue = default;

			// Act
			var actualRadioComponentValue = radioComponent.Value;

			// Assert
			Assert.AreEqual(actualRadioComponentValue,
				expectedRadioComponentValue);
		}

		public void
			GetImpedance_GoodParametersAssigned_ReturnsExpectedImpedance(
				double frequency, double radioComponentValue,
				Complex expectedImpedance)
		{
			// Arrange
			var radioComponent = GetRadioComponent(radioComponentValue);

			// Act
			var actualImpedance = radioComponent.GetImpedance(frequency);

			// Assert
			Assert.AreEqual(actualImpedance, expectedImpedance);
		}

		public void UnitTypeQuantityProperties_Always_ReturnsValues(
			params string[] expectedValues)
		{
			// Arrange
			var radioComponent = GetRadioComponent();

			// Act
			string[] actualValues =
			{
				radioComponent.Unit,
				radioComponent.Type,
				radioComponent.Quantity
			};

			// Assert
			Assert.AreEqual(actualValues, expectedValues);
		}

		public void ToString_Always_ReturnsValue(string expectedString)
		{
			// Arrange
			var radioComponent = GetRadioComponent();

			// Act
			var actualString = radioComponent.ToString();

			// Assert
			Assert.AreEqual(actualString, expectedString);
		}
	}
}
