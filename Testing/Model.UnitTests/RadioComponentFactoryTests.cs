using System;
using System.Collections.Generic;
using NUnit.Framework;
using Model.PassiveComponents;


namespace Model.UnitTests
{
	[TestFixture]
	class RadiocomponentFactoryTests
	{
		private static readonly List<(RadiocomponentType radiocomponentType,
			Type type, IRadiocomponent radiocomponent)>
				_radiocomponentInfoDictionary
					= new List<(RadiocomponentType radiocomponentType,
						Type type, IRadiocomponent radiocomponent)>
					{
						(RadiocomponentType.Resistor, typeof(Resistor),
							new Resistor()),
						(RadiocomponentType.Inductor, typeof(Inductor),
							new Inductor()),
						(RadiocomponentType.Capacitor, typeof(Capacitor),
							new Capacitor())
					};

		#region TestCaseSources
		private static
			IEnumerable<TestCaseData> CreateRadiocomponentTestCases()
		{
			foreach (var (radioComponetType, type, _)
				in _radiocomponentInfoDictionary)
			{
				yield return new TestCaseData(radioComponetType, type)
					.SetName($"Когда метод CreateRadiocomponent " +
					$"вызывается с типом {radioComponetType} из " +
					$"перечисления {typeof(RadiocomponentType).Name} и с " +
					$"допустимым значением физической величины " +
					$"радиокомпонента, то он должен вернуть объект типа " +
					$"{radioComponetType}.");
			}
		}

		private static
			IEnumerable<TestCaseData> GetRadiocomponentTypeTestCases()
		{
			foreach (var (radioComponetType, type, radiocomponent)
				in _radiocomponentInfoDictionary)
			{
				yield return new TestCaseData(radiocomponent,
					radioComponetType).SetName($"Когда в метод " +
					$"GetRadiocomponentType передается в качестве " +
					$"параметра объект класса {type.Name}, то он должен " +
					$"вернуть {radioComponetType} из перечисления " +
					$"{typeof(RadiocomponentType).Name}.");
			}
		}
		#endregion

		#region Tests
		[TestCaseSource(nameof(CreateRadiocomponentTestCases))]
		public void
			CreateRadiocomponent_ReceivedGoodValues_ReturnsObjectOfExpectedType(
				RadiocomponentType radiocomponentType, Type expectedType)
		{
			// Arrange
			var radiocomponentFactory = new RadiocomponentFactory();
			// В качестве значения физической величины радиокомпонента
			// можно взять любое положительное число
			double goodRadiocomponentValue = 500;

			// Act
			object actualObject = radiocomponentFactory.CreateRadiocomponent(
				radiocomponentType, goodRadiocomponentValue);

			// Assert
			Assert.AreEqual(actualObject.GetType(), expectedType);
		}

		[TestCaseSource(nameof(GetRadiocomponentTypeTestCases))]
		public void GetRadiocomponentType_ReceivedGoodValue_ReturnsValue(
			IRadiocomponent radiocomponent, RadiocomponentType expectedType)
		{
			// Arrange
			var radiocomponentFactory = new RadiocomponentFactory();

			// Act
			var actualType = radiocomponentFactory
				.GetRadiocomponentType(radiocomponent);

			// Assert
			Assert.AreEqual(actualType, expectedType);
		}
		#endregion
	}
}
