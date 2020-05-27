using System;
using System.Numerics;
using NUnit.Framework;


namespace Model.UnitTests
{
	/// <summary>
	/// Набор тестов, общих для классов, производных от
	/// <see cref="RadioComponentBase"/>
	/// </summary>
	/// <typeparam name="T">Класс, производный от
	/// <see cref="RadioComponentBase"/></typeparam>
	[TestFixture]
	public abstract class RadioComponentBaseTests<T>
		where T : RadioComponentBase, new()
	{
		protected const double MinRadioComponentValue = 0;
		protected const double MinFrequency = 0;

		[Test]
		[TestCase(MinRadioComponentValue,
			TestName = "Когда свойству Value присваивается значение 0, " +
			"то свойство Value должно стать равно 0.")]
		[TestCase(MinRadioComponentValue + 1,
			TestName = "Когда свойству Value присваивается значение 1, " +
			"то свойство Value должно стать равно 1.")]
		[TestCase(double.MaxValue - 1,
			TestName = "Когда свойству Value присваивается значение " +
			"MaxValue - 1, то свойство Value должно стать равно " +
			"MaxValue - 1.")]
		[TestCase(double.MaxValue,
			TestName = "Когда свойству Value присваивается значение " +
			"MaxValue, то свойство Value должно стать равно MaxValue.")]
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

		[Test]
		[TestCase(double.NegativeInfinity,
			typeof(ArgumentOutOfRangeException),
			TestName = "Когда свойству Value присваивается значение " +
			"NegativeInfinity, то должно выбрасываться исключение " +
			"ArgumentOutOfRangeException.")]
		[TestCase(MinRadioComponentValue - 1,
			typeof(ArgumentOutOfRangeException),
			TestName = "Когда свойству Value присваивается значение (-1), " +
			"то должно выбрасываться исключение " +
			"ArgumentOutOfRangeException.")]
		[TestCase(double.PositiveInfinity,
			typeof(ArgumentOutOfRangeException),
			TestName = "Когда свойству Value присваивается значение " +
			"PositiveInfinity, то должно выбрасываться исключение " +
			"ArgumentOutOfRangeException.")]
		[TestCase(double.NaN, typeof(ArgumentException),
			TestName = "Когда свойству Value присваивается значение NaN, " +
			"то должно выбрасываться исключение ArgumentException.")]
		public void ValueProperty_AssignedBadValues_ThrowsExpectedException(
			double value, Type expectedException)
		{
			// Setup
			var radioComponent = new T();

			// Assert
			_ = Assert.Throws(expectedException,
				() => radioComponent.Value = value);
		}

		[Test]
		[TestCase(double.NegativeInfinity,
			typeof(ArgumentOutOfRangeException),
			TestName = "Когда в метод GetImpedance передается значение " +
			"частоты NegativeInfinity, то должно выбрасываться исключение " +
			"ArgumentOutOfRangeException.")]
		[TestCase(MinFrequency - 1, typeof(ArgumentOutOfRangeException),
			TestName = "Когда в метод GetImpedance передается значение " +
			"частоты (-1), то должно выбрасываться исключение " +
			"ArgumentOutOfRangeException.")]
		[TestCase(double.PositiveInfinity,
			typeof(ArgumentOutOfRangeException),
			TestName = "Когда в метод GetImpedance передается значение " +
			"частоты PositiveInfinity, то должно выбрасываться исключение " +
			"ArgumentOutOfRangeException.")]
		[TestCase(double.NaN, typeof(ArgumentException),
			TestName = "Когда в метод GetImpedance передается значение " +
			"частоты NaN, то должно выбрасываться исключение " +
			"ArgumentException.")]
		public void GetImpedance_BadFrequencies_ThrowsExpectedException(
			double frequency, Type expectedException)
		{
			// Setup
			var radioComponent = new T();

			// Assert
			_ = Assert.Throws(expectedException,
				() => radioComponent.GetImpedance(frequency));
		}

		[Test]
		public abstract
			void GetImpedance_GoodValuesAndFrequencies_ReturnsValue(
				double value, double frequency, Complex expectedImpedance);
	}
}
