using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;

namespace Model.UnitTests
{
	/// <summary>
	/// Набор общих тестовых методов и тестовых случаев
	/// для классов-наследников <see cref="RadiocomponentBase_"/>
	/// </summary>
	/// <typeparam name="T">Класс-наследник <see cref="RadiocomponentBase_"/>
	/// </typeparam>
	[TestFixture(typeof(Resistor))]
	[TestFixture(typeof(Inductor))]
	[TestFixture(typeof(Capacitor))]
	public class RadiocomponentTests_<T> where T : RadiocomponentBase_, new()
	{
		public const double MinRadiocomponentValue = 0;
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

		public static double[] GoodRadiocomponentValues => _goodDoubles;
		public static double[] GoodFrequencies => _goodDoubles;

		private T GetRadiocomponent(double radiocomponentValue = 0)
		{
			return new T()
			{
				Value = radiocomponentValue
			};
		}

		#region TestCaseSources that are common for all radiocomponents
		public static
			IEnumerable<TestCaseData> ValuePropertyGoodValuesTestCases()
		{
			foreach (var radiocomponentValue in GoodRadiocomponentValues)
			{
				yield return new TestCaseData(radiocomponentValue)
					.SetName($"Когда свойству " +
					$"{nameof(RadiocomponentBase_.Value)} объекта типа " +
					$"{typeof(T).Name} присваивается значение " +
					$"{radiocomponentValue}, то свойство " +
					$"{nameof(RadiocomponentBase_.Value)} должно стать " +
                    $"равным {radiocomponentValue}.");
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
					$"{nameof(RadiocomponentBase_.Value)} объекта типа " +
					$"{typeof(T).Name} присваивается значение " +
					$"{doubleToExpectedExceptionType.Key}, то должно " +
					$"выбрасываться исключение " +
					$"{doubleToExpectedExceptionType.Value.Name}.");
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
					$"{nameof(RadiocomponentBase_.GetImpedance)} объекта " +
                    $"типа {typeof(T).Name} передается значение частоты " +
					$"{doubleToExpectedExceptionType.Key}, то должно " +
					$"выбрасываться исключение " +
					$"{doubleToExpectedExceptionType.Value.Name}.");
			}
		}

		public static
			IEnumerable<TestCaseData> ConstructorNoParametersTestCase()
		{
			yield return new TestCaseData().SetName($"Когда объект типа " +
				$"{typeof(T).Name} создается конструтором без параметров, " +
				$"то свойство {nameof(RadiocomponentBase_.Value)} объекта " +
				$"должно стать равным 0.");
		}

		public static
			IEnumerable<TestCaseData> UnitTypeQuantityPropertiesTestCases(
				RadiocomponentUnit expectedUnit,
                RadiocomponentType_ expectedType,
				RadiocomponentQuantity expectedQuantity)
		{
			string testName = $"Когда вызываются свойства " +
				$"{nameof(RadiocomponentBase_.Unit)}, " +
				$"{nameof(RadiocomponentBase_.Type)}, " +
				$"{nameof(RadiocomponentBase_.Quantity)} объекта типа " +
				$"{typeof(T).Name}, то они должны вернуть значения " +
				$"{expectedUnit}, {expectedType}, {expectedQuantity} " +
				$"соответственно.";

			yield return new TestCaseData(expectedUnit, expectedType,
				expectedQuantity).SetName(testName);
		}
		#endregion

		#region TestMethods that are common for all radiocomponents
		[TestCaseSource(nameof(ValuePropertyGoodValuesTestCases))]
		public void ValueProperty_AssignedGoodValue_IsAssigned(double value)
		{
			// Arrange
			var expectedValue = value;
			var radiocomponent = GetRadiocomponent();

			// Act
			radiocomponent.Value = value;
			var actualValue = radiocomponent.Value;

			// Assert
			Assert.AreEqual(expectedValue, actualValue);
		}

		[TestCaseSource(nameof(ValuePropertyBadValuesTestCases))]
		public void ValueProperty_AssignedBadValue_ThrowsExpectedException(
			KeyValuePair<double, Type> doubleToExpectedExceptionType)
		{
			// Arrange
			var radiocomponent = GetRadiocomponent();
			var expectedException = doubleToExpectedExceptionType.Value;

			TestDelegate SetRadiocomponentValue
				= () => radiocomponent.Value
					= doubleToExpectedExceptionType.Key;

			// Assert
			_ = Assert.Throws(expectedException, SetRadiocomponentValue);
		}

		[TestCaseSource(nameof(GetImpedanceMethodBadFrequenciesTestCases))]
		public void GetImpedance_BadFrequency_ThrowsExpectedException(
			KeyValuePair<double, Type> doubleToExpectedExceptionType)
		{
			// Arrange
			var radiocomponent = GetRadiocomponent();
			var expectedException = doubleToExpectedExceptionType.Value;

			TestDelegate GetRadiocomponentImpedance
				= () => radiocomponent.GetImpedance(
					doubleToExpectedExceptionType.Key);

			// Assert
			_ = Assert.Throws(expectedException, GetRadiocomponentImpedance);
		}

		[TestCaseSource(nameof(ConstructorNoParametersTestCase))]
		public void Constructor_NoParameters_SetsDefaultRadiocomponentValue()
		{
			// Arrange
			var radiocomponent = new T();
			double expectedRadiocomponentValue = default;

			// Act
			var actualRadiocomponentValue = radiocomponent.Value;

			// Assert
			Assert.AreEqual(actualRadiocomponentValue,
				expectedRadiocomponentValue);
		}

		public void
			GetImpedance_GoodParametersAssigned_ReturnsExpectedImpedance(
				double frequency, double radiocomponentValue,
				Complex expectedImpedance)
		{
			// Arrange
			var radiocomponent = GetRadiocomponent(radiocomponentValue);

			// Act
			var actualImpedance = radiocomponent.GetImpedance(frequency);

			// Assert
			Assert.AreEqual(actualImpedance, expectedImpedance);
		}

		public void UnitTypeQuantityProperties_Always_ReturnsValues(
			RadiocomponentUnit expectedUnit, RadiocomponentType_ expectedType,
			RadiocomponentQuantity expectedQuantity)
		{
			// Arrange
			var radiocomponent = GetRadiocomponent();

			object[] expectedValues =
			{
				expectedUnit,
				expectedType,
				expectedQuantity
			};

			// Act
			object[] actualValues =
			{
				radiocomponent.Unit,
				radiocomponent.Type,
				radiocomponent.Quantity
			};

			// Assert
			Assert.AreEqual(actualValues, expectedValues);
		}

		public void ToString_Always_ReturnsValue(string expectedString)
		{
			// Arrange
			var radiocomponent = GetRadiocomponent();

			// Act
			var actualString = radiocomponent.ToString();

			// Assert
			Assert.AreEqual(actualString, expectedString);
		}
		#endregion
	}
}
