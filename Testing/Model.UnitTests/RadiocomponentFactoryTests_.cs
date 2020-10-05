using System;
using System.Collections.Generic;
using NUnit.Framework;
using Randomizers;

namespace Model.UnitTests
{
	[TestFixture]
	internal class RadiocomponentFactoryTests_
	{
		#region -- Private fields --

		private static readonly
            List<(RadiocomponentType_ radiocomponentType, Type type,
                IRadiocomponent_ radiocomponent)> _radiocomponentInfoDictionary
                = new List<(RadiocomponentType_ radiocomponentType, Type type,
                IRadiocomponent_ radiocomponent)>
            {
                (RadiocomponentType_.Resistor, typeof(Resistor),
                    new Resistor()),
                (RadiocomponentType_.Inductor, typeof(Inductor),
                    new Inductor()),
                (RadiocomponentType_.Capacitor, typeof(Capacitor),
                    new Capacitor())
            };

		#endregion

		#region -- Constructors --

		public RadiocomponentFactoryTests_()
        {
            RandomizersAmbientContext.Instance = new FakeRandomizer();
        }

		#endregion

		#region TestCaseSources

		private static
			IEnumerable<TestCaseData> CreateRadiocomponentTestCases()
		{
			foreach (var (radiocomponentType, type, _)
				in _radiocomponentInfoDictionary)
			{
				yield return new TestCaseData(radiocomponentType, type)
					.SetName($"Когда метод CreateRadiocomponent " +
					$"вызывается с типом {radiocomponentType} из " +
					$"перечисления {typeof(RadiocomponentType_).Name} и с " +
					$"допустимым значением физической величины " +
					$"радиокомпонента, то он должен вернуть объект типа " +
					$"{radiocomponentType}.");
			}
		}

		private static
			IEnumerable<TestCaseData> GetRadiocomponentTypeTestCases()
		{
			foreach (var (radiocomponentType, type, radiocomponent)
				in _radiocomponentInfoDictionary)
			{
				yield return new TestCaseData(radiocomponent,
					radiocomponentType).SetName($"Когда в метод " +
					$"GetRadiocomponentType передается в качестве " +
					$"параметра объект класса {type.Name}, то он должен " +
					$"вернуть {radiocomponentType} из перечисления " +
					$"{typeof(RadiocomponentType_).Name}.");
			}
		}

        private static IEnumerable<TestCaseData>
            CreateRandomRadiocomponent_NoParameters_TestCasesData()
        {
            var radiocomponents = new List<RadiocomponentBase_>
            {
                new Resistor(1),
                new Inductor(1e-6),
                new Capacitor(1e-9)
            };

            foreach (var radiocomponent in radiocomponents)
            {
                yield return new TestCaseData(radiocomponent).SetName(
                    "Когда вызывается метод " +
                    $"{nameof(RadiocomponentFactory_.CreateRandomRadiocomponent)} " +
					"(и в этом методе используется фэйковый рандомизатор " +
                    $"{nameof(FakeRandomizer)}), то он должен вернуть " +
                    $"радиокомпонент {radiocomponent}");
            }
		}

		#endregion

		#region Tests

		[TestCaseSource(nameof(CreateRadiocomponentTestCases))]
		public void
			CreateRadiocomponent_ReceivedGoodValues_ReturnsObjectOfExpectedType(
				RadiocomponentType_ radiocomponentType, Type expectedType)
		{
			// Arrange
			// В качестве значения физической величины радиокомпонента
			// можно взять любое положительное число
			double goodRadiocomponentValue = 500;

			// Act
			object actualObject = RadiocomponentFactory_.CreateRadiocomponent(
				radiocomponentType, goodRadiocomponentValue);

			// Assert
			Assert.AreEqual(actualObject.GetType(), expectedType);
		}

		[TestCaseSource(nameof(GetRadiocomponentTypeTestCases))]
		public void GetRadiocomponentType_ReceivedGoodValue_ReturnsValue(
			IRadiocomponent_ radiocomponent, RadiocomponentType_ expectedType)
		{
			// Act
			var actualType = RadiocomponentFactory_.GetRadiocomponentType(
                radiocomponent);

			// Assert
			Assert.AreEqual(actualType, expectedType);
		}

		[TestCaseSource(nameof(CreateRandomRadiocomponent_NoParameters_TestCasesData))]
        public void CreateRandomRadiocomponent_NoParameter_ReturnsValue(
            IRadiocomponent_ expectedRadiocomponent)
        {
            // Act
            var actualRadiocomponent = RadiocomponentFactory_
                .CreateRandomRadiocomponent();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(actualRadiocomponent.GetType(),
                    expectedRadiocomponent.GetType());

                Assert.AreEqual(actualRadiocomponent.Value,
                    expectedRadiocomponent.Value);
            });
		}

		#endregion
	}
}
