using System;
using NUnit.Framework;
using Model.PassiveComponents;


namespace Model.UnitTests
{
	[TestFixture]
	class RadioComponentFactoryTests
	{
		[TestCase(RadioComponentType.Resistor, 500, typeof(Resistor))]
		[TestCase(RadioComponentType.Inductor, 500, typeof(Inductor))]
		[TestCase(RadioComponentType.Capacitor, 500, typeof(Capacitor))]
		public void
			CreateRadioComponent_PassedGoodValues_ReturnsObjectOfExpectedType(
				RadioComponentType radioComponentType,
				double radioComponentValue, Type expectedType)
		{
			// Arrange
			var radioComponentFactory = new RadioComponentFactory();

			// Act
			object actualObject = radioComponentFactory.CreateRadioComponent(
				radioComponentType, radioComponentValue);

			// Assert
			Assert.AreEqual(actualObject.GetType(), expectedType);
		}
	}
}
