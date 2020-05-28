using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;


namespace Model.UnitTests
{
	/// <summary>
	/// Набор общих тестов для классов, реализующих интерфейс
	/// <see cref="IRadioComponent"/>
	/// </summary>
	/// <typeparam name="T">Класс, реализующий интерфейс
	/// <see cref="IRadioComponent"/></typeparam>
	[TestFixture]
	public abstract class RadioComponentBaseTests<T>
		where T : IRadioComponent
	{
		protected const double MinRadioComponentValue = 0;
		protected const double MinFrequency = 0;

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

		protected static double[] GoodRadioComponentValues => _goodDoubles;
		protected static double[] GoodFrequencies => _goodDoubles;

		protected T GetRadioComponent(double radioComponentValue = 0)
		{
			return (T)Activator.CreateInstance(typeof(T),
				radioComponentValue);
		}

		protected static
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

		protected static
			IEnumerable<TestCaseData> ValuePropertyBadValuesTestCases()
		{
			foreach (var doubleToExpectedExceptionType
				in _badDoubleToExpectedExceptionTypeMap)
			{
				yield return new TestCaseData(doubleToExpectedExceptionType)
					.SetName($"Когда свойству Value присваивается " +
					$"значение {doubleToExpectedExceptionType.Key}, " +
					$"то должно выбрасываться исключение " +
					$"{doubleToExpectedExceptionType.Value}.");
			}
		}

		protected static
			IEnumerable<TestCaseData> GetImpedanceMethodBadFrequenciesTestCases()
		{
			foreach (var doubleToExpectedExceptionType
				in _badDoubleToExpectedExceptionTypeMap)
			{
				yield return new TestCaseData(doubleToExpectedExceptionType)
					.SetName($"Когда в метод GetImpedance передается " +
					$"значение частоты {doubleToExpectedExceptionType.Key}, " +
					$"то должно выбрасываться исключение " +
					$"{doubleToExpectedExceptionType.Value}.");
			}
		}

		[Test, TestCaseSource("ValuePropertyGoodValuesTestCases")]
		public void ValueProperty_AssignedGoodValues_IsAssigned(double value)
		{
			// Setup
			var expected = value;

			// Act
			var radioComponent = new T
			{
				Value = value
			};
			var actual = radioComponent.Value;

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test, TestCaseSource("ValuePropertyBadValuesTestCases")]
		public void ValueProperty_AssignedBadValues_ThrowsExpectedException(
			KeyValuePair<double, Type> doubleToExpectedExceptionType)
		{
			// Setup
			var radioComponent = new T();

			// Assert
			_ = Assert.Throws(doubleToExpectedExceptionType.Value,
				() => radioComponent.Value
					= doubleToExpectedExceptionType.Key);
		}

		[Test, TestCaseSource("GetImpedanceMethodBadFrequenciesTestCases")]
		public void GetImpedance_BadFrequencies_ThrowsExpectedException(
			KeyValuePair<double, Type> doubleToExpectedExceptionType)
		{
			// Setup
			var radioComponent = new T();

			// Assert
			_ = Assert.Throws(doubleToExpectedExceptionType.Value,
				() => radioComponent.GetImpedance(
					doubleToExpectedExceptionType.Key));
		}

		public abstract
			void GetImpedance_GoodValuesAndFrequencies_ReturnsValue(
				double value, double frequency, Complex expectedImpedance);
	}
}
