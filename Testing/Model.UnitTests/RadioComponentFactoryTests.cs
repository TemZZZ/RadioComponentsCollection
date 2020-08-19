using System;
using System.Collections.Generic;
using NUnit.Framework;
using Model.PassiveComponents;


namespace Model.UnitTests
{
	[TestFixture]
	class RadioComponentFactoryTests
	{
		private static readonly List<(RadioComponentType radioComponentType,
			Type type, IRadiocomponent radioComponent)>
				_radioComponentInfoDictionary
					= new List<(RadioComponentType radioComponentType,
						Type type, IRadiocomponent radioComponent)>
					{
						(RadioComponentType.Resistor, typeof(Resistor),
							new Resistor()),
						(RadioComponentType.Inductor, typeof(Inductor),
							new Inductor()),
						(RadioComponentType.Capacitor, typeof(Capacitor),
							new Capacitor())
					};

		#region TestCaseSources
		private static
			IEnumerable<TestCaseData> CreateRadioComponentTestCases()
		{
			foreach (var (radioComponetType, type, _)
				in _radioComponentInfoDictionary)
			{
				yield return new TestCaseData(radioComponetType, type)
					.SetName($"Когда метод CreateRadioComponent " +
					$"вызывается с типом {radioComponetType} из " +
					$"перечисления {typeof(RadioComponentType).Name} и с " +
					$"допустимым значением физической величины " +
					$"радиокомпонента, то он должен вернуть объект типа " +
					$"{radioComponetType}.");
			}
		}

		private static
			IEnumerable<TestCaseData> GetRadioComponentTypeTestCases()
		{
			foreach (var (radioComponetType, type, radioComponent)
				in _radioComponentInfoDictionary)
			{
				yield return new TestCaseData(radioComponent,
					radioComponetType).SetName($"Когда в метод " +
					$"GetRadioComponentType передается в качестве " +
					$"параметра объект класса {type.Name}, то он должен " +
					$"вернуть {radioComponetType} из перечисления " +
					$"{typeof(RadioComponentType).Name}.");
			}
		}
		#endregion

		#region Tests
		[TestCaseSource(nameof(CreateRadioComponentTestCases))]
		public void
			CreateRadioComponent_ReceivedGoodValues_ReturnsObjectOfExpectedType(
				RadioComponentType radioComponentType, Type expectedType)
		{
			// Arrange
			var radioComponentFactory = new RadioComponentFactory();
			// В качестве значения физической величины радиокомпонента
			// можно взять любое положительное число
			double goodRadioComponentValue = 500;

			// Act
			object actualObject = radioComponentFactory.CreateRadioComponent(
				radioComponentType, goodRadioComponentValue);

			// Assert
			Assert.AreEqual(actualObject.GetType(), expectedType);
		}

		[TestCaseSource(nameof(GetRadioComponentTypeTestCases))]
		public void GetRadioComponentType_ReceivedGoodValue_ReturnsValue(
			IRadiocomponent radiocomponent, RadioComponentType expectedType)
		{
			// Arrange
			var radioComponentFactory = new RadioComponentFactory();

			// Act
			var actualType = radioComponentFactory
				.GetRadioComponentType(radiocomponent);

			// Assert
			Assert.AreEqual(actualType, expectedType);
		}
		#endregion
	}
}
