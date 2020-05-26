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
		/// <inheritdoc/>
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
			Assert.Equals(actual, expectedImpedance);
		}
	}
}
