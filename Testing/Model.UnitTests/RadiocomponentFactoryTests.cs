using System;
using System.Collections.Generic;
using NUnit.Framework;
using Randomizers;

namespace Model.UnitTests
{
	[TestFixture]
	internal class RadiocomponentFactoryTests
	{
		#region -- Private fields --

		private static readonly
            List<(RadiocomponentType radiocomponentType, Type type,
                IRadiocomponent radiocomponent)> _radiocomponentInfoTuples
                = new List<(RadiocomponentType radiocomponentType, Type type,
                IRadiocomponent radiocomponent)>
            {
                (RadiocomponentType.Resistor, typeof(Resistor),
                    new Resistor()),
                (RadiocomponentType.Inductor, typeof(Inductor),
                    new Inductor()),
                (RadiocomponentType.Capacitor, typeof(Capacitor),
                    new Capacitor())
            };

		#endregion

		#region -- Constructors --

		public RadiocomponentFactoryTests()
        {
            RandomizersAmbientContext.Instance = new FakeRandomizer();
        }

		#endregion

		#region TestCaseSources

		private static
			IEnumerable<TestCaseData> GetRadiocomponent_TestCasesData()
		{
			foreach (var (radiocomponentType, type, _)
				in _radiocomponentInfoTuples)
			{
				yield return new TestCaseData(radiocomponentType, type)
                    .SetName("Когда метод " +
                             $"{nameof(RadiocomponentFactory.GetRadiocomponent)} " +
                             $"вызывается с типом {radiocomponentType} из " +
                             "перечисления " +
                             $"{typeof(RadiocomponentType).Name} и с " +
                             "допустимым значением физической величины " +
                             "радиокомпонента, то он должен вернуть " +
                             $"объект типа {radiocomponentType}.");
			}
		}

		/*private static
			IEnumerable<TestCaseData> GetRadiocomponentType_TestCasesData()
		{
			foreach (var (radiocomponentType, type, radiocomponent)
				in _radiocomponentInfoTuples)
			{
				yield return new TestCaseData(radiocomponent,
                    radiocomponentType).SetName(
                    "Когда методу " +
                    $"{nameof(RadiocomponentFactory.GetRadiocomponentType)} " +
                    "передается в качестве параметра объект класса " +
                    $"{type.Name}, то он должен вернуть " +
                    $"{radiocomponentType} из перечисления " +
                    $"{typeof(RadiocomponentType).Name}.");
			}
		}*/

        private static IEnumerable<TestCaseData>
            GetRandomRadiocomponent_NoParameters_TestCasesData()
        {
            var radiocomponents = new List<RadiocomponentBase>
            {
                new Resistor(1),
                new Inductor(1e-6),
                new Capacitor(1e-9)
            };

            foreach (var radiocomponent in radiocomponents)
            {
                yield return new TestCaseData(radiocomponent).SetName(
                    "Когда вызывается метод " +
                    $"{nameof(RadiocomponentFactory.GetRandomRadiocomponent)} " +
					"(и в этом методе используется фэйковый рандомизатор " +
                    $"{nameof(FakeRandomizer)}), то он должен вернуть " +
                    $"радиокомпонент {radiocomponent}");
            }
		}

		#endregion

		#region Tests

		[TestCaseSource(nameof(GetRadiocomponent_TestCasesData))]
		public void
			GetRadiocomponent_ReceivedGoodValues_ReturnsObjectOfExpectedType(
				RadiocomponentType radiocomponentType, Type expectedType)
		{
			// Arrange
			// В качестве значения физической величины радиокомпонента
			// можно взять любое положительное число
			double goodRadiocomponentValue = 500;

			// Act
			object actualObject = RadiocomponentFactory.GetRadiocomponent(
				radiocomponentType, goodRadiocomponentValue);

			// Assert
			Assert.AreEqual(actualObject.GetType(), expectedType);
		}

		/*[TestCaseSource(nameof(GetRadiocomponentType_TestCasesData))]
		public void GetRadiocomponentType_ReceivedGoodValue_ReturnsValue(
			IRadiocomponent radiocomponent, RadiocomponentType expectedType)
		{
			// Act
			var actualType = RadiocomponentFactory.GetRadiocomponentType(
                radiocomponent);

			// Assert
			Assert.AreEqual(actualType, expectedType);
		}*/

		[TestCaseSource(nameof(GetRandomRadiocomponent_NoParameters_TestCasesData))]
        public void GetRandomRadiocomponent_NoParameter_ReturnsValue(
            IRadiocomponent expectedRadiocomponent)
        {
            // Act
            var actualRadiocomponent = RadiocomponentFactory
                .GetRandomRadiocomponent();

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
