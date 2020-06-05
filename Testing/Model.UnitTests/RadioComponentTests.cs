using System;
using System.Collections.Generic;
using System.Numerics;
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
	public class RadioComponentTests<T> where T : IRadioComponent
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
			return (T)Activator.CreateInstance(typeof(T),
				radioComponentValue);
		}

		public static
			IEnumerable<TestCaseData> ValuePropertyGoodValuesTestCases()
		{
			foreach (var radioComponentValue in GoodRadioComponentValues)
			{
				yield return new TestCaseData(radioComponentValue)
					.SetName($"Когда свойству Value присваивается " +
					$"значение {radioComponentValue}, то свойство Value " +
					$"должно стать равным {radioComponentValue}.");
			}
		}

		public static
			IEnumerable<TestCaseData> ValuePropertyBadValuesTestCases()
		{
			foreach (var doubleToExpectedExceptionType
				in _badDoubleToExpectedExceptionTypeMap)
			{
				yield return new TestCaseData(doubleToExpectedExceptionType)
					.SetName($"Когда свойству Value присваивается " +
					$"значение {doubleToExpectedExceptionType.Key}, " +
					$"то должно выбрасываться исключение " +
					$"{doubleToExpectedExceptionType.Value.Name}.");
			}
		}

		public static
			IEnumerable<TestCaseData> GetImpedanceMethodBadFrequenciesTestCases()
		{
			foreach (var doubleToExpectedExceptionType
				in _badDoubleToExpectedExceptionTypeMap)
			{
				yield return new TestCaseData(doubleToExpectedExceptionType)
					.SetName($"Когда в метод GetImpedance передается " +
					$"значение частоты {doubleToExpectedExceptionType.Key}, " +
					$"то должно выбрасываться исключение " +
					$"{doubleToExpectedExceptionType.Value.Name}.");
			}
		}

		public static
			IEnumerable<TestCaseData> ConstructorNoParametersTestCase()
		{
			yield return new TestCaseData().SetName("Когда вызывается " +
				"конструтор без параметров, то Value должно " +
				"стать равным 0.");
		}

		public void ValueProperty_AssignedGoodValue_IsAssigned(double value)
		{
			// Setup
			var expected = value;
			var radioComponent = GetRadioComponent();

			// Act
			radioComponent.Value = value;
			var actual = radioComponent.Value;

			// Assert
			Assert.AreEqual(expected, actual);
		}

		public void ValueProperty_AssignedBadValue_ThrowsExpectedException(
			KeyValuePair<double, Type> doubleToExpectedExceptionType)
		{
			// Setup
			var radioComponent = GetRadioComponent();
			var expectedException = doubleToExpectedExceptionType.Value;

			TestDelegate SetRadioComponentValue
				= () =>	radioComponent.Value
					= doubleToExpectedExceptionType.Key;

			// Assert
			_ = Assert.Throws(expectedException, SetRadioComponentValue);
		}

		public void GetImpedance_BadFrequency_ThrowsExpectedException(
			KeyValuePair<double, Type> doubleToExpectedExceptionType)
		{
			// Setup
			var radioComponent = GetRadioComponent();
			var expectedException = doubleToExpectedExceptionType.Value;

			TestDelegate GetRadioComponentImpedance
				= () => radioComponent.GetImpedance(
					doubleToExpectedExceptionType.Key);

			// Assert
			_ = Assert.Throws(expectedException, GetRadioComponentImpedance);
		}

		public void
			GetImpedance_GoodParametersAssigned_ReturnsExpectedImpedance(
				double frequency, double radioComponentValue,
				Complex expectedImpedance)
		{
			// Setup
			var radioComponent = GetRadioComponent(radioComponentValue);

			// Act
			var actualImpedance = radioComponent.GetImpedance(frequency);

			// Assert
			Assert.AreEqual(actualImpedance, expectedImpedance);
		}

		public void UnitTypeQuantityProperties_Always_ReturnsValues(
			params string[] expectedValues)
		{
			// Setup
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

		public void Constructor_NoParameters_SetsDefaultRadioComponentValue()
		{
			// Setup
			var radioComponent = (T)Activator.CreateInstance(typeof(T));
			double expectedRadioComponentValue = default;

			// Act
			var actualRadioComponentValue = radioComponent.Value;

			// Assert
			Assert.AreEqual(actualRadioComponentValue,
				expectedRadioComponentValue);
		}
	}
}
