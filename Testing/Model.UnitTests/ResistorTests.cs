using System.Numerics;
using NUnit.Framework;
using Model.PassiveComponents;


namespace Model.UnitTests
{
	/// <summary>
	/// Набор тестов для класса <see cref="Resistor"/>
	/// </summary>
	class ResistorTests : RadioComponentBaseTests<Resistor>
	{
		static object[] TestCases =
		{
			new object[] { MinRadioComponentValue, MinFrequency,
				new Complex(MinRadioComponentValue, 0) },

			new object[] { MinRadioComponentValue + 1, MinFrequency,
				new Complex(MinRadioComponentValue + 1, 0) },

			new object[] { double.MaxValue, MinFrequency,
				new Complex(double.MaxValue, 0) },

			new object[] { MinRadioComponentValue, MinFrequency + 1,
				new Complex(MinRadioComponentValue, 0) },

			new object[] { MinRadioComponentValue + 1, MinFrequency + 1,
				new Complex(MinRadioComponentValue + 1, 0) },

			new object[] { double.MaxValue, MinFrequency + 1,
				new Complex(double.MaxValue, 0) },

			new object[] { MinRadioComponentValue, double.MaxValue - 1,
				new Complex(MinRadioComponentValue, 0) },

			new object[] { MinRadioComponentValue + 1, double.MaxValue - 1,
				new Complex(MinRadioComponentValue + 1, 0) },

			new object[] { double.MaxValue, double.MaxValue - 1,
				new Complex(double.MaxValue, 0) },

			new object[] { MinRadioComponentValue, double.MaxValue,
				new Complex(MinRadioComponentValue, 0) },

			new object[] { MinRadioComponentValue + 1, double.MaxValue,
				new Complex(MinRadioComponentValue + 1, 0) },

			new object[] { double.MaxValue, double.MaxValue,
				new Complex(double.MaxValue, 0) }
		};

		/// <inheritdoc/>
		[Test]
		[TestCaseSource("TestCases")]
		public override
			void GetImpedance_GoodValuesAndFrequencies_ReturnsValue(
				double value, double frequency, Complex expectedImpedance)
		{
			// Setup
			var resistor = new Resistor
			{
				Value = value
			};

			// Act
			var actual = resistor.GetImpedance(frequency);

			// Assert
			Assert.AreEqual(actual, expectedImpedance);
		}
	}
}
